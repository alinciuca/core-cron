using Core.Cron.Data;
using System;

namespace Core.Cron.Models
{
	public static class ModelToDtoExtensions
	{
		public static Service ToService(this RegistrationDto dto) => new Service
		{
			DateAdded = DateTime.Now,
			ServiceName = dto.ServiceName,
			ServiceIdentifier = Guid.NewGuid().ToString()
		};
	}
}
