using ExpenseTracker.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.DataAccess.Entities
{
	public class SavingEntity
	{
		[Key]
		public int Id { get; set; }

		[MaxLength(50)]
		[Column(TypeName = "varchar(50)")]
		public string Title { get; set; }

		[MaxLength(200)]
		[Column(TypeName = "varchar(200)")]
		public string Description { get; set; }

		public decimal TargetAmount { get; set; }
		public DateTime Date { get; set; }

		[Required]
		public string UserId { get; set; }
		public AppUserEntity User { get; set; }

		[Required]
		public int CategoryId { get; set; }
		public CategoryEntity Category { get; set; }

		public ICollection<SavedAmountEntity> SavedAmounts { get; set; } = new List<SavedAmountEntity>();
	}
}

