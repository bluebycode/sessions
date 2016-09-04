using System;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Collections.Concurrent;

using System.ComponentModel;
using System.Timers;

using Akka;
using Akka.Actor;
using Akka.Actor.Internal;

using log4net;
using log4net.Config;

using game;
using ProtoBuf;
using Game.Common;
using System.Collections;
using Mono.Unix;

namespace Sessions
{
    public class Launcher
    {
        private static readonly ILog log = LogManager.GetLogger (typeof (Launcher));

        static Launcher ()
        {
            XmlConfigurator.Configure ();
        }

        public static void Main (string [] args)
        {
            if (log.IsInfoEnabled) 
                log.Info ("Application Start");

            UnixSignal [] signals = new UnixSignal [] {
                new UnixSignal (Mono.Unix.Native.Signum.SIGINT),
                new UnixSignal (Mono.Unix.Native.Signum.SIGUSR1),
            };

            var factoryContainer = ActorSystem.Create ("SessionFactory");
            var factory = factoryContainer.ActorOf<SessionFactoryActor> ("sessions");

            Thread.Sleep (5);

            //wait for a kill signal
            UnixSignal.WaitAny (signals, -1);
        }
    }
}

