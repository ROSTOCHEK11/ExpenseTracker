﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Core.Models
{
	public class Income
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }


		public int UserId { get; set; }
		public User User { get; set; }

		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}