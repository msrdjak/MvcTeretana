using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTeretana.Data;
using MvcTeretana.Models;

namespace MvcTeretana.Controllers
{
    public class ClansController : Controller
    {
        private readonly MvcTeretanaContext _context;

        public ClansController(MvcTeretanaContext context)
        {
            _context = context;
        }

        // GET: Clans
        public async Task<IActionResult> Index(string searchString)
        {
            var clans = from m in _context.Clan
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                clans = clans.Where(s => s.Ime.Contains(searchString));
            }

            return View(await clans.ToListAsync());
        }

        // GET: Clans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clan = await _context.Clan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clan == null)
            {
                return NotFound();
            }

            return View(clan);
        }

        // GET: Clans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,GodinaRodenja,Spol,RazinaClanarine,ClanarinaVrijediDo,VrstaTreninga")] Clan clan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clan);
        }

        // GET: Clans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clan = await _context.Clan.FindAsync(id);
            if (clan == null)
            {
                return NotFound();
            }
            return View(clan);
        }

        // POST: Clans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,GodinaRodenja,Spol,RazinaClanarine,ClanarinaVrijediDo")] Clan clan)
        {
            if (id != clan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClanExists(clan.Id))
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
            return View(clan);
        }

        // GET: Clans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clan = await _context.Clan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clan == null)
            {
                return NotFound();
            }

            return View(clan);
        }

        // POST: Clans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clan = await _context.Clan.FindAsync(id);
            _context.Clan.Remove(clan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClanExists(int id)
        {
            return _context.Clan.Any(e => e.Id == id);
        }
    }
}
