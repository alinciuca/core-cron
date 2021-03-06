﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Cron.Data
{
    public class Service
    {
        public int ServiceId { get; set; }
		public string ServiceName { get; set; }
		public string ServiceIdentifier { get; set; }
        public DateTimeOffset DateAdded { get; set; }
		public byte[] RowVersion { get; set; }

		[JsonIgnore]
        public Collection<Heartbeat> Heartbeats { get; set; }
    }
}
