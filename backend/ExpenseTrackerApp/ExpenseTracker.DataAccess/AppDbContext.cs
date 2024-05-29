using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.DataAccess.Entities;

namespace ExpenseTracker.DataAccess
{
	public class AppDbContext : IdentityDbContext<AppUserEntity>
	{

        public DbSet<CategoryEntity> Categories { get; set; }
		public DbSet<TransactionEntity> Transactions { get; set; }
		public DbSet<IncomeEntity> Incomes { get; set; }
		public DbSet<SavedAmountEntity> SavedAmounts { get; set; }
		public DbSet<SavingEntity> Savings { get; set; }
		public DbSet<SummaryEntity> Summaries { get; set; }


		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Transaction relationship
			modelBuilder.Entity<SummaryEntity>()
				.HasOne(s => s.Transaction)
				.WithMany()
				.HasForeignKey(s => s.TransactionId)
				.OnDelete(DeleteBehavior.NoAction);  // Prevent cascade delete

			// Income relationship
			modelBuilder.Entity<SummaryEntity>()
				.HasOne(s => s.Income)
				.WithMany()
				.HasForeignKey(s => s.IncomeId)
				.OnDelete(DeleteBehavior.NoAction);  // Prevent cascade delete

			// Saving relationship
			modelBuilder.Entity<SummaryEntity>()
				.HasOne(s => s.Saving)
				.WithMany()
				.HasForeignKey(s => s.SavingId)
				.OnDelete(DeleteBehavior.NoAction);  // Prevent cascade delete, handles nulls naturally

		}

	}
}
