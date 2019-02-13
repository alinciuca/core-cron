using Core.Cron.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Cron.Models
{
	public static class ModelToDtoExtensions
	{
		public static Service ToDbModel(this ServiceView view) => new Service
		{
			DateAdded = DateTimeOffset.Now,
			ServiceName = view.ServiceName,
			ServiceIdentifier = Guid.NewGuid().ToString()
		};
	}
}
