using Microsoft.AspNetCore.Identity;
using ExpenseTracker.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Core.Models
{
	public class AppUser : IdentityUser
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Photo {  get; set; }

        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpireTime { get; set; }

		public List<Income> Incomes { get; set; } = new List<Income>();
		public List<Transaction> Transactions { get; set; } = new List<Transaction>();
		public List<Saving> Savings { get; set; } = new List<Saving>();


	}

}

