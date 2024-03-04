using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseModelClasses.Data;
using DatabaseModelClasses.Models;
using DatabaseModelClasses.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace _4870_assignment_1.Controllers
{
	[Authorize(Roles = "Admin, Owner")]
	public class ManifestsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ManifestsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Manifests
		public async Task<IActionResult> Index()
		{
			var manifests = await _context.Manifests
				.Select(m => new ManifestViewModel
				{
					ManifestId = m.ManifestId,
					Id = m.Id,
					TripId = m.TripId,
					Notes = m.Notes!
				})
				.ToListAsync();

			return View(manifests);
		}

		// GET: Manifests/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var manifest = await _context.Manifests
				.Where(m => m.ManifestId == id.Value)
				.Select(m => new ManifestViewModel
				{
					ManifestId = m.ManifestId,
					Id = m.Id,
					TripId = m.TripId,
					Notes = m.Notes!,
					Created = m.Created,
					Modified = m.Modified,
					CreatedBy = m.CreatedBy,
					ModifiedBy = m.ModifiedBy
				})
				.FirstOrDefaultAsync();

			if (manifest == null)
			{
				return NotFound();
			}

			return View(manifest);
		}

		// GET: Manifests/Create
		public IActionResult Create()
		{
			// Prepare the ViewModel for the Create view
			var manifestViewModel = new ManifestViewModel();

			// Populate the dropdown lists
			ViewData["MemberId"] = new SelectList(_context.Members.OrderBy(m => m.Id), "MemberId", "MemberId");
			ViewData["TripId"] = new SelectList(_context.Trips.OrderBy(t => t.TripId), "TripId", "TripId");

			return View(manifestViewModel);
		}


		// POST: Manifests/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ManifestViewModel manifestViewModel)
		{
			if (ModelState.IsValid)
			{
				var manifest = new Manifest
				{
					Id = manifestViewModel.Id,
					TripId = manifestViewModel.TripId,
					Notes = manifestViewModel.Notes,
					Created = DateTime.UtcNow,
					Modified = DateTime.UtcNow,
					CreatedBy = User.Identity!.Name ?? "Default User",
					ModifiedBy = User.Identity.Name ?? "Default User"
				};

				_context.Add(manifest);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", manifestViewModel.Id);
			ViewData["TripId"] = new SelectList(_context.Trips, "TripId", "TripId", manifestViewModel.TripId);
			return View(manifestViewModel);
		}

		// GET: Manifests/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var manifest = await _context.Manifests.FindAsync(id);
			if (manifest == null)
			{
				return NotFound();
			}

			var manifestViewModel = new ManifestViewModel
			{
				ManifestId = manifest.ManifestId,
				Id = manifest.Id,
				TripId = manifest.TripId,
				Notes = manifest.Notes!
			};

			ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", manifest.Id);
			ViewData["TripId"] = new SelectList(_context.Trips, "TripId", "TripId", manifest.TripId);

			return View(manifestViewModel);
		}

		// POST: Manifests/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, ManifestViewModel manifestViewModel)
		{
			if (id != manifestViewModel.ManifestId)
			{
				return NotFound();
			}

			// Populate or Repopulate SelectList for the view
			ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", manifestViewModel.Id);
			ViewData["TripId"] = new SelectList(_context.Trips, "TripId", "TripId", manifestViewModel.TripId);

			if (!ModelState.IsValid)
			{
				return View(manifestViewModel);
			}

			try
			{
				var manifest = await _context.Manifests.FindAsync(id);
				if (manifest == null)
				{
					return NotFound();
				}

				// Update the manifest with the ViewModel data
				manifest.ManifestId = manifestViewModel.ManifestId;
				manifest.Id = manifestViewModel.Id;
				manifest.TripId = manifestViewModel.TripId;
				manifest.Notes = manifestViewModel.Notes;
				manifest.Modified = DateTime.UtcNow;
				manifest.ModifiedBy = User.Identity!.Name ?? "Default User";


				_context.Update(manifest);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ManifestExists(manifestViewModel.ManifestId))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
		}

		// GET: Manifests/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var manifest = await _context.Manifests
					.Include(m => m.Member)
					.Include(m => m.Trip)
					.FirstOrDefaultAsync(m => m.ManifestId == id);
			if (manifest == null)
			{
				return NotFound();
			}

			return View(manifest);
		}

		// POST: Manifests/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var manifest = await _context.Manifests.FindAsync(id);
			if (manifest != null)
			{
				_context.Manifests.Remove(manifest);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ManifestExists(int id)
		{
			return _context.Manifests.Any(e => e.ManifestId == id);
		}
	}
}
