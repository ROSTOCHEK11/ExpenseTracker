using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.DataAccess.Entities
{
	public class AppUserEntity : IdentityUser
	{
		[MaxLength(50)]
		[Required]
		public string FirstName { get; set; }

		[MaxLength(50)]
		[Required]
		public string LastName { get; set; }

		public string? Photo { get; set; }

		public string? RefreshToken { get; set; }
		public DateTime RefreshTokenExpireTime { get; set; }

		public ICollection<IncomeEntity> Incomes { get; set; } = new List<IncomeEntity>();
		public ICollection<SavingEntity> Savings { get; set; } = new List<SavingEntity>();
		public ICollection<TransactionEntity> Transactions { get; set; } = new List<TransactionEntity>();
	}
}
