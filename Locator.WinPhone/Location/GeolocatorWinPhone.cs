// --------------------------------------------------------------------------------------------------
//  <copyright file="GeolocatorIOS.cs" company="Flush Arcade Pty Ltd.">
//    Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace Locator.iOS.Location
{
    using System;
    using System.Reactive.Subjects;
    using System.Linq;

    using CoreLocation;
    using UIKit;

    using Locator.Portable.Location;
    using Windows.Devices.Geolocation;

    public class GeolocatorIOS : IGeolocator
    {
        public Subject<IPosition> Positions { get; set; }

        Geolocator geolocator;

        public GeolocatorIOS()
        {
            this.Positions = new Subject<IPosition>();

            this.geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;
        }

        /// <summary>
        /// Start this instance.
        /// </summary>
        public async void Start()
        {
            try
            {
                Geoposition geoposition = await this.geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10)
                    );

                this.geolocator.PositionChanged += geolocatorPositionChanged;

                // push a new position into the sequence
                this.Positions.OnNext(new Position()
                    {
                        Latitude = geoposition.Coordinate.Latitude,
                        Longitude = geoposition.Coordinate.Longitude
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving geoposition - " + ex);
            }

        }

        /// <summary>
        /// Stop this instance.
        /// </summary>
        public void Stop()
        {
            // remove event handler
            this.geolocator.PositionChanged -= geolocatorPositionChanged;
        }

        /// <summary>
        /// Geolocator position changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void geolocatorPositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            // push a new position into the sequence
            this.Positions.OnNext(new Position()
            {
                Latitude = args.Position.Coordinate.Latitude,
                Longitude = args.Position.geoposition.Coordinate.Longitude
            });
        }
    }
}