// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WinPhoneModule.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace SpeechTalk.WinPhone.Modules
{   
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Autofac;

    using Locator.Ioc;
    using Locator.WinPhone.Services;

    public class WinPhoneModule : IModule
    {
        public void Register(ContainerBuilder builer)
        {
            builer.RegisterType<TextToSpeechWinPhone>().As<ITextToSpeech>().SingleInstance();
        }
    }
}
