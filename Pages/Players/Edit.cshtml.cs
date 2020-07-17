using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuizKnock12HourPlayer.Models;

namespace QuizKnock12HourPlayer.Pages_Players
{
	public class EditModel : PageModel
	{
		private readonly QuizKnock12HourPlayer.Models.qk12hContext _context;

		public EditModel(QuizKnock12HourPlayer.Models.qk12hContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Players Players { get; set; }

		public async Task<IActionResult> OnGetAsync(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Players = await _context.Players.FirstOrDefaultAsync(m => m.Userid == id);

			if (Players == null)
			{
				return NotFound();
			}

			return Page();
		}

		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(Players).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PlayersExists(Players.Userid))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return Page();
		}

		private bool PlayersExists(string id)
		{
			return _context.Players.Any(e => e.Userid == id);
		}

	}
}
