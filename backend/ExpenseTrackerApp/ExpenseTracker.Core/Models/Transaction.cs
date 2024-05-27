using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Core.Models
{
	public class Transaction
	{
		public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public int CategoryId { get; set; }


    }
}
