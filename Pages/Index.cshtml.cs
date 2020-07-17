using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuizKnock12HourPlayer.Models;

namespace QuizKnock12HourPlayer.Pages
{
	public class IndexModel : PageModel
	{
        private readonly QuizKnock12HourPlayer.Models.qk12hContext _context;

		public IndexModel(QuizKnock12HourPlayer.Models.qk12hContext context)
		{
            _context = context;
		}

		public IActionResult OnGet()
		{
			var loginUserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
			if (this.PlayersExists(loginUserId))
			{
				return RedirectToPage("/Players/Edit", new { id = loginUserId });
			}
			else
			{
				return RedirectToPage("/Players/Create");
			}

		}
		private bool PlayersExists(string id)
		{
            return _context.Players.Any(e => e.Userid == id);
		}
	}
}
