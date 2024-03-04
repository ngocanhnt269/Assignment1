using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseModelClasses;
using DatabaseModelClasses.Data;
using DatabaseModelClasses.Models;
using DatabaseModelClasses.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace _4870_assignment_1.Controllers
{
    [Authorize(Roles = "Admin, Owner")]
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var vehicles = await _context.Vehicles
                .Include(v => v.Member)
                .ToListAsync();

            var vehicleViewModels = vehicles.Select(v => new VehicleViewModel
            {
                VehicleId = v.VehicleId,
                Model = v.Model,
                Make = v.Make,
                Year = v.Year,
                NumberOfSeats = v.NumberOfSeats,
                VehicleType = v.VehicleType,
                Id = v.Id,
            }).ToList();

            return View(vehicleViewModels);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .Include(v => v.Member)
                .FirstOrDefaultAsync(m => m.VehicleId == id);

            if (vehicle == null)
            {
                return NotFound();
            }

            // Map to VehicleViewModel
            var viewModel = new VehicleViewModel
            {
                VehicleId = vehicle.VehicleId,
                Model = vehicle.Model,
                Make = vehicle.Make,
                Year = vehicle.Year,
                NumberOfSeats = vehicle.NumberOfSeats,
                VehicleType = vehicle.VehicleType,
                Id = vehicle.Id,
                Created = vehicle.Created,
                Modified = vehicle.Modified,
                CreatedBy = vehicle.CreatedBy,
                ModifiedBy = vehicle.ModifiedBy
            };

            return View(viewModel);
        }


        // GET: Vehicles/Create
        public IActionResult Create()
        {
            // This will populate the dropdown with MemberId as both the value and the text displayed
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId");
            return View();
        }

        // POST: Vehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleViewModel viewModel)
        {
            // Check if the Name claim is set
            var nameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (nameClaim == null)
            {
                Console.WriteLine("Name claim is not set.");
            }
            else
            {
                Console.WriteLine($"Name claim is set with value: {nameClaim.Value}");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.SelectMany(x => x.Value!.Errors.Select(p => p.ErrorMessage)).ToList();

                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
            }

            if (ModelState.IsValid)
            {
                var vehicle = new Vehicle
                {
                    Model = viewModel.Model!,
                    Make = viewModel.Make!,
                    Year = viewModel.Year,
                    NumberOfSeats = viewModel.NumberOfSeats,
                    VehicleType = viewModel.VehicleType!,
                    Id = viewModel.Id,
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    CreatedBy = User.Identity!.Name ?? "Default User",
                    ModifiedBy = User.Identity.Name ?? "Default User"
                };

                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateMembersDropDownList(viewModel.Id);
            return View(viewModel);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            var viewModel = new VehicleViewModel
            {
                VehicleId = vehicle.VehicleId,
                Model = vehicle.Model,
                Make = vehicle.Make,
                Year = vehicle.Year,
                NumberOfSeats = vehicle.NumberOfSeats,
                VehicleType = vehicle.VehicleType,
                Id = vehicle.Id
            };

            // Populate the SelectList for the dropdown
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", vehicle.Id);

            return View(viewModel);
        }

        // POST: Vehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VehicleViewModel viewModel)
        {
            if (id != viewModel.VehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var vehicleToUpdate = await _context.Vehicles.FindAsync(id);
                if (vehicleToUpdate == null)
                {
                    return NotFound();
                }

                vehicleToUpdate.Model = viewModel.Model!;
                vehicleToUpdate.Make = viewModel.Make!;
                vehicleToUpdate.Year = viewModel.Year;
                vehicleToUpdate.NumberOfSeats = viewModel.NumberOfSeats;
                vehicleToUpdate.VehicleType = viewModel.VehicleType!;
                vehicleToUpdate.Id = viewModel.Id;
                //vehicleToUpdate.Modified = DateTime.UtcNow;
                vehicleToUpdate.ModifiedBy = User.Identity!.Name ?? "Default User"; //If ModifiedBy is null, set to "Default User"

                try
                {
                    vehicleToUpdate.Modified = DateTime.UtcNow; // Update the Modified property with the current date and time
                    _context.Update(vehicleToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(viewModel.VehicleId))
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
            PopulateMembersDropDownList(viewModel.Id);
            return View(viewModel);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .Include(v => v.Member)
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void PopulateMembersDropDownList(object? selectedMember = null)
        {
            var membersQuery = from d in _context.Members
                               orderby d.Id
                               select d;
            ViewData["MemberId"] = new SelectList(membersQuery, "MemberId", "MemberId", selectedMember);
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.VehicleId == id);
        }
    }
}
