using ExpenseTracker.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.DataAccess.Entities
{
	public class SummaryEntity
	{
		[Key]
		public int Id { get; set; }

		public DateTime StartDate { get; set; } = DateTime.Now;
		public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

		[Required]
		public string UserId { get; set; }
		public AppUserEntity User { get; set; }

		public int TransactionId { get; set; }
		[ForeignKey("TransactionId")]
		public TransactionEntity Transaction { get; set; }

		public int IncomeId { get; set; }
		[ForeignKey("IncomeId")]
		public IncomeEntity Income { get; set; }

		public int? SavingId { get; set; }
		[ForeignKey("SavingId")]
		public SavingEntity Saving { get; set; }
	}
}
