using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Cron.Models
{
	public class ServiceViewModel
	{
		[Required]
		[StringLength(500)]
		public string ServiceName { get; set; }

		public string ServiceIdentifier { get; set; }
		public DateTimeOffset DateAdded { get; set; }
		public int ServiceId { get; internal set; }
	}
}
