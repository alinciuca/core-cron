using Core.Cron.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Cron.Models
{
	public static class ModelToDtoExtensions
	{
		public static Service ToDbModel(this RegistrationDto dto) => new Service
		{
			DateAdded = DateTimeOffset.Now,
			ServiceName = dto.ServiceName,
			ServiceIdentifier = Guid.NewGuid().ToString()
		};

		public static Service ToDbModel(this ServiceView view) => new Service
		{
			DateAdded = DateTimeOffset.Now,
			ServiceName = view.ServiceName,
			ServiceIdentifier = Guid.NewGuid().ToString()
		};

		public static IEnumerable<ServiceViewModel> ToViewModel(this IEnumerable<Service> services)
		{
			var temp = new List<ServiceViewModel>();
			if(services?.Any() != true)
			{
				return temp;
			}
			foreach(var service in services)
			{
				temp.Add(service.ToViewModel());
			}
			return temp;
		}

		public static ServiceViewModel ToViewModel(this Service service) => new ServiceViewModel
		{
			ServiceId = service.ServiceId,
			ServiceName = service.ServiceName,
			ServiceIdentifier = service.ServiceIdentifier,
			DateAdded = service.DateAdded.DateTime,
			RowVersion = service.RowVersion
		};
	}
}
