using System;
using System.Collections.Generic;

using log4net;
using log4net.Config;

using Akka;
using Akka.Actor;
using Akka.Actor.Internal;

namespace Sessions
{
    public class SessionFactoryActor: ReceiveActor
    {
        protected static readonly ILog log = LogManager.GetLogger (typeof (SessionFactoryActor));

        private readonly int MAX_SESSIONS = 15;
        private ActorSystem container;
        private List<IActorRef> sessions = new List<IActorRef> ();

        public SessionFactoryActor ()
        {
            container = ActorSystem.Create ("Sessions");
            for (var i = 0; i < MAX_SESSIONS; i++) {
                sessions.Add(container.ActorOf<SessionActor> ("session"+ i));
            }
        }
    }
}

