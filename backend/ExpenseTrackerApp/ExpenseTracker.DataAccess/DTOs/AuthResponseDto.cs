using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.DataAccess.DTOs
{
	public class AuthResponseDto
	{
        public string? Token { get; set; } = string.Empty;
        public bool IsSucceed { get; set; }
        public string? Message { get; set; }


    }
}
