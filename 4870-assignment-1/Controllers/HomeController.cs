using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _4870_assignment_1.Models;
using DatabaseModelClasses.Data;
using DatabaseModelClasses.ViewModels;

namespace _4870_assignment_1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var trips = _context.Trips.Select(t => new TripViewModel
        {
            TripId = t.TripId,
            VehicleId = t.VehicleId,
            Date = t.Date,
            Time = t.Time,
            DestinationAddress = t.DestinationAddress,
            MeetingAddress = t.MeetingAddress
        }).ToList();

        return View(trips);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
