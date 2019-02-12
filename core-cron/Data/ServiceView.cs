using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Cron.Data
{
	public class ServiceView
	{
		public int ServiceId { get; set; }
		public string ServiceName { get; set; }
		public string ServiceIdentifier { get; set; }
		public DateTimeOffset DateAdded { get; set; }
		public byte[] RowVersion { get; set; }
		public DateTime LastUpdate { get; set; }
		public int UpdateFrequencyInHours { get; set; }
	}
}
