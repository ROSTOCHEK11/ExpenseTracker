using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.DataAccess.Entities
{
	public class CategoryEntity
	{
		[Key]
		public int Id { get; set; }

		[MaxLength(50)]
		[Column(TypeName = "varchar(50)")]
		public string Title { get; set; }

		public string Icon { get; set; }
		public CategoryTypeEntity Type { get; set; }

		public ICollection<IncomeEntity> Incomes { get; set; } = new List<IncomeEntity>();
		public ICollection<SavingEntity> Savings { get; set; } = new List<SavingEntity>();
		public ICollection<TransactionEntity> Transactions { get; set; } = new List<TransactionEntity>();
	}
}
