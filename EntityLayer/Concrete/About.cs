﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class About
	{
		[Key]
		public int AboutId { get; set; }
		public string AboutHistory { get; set; }
		public string AboutUs { get; set; }

	}
}
