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


		public int UserId { get; set; }
		public User User { get; set; }

		public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }

        public int IncomeId { get; set; }
		public Income Income { get; set; }

        public int SavingId { get; set; }
		public Saving Saving { get; set; }
	}
}
