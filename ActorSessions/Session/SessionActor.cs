using System;
using Akka;
using Akka.Actor;

using log4net;
using log4net.Config;

using Akka.Actor.Internal;
namespace Sessions
{
    public class SessionActor: ReceiveActor
    {
        private Session session;

        public SessionActor ()
        {
            session = new Session (
                id:  Self.Path.ToString()
            );
            this.Receive<string> (message => {
                Console.WriteLine ("Received string: " + message.ToString ());
            });
        }


    }
}

