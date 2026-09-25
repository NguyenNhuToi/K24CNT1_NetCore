using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TvcLesson10EFDbFirst.Models;

namespace TvcLesson10EFDbFirst.Controllers
{
    public class TvcMembersController : Controller
    {
        private readonly TvcK24cnt1lesson10EfdbContext _context;

        public TvcMembersController(TvcK24cnt1lesson10EfdbContext context)
        {
            _context = context;
        }

        // GET: TvcMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TvcMembers.ToListAsync());
        }

        // GET: TvcMembers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcMember = await _context.TvcMembers
                .FirstOrDefaultAsync(m => m.Id == id.Value);
            if (tvcMember == null)
            {
                return NotFound();
            }

            return View(tvcMember);
        }

        // GET: TvcMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TvcMembers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TvcUserName,TvcPassword,TvcFullName,TvcEmail,TvcPhone,TvcStatus")] TvcMember tvcMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tvcMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tvcMember);
        }

        // GET: TvcMembers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcMember = await _context.TvcMembers.FindAsync(id.Value);
            if (tvcMember == null)
            {
                return NotFound();
            }
            return View(tvcMember);
        }

        // POST: TvcMembers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,TvcUserName,TvcPassword,TvcFullName,TvcEmail,TvcPhone,TvcStatus")] TvcMember tvcMember)
        {
            if (id != tvcMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvcMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvcMemberExists(tvcMember.Id))
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
            return View(tvcMember);
        }

        // GET: TvcMembers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcMember = await _context.TvcMembers
                .FirstOrDefaultAsync(m => m.Id == id.Value);
            if (tvcMember == null)
            {
                return NotFound();
            }

            return View(tvcMember);
        }

        // POST: TvcMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tvcMember = await _context.TvcMembers.FindAsync(id);
            if (tvcMember != null)
            {
                _context.TvcMembers.Remove(tvcMember);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TvcMemberExists(long id)
        {
            return _context.TvcMembers.Any(e => e.Id == id);
        }
    }
}
