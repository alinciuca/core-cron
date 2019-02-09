using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Cron.Data
{
    public class Heartbeat
    {
        public int HeartbeatId { get; set; }
        public int ServiceId { get; set; }
        public DateTime LastUpdate { get; set; }
        public Service Service { get; set; }
		public byte[] RowVersion { get; set; }
	}
}
