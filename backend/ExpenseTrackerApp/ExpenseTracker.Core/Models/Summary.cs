using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Core.Models
{
	public class Summary
	{
		public int Id { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
		public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);
		public string UserId { get; set; }
		public List<Transaction> Transactions { get; set; } = new List<Transaction>();
		public List<Income> Incomes { get; set; } = new List<Income>();
		public List<Saving> Savings { get; set; } = new List<Saving>();
	}
}
