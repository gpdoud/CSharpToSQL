﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpToSql {

	public class Student {

		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime Birthday { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public int MajorId { get; set; }
	}
}
