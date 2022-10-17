using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentDetails.Models;

namespace StudentDetails.Controllers
{
    public class StudentTablesController : Controller
    {
        private readonly StudentContext _context;

        public StudentTablesController(StudentContext context)
        {
            _context = context;
        }

        // GET: StudentTables
        public async Task<IActionResult> Index()
        {
              return View(await _context.StudentTables.ToListAsync());
        }

        // GET: StudentTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentTables == null)
            {
                return NotFound();
            }

            var studentTable = await _context.StudentTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentTable == null)
            {
                return NotFound();
            }

            return View(studentTable);
        }

        // GET: StudentTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Mobile,Address,Department")] StudentTable studentTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentTable);
        }

        // GET: StudentTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentTables == null)
            {
                return NotFound();
            }

            var studentTable = await _context.StudentTables.FindAsync(id);
            if (studentTable == null)
            {
                return NotFound();
            }
            return View(studentTable);
        }

        // POST: StudentTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Mobile,Address,Department")] StudentTable studentTable)
        {
            if (id != studentTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentTableExists(studentTable.Id))
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
            return View(studentTable);
        }

        // GET: StudentTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentTables == null)
            {
                return NotFound();
            }

            var studentTable = await _context.StudentTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentTable == null)
            {
                return NotFound();
            }

            return View(studentTable);
        }

        // POST: StudentTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentTables == null)
            {
                return Problem("Entity set 'StudentContext.StudentTables'  is null.");
            }
            var studentTable = await _context.StudentTables.FindAsync(id);
            if (studentTable != null)
            {
                _context.StudentTables.Remove(studentTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentTableExists(int id)
        {
          return _context.StudentTables.Any(e => e.Id == id);
        }
    }
}
