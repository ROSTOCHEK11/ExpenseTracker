using ExpenseTracker.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Core.Models
{
	public class Category
	{
		public int Id { get; set; }
        public string Title { get; set; }
		public string Icon { get; set; }
		public CategoryType Type { get; set; }

		public List<Income> Incomes { get; set; } = new List<Income>();
		public List<Transaction> Transactions { get; set; } = new List<Transaction>();
		public List<Saving> Savings { get; set; } = new List<Saving>();

	}
}
