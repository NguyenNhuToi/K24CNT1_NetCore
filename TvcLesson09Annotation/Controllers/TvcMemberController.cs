using Microsoft.AspNetCore.Mvc;
using TvcLesson09Annotation.Models.DataModels;
using TvcLesson09Annotation.Models.DataViewModels;

namespace TvcLesson09Annotation.Controllers
{
    public class TvcMemberController : Controller
    {
        private static List<TvcMember> _tvcMembers = new List<TvcMember>();

        // ==================== INDEX ====================
        // GET: TvcMember
        public IActionResult Index()
        {
            return View(_tvcMembers);  
        }

        // ==================== DETAILS ====================
        // GET: TvcMember/Details/5
        public IActionResult Details(int id)
        {
            var member = _tvcMembers.FirstOrDefault(m => m.TvcMemberId == id);
            if (member == null) return NotFound();
            return View(member);  
        }

        // ==================== CREATE (GET) ====================
        // GET: TvcMember/Create
        public IActionResult Create()
        {
            return View();
        }

        // ==================== CREATE (POST) ====================
        // POST: TvcMember/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TvcMemberRegister model)   
        {
            if (ModelState.IsValid)  
            {
                var member = new TvcMember
                {
                    TvcMemberId = _tvcMembers.Count > 0
                                  ? _tvcMembers.Max(m => m.TvcMemberId) + 1
                                  : 1,
                    TvcUserName = model.TvcUserName,
                    TvcPassword = model.TvcPassword,
                    TvcEmail = model.TvcEmail,
                    TvcPhoneNumber = model.TvcPhoneNumber,
                    TvcFullName = model.TvcFullName,
                    TvcDateOfBirth = model.TvcDateOfBirth
                };

                _tvcMembers.Add(member);  
                return RedirectToAction(nameof(Index));
            }

            return View(model);   
        }

        // ==================== EDIT (GET) ====================
        // GET: TvcMember/Edit/5
        public IActionResult Edit(int id)
        {
            var member = _tvcMembers.FirstOrDefault(m => m.TvcMemberId == id);
            if (member == null) return NotFound();

            var model = new TvcMemberRegister
            {
                TvcMemberId = member.TvcMemberId,
                TvcUserName = member.TvcUserName,
                TvcPassword = member.TvcPassword,
                TvcEmail = member.TvcEmail,
                TvcPhoneNumber = member.TvcPhoneNumber,
                TvcFullName = member.TvcFullName,
                TvcDateOfBirth = member.TvcDateOfBirth
            };
            return View(model);   
        }

        // ==================== EDIT (POST) ====================
        // POST: TvcMember/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TvcMemberRegister model)   
        {
            if (id != model.TvcMemberId) return NotFound();

            if (ModelState.IsValid)
            {
                var member = _tvcMembers.FirstOrDefault(m => m.TvcMemberId == id);
                if (member == null) return NotFound();

                member.TvcUserName = model.TvcUserName;
                member.TvcPassword = model.TvcPassword;
                member.TvcEmail = model.TvcEmail;
                member.TvcPhoneNumber = model.TvcPhoneNumber;
                member.TvcFullName = model.TvcFullName;
                member.TvcDateOfBirth = model.TvcDateOfBirth;

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // ==================== DELETE (GET) ====================
        // GET: TvcMember/Delete/5
        public IActionResult Delete(int id)
        {
            var member = _tvcMembers.FirstOrDefault(m => m.TvcMemberId == id);
            if (member == null) return NotFound();
            return View(member);   
        }

        // ==================== DELETE (POST) ====================
        // POST: TvcMember/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)   
        {
            var member = _tvcMembers.FirstOrDefault(m => m.TvcMemberId == id);
            if (member != null)
            {
                _tvcMembers.Remove(member);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}