using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizKnock12HourPlayer.Models;

namespace QuizKnock12HourPlayer.Pages_Players
{
	public class CreateModel : PageModel
	{
		private readonly QuizKnock12HourPlayer.Models.qk12hContext _context;

		public CreateModel(QuizKnock12HourPlayer.Models.qk12hContext context)
		{
			_context = context;
		}

		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public Players Players { get; set; }

		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			this.Players.Userid = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
			this.Players.Gotou1 = 0;
			this.Players.Gotou2 = 0;
			this.Players.Gotou3 = 0;
			this.Players.Seikai = 0;
			this.Players.Reset1 = false;
			this.Players.Reset2 = false;

			if (!ModelState.IsValid)
			{
				return Page();
			}
			_context.Players.Add(Players);
			await _context.SaveChangesAsync();

			var loginUserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
			return RedirectToPage("/Players/Edit", new { id = loginUserId });
		}
	}
}
