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
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TripsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trips
        public async Task<IActionResult> Index()
        {
            var trips = await _context.Trips
                .Select(t => new TripViewModel
                {
                    TripId = t.TripId,
                    VehicleId = t.VehicleId,
                    Date = t.Date,
                    Time = t.Time,
                    DestinationAddress = t.DestinationAddress!,
                    MeetingAddress = t.MeetingAddress!,
                }).ToListAsync();

            return View(trips);
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.Vehicle)
                .Select(t => new TripViewModel
                {
                    TripId = t.TripId,
                    VehicleId = t.VehicleId,
                    Date = t.Date,
                    Time = t.Time,
                    DestinationAddress = t.DestinationAddress!,
                    MeetingAddress = t.MeetingAddress!,
                    Created = t.Created,
                    Modified = t.Modified,
                    CreatedBy = t.CreatedBy,
                    ModifiedBy = t.ModifiedBy
                })
                .FirstOrDefaultAsync(m => m.TripId == id);

            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trips/Create
        public IActionResult Create()
        {
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "VehicleId");
            return View();
        }


        // POST: Trips/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TripViewModel tripViewModel)
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
                var trip = new Trip
                {
                    VehicleId = tripViewModel.VehicleId,
                    Date = tripViewModel.Date,
                    Time = tripViewModel.Time,
                    DestinationAddress = tripViewModel.DestinationAddress,
                    MeetingAddress = tripViewModel.MeetingAddress,
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    CreatedBy = User.Identity!.Name ?? "Default User",
                    ModifiedBy = User.Identity.Name ?? "Default User"
                };

                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "VehicleId");

            return View(tripViewModel);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            // Create a new TripViewModel and populate it with values from the trip entity
            var tripViewModel = new TripViewModel
            {
                TripId = trip.TripId,
                VehicleId = trip.VehicleId,
                Date = trip.Date,
                Time = trip.Time,
                DestinationAddress = trip.DestinationAddress!,
                MeetingAddress = trip.MeetingAddress!,
            };

            // Populates the SelectList for Vehicles
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "VehicleId", trip.VehicleId);

            // Passes the TripViewModel to the view
            return View(tripViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TripViewModel tripViewModel)
        {
            if (id != tripViewModel.TripId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    var trip = await _context.Trips.FindAsync(id);
                    if (trip == null)
                    {
                        return NotFound();
                    }

                    trip.VehicleId = tripViewModel.VehicleId;
                    trip.Date = tripViewModel.Date;
                    trip.Time = tripViewModel.Time;
                    trip.DestinationAddress = tripViewModel.DestinationAddress;
                    trip.MeetingAddress = tripViewModel.MeetingAddress;
                    trip.Modified = DateTime.UtcNow;
                    trip.ModifiedBy = User.Identity!.Name ?? "Default User";

                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(tripViewModel.TripId))
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
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "VehicleId");
            return View(tripViewModel);
        }

        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
            return _context.Trips.Any(e => e.TripId == id);
        }
    }
}
