using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineCaters.Data;
using OnlineCaters.Models;

namespace OnlineCaters.Controllers
{
    public class UserloginsController : Controller
    {
        private readonly CatersContext _context;

        public UserloginsController(CatersContext context)
        {
            _context = context;
        }

        // GET: Userlogins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Userlogin.ToListAsync());
        }

        // GET: Userlogins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userlogin = await _context.Userlogin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userlogin == null)
            {
                return NotFound();
            }

            return View(userlogin);
        }

        // GET: Userlogins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Userlogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,FullName,Email")] Userlogin userlogin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userlogin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userlogin);
        }

        // GET: Userlogins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userlogin = await _context.Userlogin.FindAsync(id);
            if (userlogin == null)
            {
                return NotFound();
            }
            return View(userlogin);
        }

        // POST: Userlogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,FullName,Email")] Userlogin userlogin)
        {
            if (id != userlogin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userlogin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserloginExists(userlogin.Id))
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
            return View(userlogin);
        }

        // GET: Userlogins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userlogin = await _context.Userlogin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userlogin == null)
            {
                return NotFound();
            }

            return View(userlogin);
        }

        // POST: Userlogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userlogin = await _context.Userlogin.FindAsync(id);
            if (userlogin != null)
            {
                _context.Userlogin.Remove(userlogin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserloginExists(int id)
        {
            return _context.Userlogin.Any(e => e.Id == id);
        }
    }
}
