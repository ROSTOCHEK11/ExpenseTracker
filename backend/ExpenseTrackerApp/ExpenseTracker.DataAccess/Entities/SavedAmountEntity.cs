using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.DataAccess.Entities
{
	public class SavedAmountEntity
	{
		[Key]
		public int Id { get; set; }
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }

		[Required]
		public int SavingId { get; set; }
		public SavingEntity Saving { get; set; }
	}
}
