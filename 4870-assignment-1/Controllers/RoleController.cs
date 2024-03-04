using DatabaseModelClasses.Data;
using DatabaseModelClasses.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _4870_assignment_1.Controllers;

[Authorize(Roles = "Admin")]
public class RoleController : Controller
{
    private readonly ApplicationDbContext _context;

    public RoleController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Role
    public async Task<IActionResult> Index()
    {
        return View(await _context.CustomRole.ToListAsync());
    }

    // GET: Role/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var customRole = await _context.CustomRole
            .FirstOrDefaultAsync(m => m.Id == id);
        if (customRole == null)
        {
            return NotFound();
        }

        return View(customRole);
    }

    // GET: Role/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Role/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Description,CreatedDate,Id,Name,NormalizedName,ConcurrencyStamp")] CustomRole customRole)
    {
        if (ModelState.IsValid)
        {
            _context.Add(customRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(customRole);
    }

    // GET: Role/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var customRole = await _context.CustomRole.FindAsync(id);
        if (customRole == null)
        {
            return NotFound();
        }
        return View(customRole);
    }

    // POST: Role/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Description,CreatedDate,Id,Name,NormalizedName,ConcurrencyStamp")] CustomRole customRole)
    {
        if (id != customRole.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(customRole);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomRoleExists(customRole.Id))
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
        return View(customRole);
    }

    // GET: Role/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var customRole = await _context.CustomRole
            .FirstOrDefaultAsync(m => m.Id == id);
        if (customRole == null)
        {
            return NotFound();
        }

        return View(customRole);
    }

    // POST: Role/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var customRole = await _context.CustomRole.FindAsync(id);
        if (customRole != null)
        {
            _context.CustomRole.Remove(customRole);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CustomRoleExists(int id)
    {
        return _context.CustomRole.Any(e => e.Id == id);
    }
}

