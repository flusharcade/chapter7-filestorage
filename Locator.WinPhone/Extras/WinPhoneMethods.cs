// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WinPhoneMethods.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.WinPhone.Extras
{
    using UIKit;

    using Locator.Portable.Extras;

    using Windows.UI.Xaml;

    /// <summary>
    /// The methods interface
    /// </summary>
    public class WinPhoneMethods : IMethods
    {
        public void Exit()
        {
            Application.Current.Terminate();
        }
    }
}

