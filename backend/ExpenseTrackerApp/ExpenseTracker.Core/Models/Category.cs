using ExpenseTracker.Core.Types;
using System;
using System.Collections.Generic;
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

    }
}
