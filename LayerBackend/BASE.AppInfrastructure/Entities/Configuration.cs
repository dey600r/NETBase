﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASE.AppInfrastructure.Entities
{
	public class Configuration : BaseEntity<int>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Master { get; set; }

		public virtual ICollection<Vehicle> Vehicles { get; set; }
	}
}