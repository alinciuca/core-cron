using System.ComponentModel.DataAnnotations;

namespace Core.Cron.Models
{
	public class RegistrationDto
	{
		[Required()]
		[StringLength(500)]
		public string ServiceName { get; set; }
	}
}
