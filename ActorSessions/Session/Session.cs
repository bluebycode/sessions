using System;


using log4net;
using log4net.Config;

namespace Sessions
{
    public class Session
    {
        protected static readonly ILog log = LogManager.GetLogger (typeof (Session));
        string Id { get; set;}
        public Session (string id)
        {
            this.Id = id;
            log.InfoFormat ("Session created, id: {0}", this.Id);
        }
    }
}

