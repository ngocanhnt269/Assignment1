using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseModelClasses;
using DatabaseModelClasses.Data;
using DatabaseModelClasses.Models;
using DatabaseModelClasses.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace _4870_assignment_1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MembersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            var members = await _context.Members.ToListAsync();
            var viewModels = members.Select(m => new MemberViewModel
            {
                Id = m.Id,
                FirstName = m.FirstName!,
                LastName = m.LastName!,
                Email = m.Email!,
                Mobile = m.Mobile!,
                Street = m.Street!,
                City = m.City!,
                PostalCode = m.PostalCode!,
                Country = m.Country!
            }).ToList();

            return View(viewModels);
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Fetch the Member entity from the database
            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id);

            if (member == null)
            {
                return NotFound();
            }

            // Map the Member entity to the MemberViewModel, excluding system-managed fields
            var viewModel = new MemberViewModel
            {
                Id = member.Id,
                FirstName = member.FirstName!,
                LastName = member.LastName!,
                Email = member.Email!,
                Mobile = member.Mobile!,
                Street = member.Street!,
                City = member.City!,
                PostalCode = member.PostalCode!,
                Country = member.Country!,
                Created = member.Created,
                Modified = member.Modified,
                CreatedBy = member.CreatedBy,
                ModifiedBy = member.ModifiedBy
            };

            return View(viewModel);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var member = new Member
                {
                    // Map ViewModel to Entity
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Email = viewModel.Email,
                    Mobile = viewModel.Mobile,
                    Street = viewModel.Street,
                    City = viewModel.City,
                    PostalCode = viewModel.PostalCode,
                    Country = viewModel.Country,
                    // System-managed fields are set within the application, not by user input
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    CreatedBy = User.Identity!.Name ?? "Default User",
                    ModifiedBy = User.Identity.Name ?? "Default User"
                };

                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Return ViewModel to the view if ModelState is invalid
            return View(viewModel);
        }

        //GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var member = await _context.Members.FindAsync(id);
            if (member == null) return NotFound();

            var viewModel = new MemberViewModel
            {
                Id = member.Id,
                FirstName = member.FirstName!,
                LastName = member.LastName!,
                Email = member.Email!,
                Mobile = member.Mobile!,
                Street = member.Street!,
                City = member.City!,
                PostalCode = member.PostalCode!,
                Country = member.Country!
            };

            return View(viewModel);
        }

        // POST: Members/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MemberViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var memberToUpdate = await _context.Members.FindAsync(id);
                if (memberToUpdate == null)
                {
                    return NotFound();
                }

                // Map changes from ViewModel
                memberToUpdate.FirstName = viewModel.FirstName;
                memberToUpdate.LastName = viewModel.LastName;
                memberToUpdate.Email = viewModel.Email;
                memberToUpdate.Mobile = viewModel.Mobile;
                memberToUpdate.Street = viewModel.Street;
                memberToUpdate.City = viewModel.City;
                memberToUpdate.PostalCode = viewModel.PostalCode;
                memberToUpdate.Country = viewModel.Country;
                memberToUpdate.Modified = DateTime.UtcNow;
                memberToUpdate.ModifiedBy = User.Identity!.Name ?? "Default User"; // If ModifiedBy is null, set to "Default User"

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(viewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            // Return ViewModel to the view if ModelState is invalid
            return View(viewModel);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }
}
