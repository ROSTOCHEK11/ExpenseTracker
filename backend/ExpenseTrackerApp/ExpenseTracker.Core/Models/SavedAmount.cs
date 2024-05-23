using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Core.Models
{
	public class SavedAmount
	{
		public int Id { get; set; }
		public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public int SavingId { get; set; }
        public Saving Saving { get; set; }
    }
}
