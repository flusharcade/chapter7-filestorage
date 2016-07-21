// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISQLiteSetup.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FileStorage.Portable.DataAccess.Storage
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using System.Linq;

	using SQLite.Net.Interop;
	using SQLite.Net.Async;
	using SQLite.Net;

	using FileStorage.Portable.Threading;
	using FileStorage.Portable.DataAccess.Storable;
	using FileStorage.Portable.DataAccess;
	using FileStorage.Portable.Logging;

	/// <summary>
	/// SQLite storage.
	/// </summary>
	public class SQLiteStorage : ISQLiteStorage
	{
		/// <summary>
		/// The async lock.
		/// </summary>
		private readonly AsyncLock asyncLock = new AsyncLock();

		/// <summary>
		/// The lock object.
		/// </summary>
		private readonly object lockObject = new object();

		/// <summary>
		/// The conn.
		/// </summary>
		private SQLiteConnectionWithLock _conn;

		/// <summary>
		/// The db async.
		/// </summary>
		private SQLiteAsyncConnection _dbAsyncConn;

		/// <summary>
		/// The sqlite platform.
		/// </summary>
		private readonly ISQLitePlatform _sqlitePlatform;

		/// <summary>
		/// The db path.
		/// </summary>
		private string _dbPath;

		/// <summary>
		/// The log.
		/// </summary>
		private readonly ILogger _log;

		/// <summary>
		/// The tag.
		/// </summary>
		private readonly string _tag;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyCareManager.DataAccess.Sqlite.Storable.SQLiteStorage"/> class.
		/// </summary>
		/// <param name="sqliteSetup">Sqlite setup.</param>
		public SQLiteStorage(ISQLiteSetup sqliteSetup, ILogger log)
		{
			_dbPath = sqliteSetup?.DatabasePath;
			_sqlitePlatform = sqliteSetup?.Platform;

			_log = log;
			_tag = $"{GetType()} ";
		}

		/// <summary>
		/// Gets the async connection.
		/// </summary>
		/// <returns>The async connection.</returns>
		public void CreateSQLiteAsyncConnection()
		{
			var connectionFactory = new Func<SQLiteConnectionWithLock>(() =>
				{
					if (_conn == null)
					{
						_conn = new SQLiteConnectionWithLock(_sqlitePlatform, 
					                                         new SQLiteConnectionString(_dbPath, true));
					}

					return _conn;
				});

			_dbAsyncConn = new SQLiteAsyncConnection(connectionFactory);
		}

		/// <summary>
		/// Creates the table.
		/// </summary>
		/// <returns>The table.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public async Task CreateTable<T>(CancellationToken token) where T : class, IStorable, new()
		{
			using (var releaser = await asyncLock.LockAsync())
			{
				await _dbAsyncConn.CreateTableAsync<T>(token);
			}
		}

		/// <summary>
		/// Gets the table.
		/// </summary>
		/// <returns>The table.</returns>
		/// <param name="token">Token.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public async Task<IList<T>> GetTable<T>(CancellationToken token) where T : class, IStorable, new()
		{
			var items = default(IList<T>);

			using (var releaser = await asyncLock.LockAsync())
			{
				try
				{
					items = await _dbAsyncConn.QueryAsync<T>(string.Format("SELECT * FROM {0};", typeof(T).Name));
				}
				catch (Exception error)
				{
					var location = string.Format("GetTable<T>() Failed to 'SELECT *' from table {0}.", typeof(T).Name);

					_log.WriteLineTime(_tag + "\n" +
						location + "\n" +
						"ErrorMessage: \n" +
						error.Message + "\n" +
						"Stacktrace: \n " +
						error.StackTrace);
				}
			}

			return items;
		}

		/// <summary>
		/// Drops the table.
		/// </summary>
		/// <returns>The table.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public async Task DropTable<T>(CancellationToken token) where T : class, IStorable, new()
		{
			using (var releaser = await asyncLock.LockAsync())
			{
				await _dbAsyncConn.DropTableAsync<T>(token);
			}
		}

		/// <summary>
		/// Inserts the object.
		/// </summary>
		/// <returns>The object.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public async Task InsertObject<T>(T item, CancellationToken token) where T : class, IStorable, new()
		{
			using (var releaser = await asyncLock.LockAsync())
			{
				try
				{
					var insertOrReplaceQuery = item.CreateInsertOrReplaceQuery();
					await _dbAsyncConn.QueryAsync<T>(insertOrReplaceQuery);
				}
				catch (Exception error)
				{
					var location = string.Format("InsertObject<T>() Failed to insert or replace object with key {0}.", item.Key);

					_log.WriteLineTime(_tag + "\n" +
						location + "\n" +
						"ErrorMessage: \n" +
						error.Message + "\n" +
						"Stacktrace: \n " +
						error.StackTrace);
				}
			}
		}

		/// <summary>
		/// Gets the object.
		/// </summary>
		/// <returns>The object.</returns>
		/// <param name="key">Key.</param>
		/// <param name="token">Token.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public async Task<T> GetObject<T>(string key, CancellationToken token) where T : class, IStorable, new()
		{
			using (var releaser = await asyncLock.LockAsync())
			{
				try
				{
					var items = await _dbAsyncConn.QueryAsync<T>(string.Format("SELECT * FROM {0} WHERE Key = '{1}';", typeof(T).Name, key));
					if (items != null && items.Count > 0)
					{
						return items.FirstOrDefault();
					}
				}
				catch (Exception error)
				{
					var location = string.Format("GetObject<T>() Failed to get object from key {0}.", key);

					_log.WriteLineTime(_tag + "\n" +
						location + "\n" +
						"ErrorMessage: \n" +
						error.Message + "\n" +
						"Stacktrace: \n " +
						error.StackTrace);
				}
			}

			return default(T);
		}

		/// <summary>
		/// Removes all table objects.
		/// </summary>
		/// <returns>The all table objects.</returns>
		/// <param name="token">Token.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public async Task ClearTable<T>(CancellationToken token) where T : class, IStorable, new()
		{
			using (var releaser = await asyncLock.LockAsync())
			{
				await _dbAsyncConn.QueryAsync<T>(string.Format("DELETE FROM {0};", typeof(T).Name));
			}
		}

		/// <summary>
		/// Deletes the object.
		/// </summary>
		/// <returns>The object.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public async Task DeleteObject<T>(T item, CancellationToken token)
		{
			using (var releaser = await asyncLock.LockAsync())
			{
				await _dbAsyncConn.DeleteAsync(item, token);
			}
		}

		/// <summary>
		/// Deletes the object by key.
		/// </summary>
		/// <returns>The object by key.</returns>
		/// <param name="key">Key.</param>
		/// <param name="token">Token.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public async Task DeleteObjectByKey<T>(string key, CancellationToken token) where T : class, IStorable, new()
		{
			using (var releaser = await asyncLock.LockAsync())
			{
				try
				{
					await _dbAsyncConn.QueryAsync<T>(string.Format("DELETE FROM {0} WHERE Key=\'{1}\';", typeof(T).Name, key));
				}
				catch (Exception error)
				{
					var location = string.Format("DeleteObjectByKey<T>() Failed to delete object from key {0}.", key);

					_log.WriteLineTime(_tag + "\n" +
						location + "\n" +
						"ErrorMessage: \n" +
						error.Message + "\n" +
						"Stacktrace: \n " +
						error.StackTrace);
				}
			}
		}

		/// <summary>
		/// Closes the connection.
		/// </summary>
		/// <returns>The connection.</returns>
		public void CloseConnection()
		{
			lock (lockObject)
			{
				if (_conn != null)
				{
					_conn.Close();
					_conn.Dispose();
					_conn = null;

					// Must be called as the disposal of the connection is not released until the GC runs.
					GC.Collect();
					GC.WaitForPendingFinalizers();
				}
			}
		}
	}
}