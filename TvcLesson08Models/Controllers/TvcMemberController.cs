using Microsoft.AspNetCore.Mvc;
using TvcLesson08Models.Models;

namespace TvcLesson08Models.Controllers
{
    public class TvcMemberController : Controller
    {
        // Mock data - TvcMember
        private static List<TvcMember> _members = new List<TvcMember>()
        {
            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcUserName = "NhuToi",
                TvcPassword = "Nhutoi22022006@@NNT",
                TvcFullName = "Nguyễn Như Tới",
                TvcEmail = "hungcungg312@gmail.com"
            },
            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcUserName = "tranthib",
                TvcPassword = "SecurePass456#",
                TvcFullName = "Trần Thị B",
                TvcEmail = "tranthib@outlook.com"
            },
            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcUserName = "levanc",
                TvcPassword = "MyPassword789$",
                TvcFullName = "Lê Văn C",
                TvcEmail = "levanc@company.com"
            }
        };

        // GET: Danh sách thành viên
        public IActionResult Index()
        {
            return View(_members);
        }
        [HttpGet]
        public IActionResult TvcCreate()
        {
            var member = new TvcMember();
            return View(member);
        }
        [HttpPost]
        public IActionResult TvcCreate(TvcMember tvcMember)
        {
            tvcMember.TvcMemberId = Guid.NewGuid().ToString();
            _members.Add(tvcMember);

            return RedirectToAction("Index");
            //return View(tvcMember);
        }
        [HttpGet]
        public IActionResult TvcEdit(string id)
        {
            var member = _members.Where(x => x.TvcMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }
        [HttpPost]
        public IActionResult TvcEdit(string id, TvcMember tvcMember)
        {
            // var member = _members.Where(x => x.TvcMemberId.Equals(id)).FirstOrDefault();
            for (int i = 0; i < _members.Count; i++)
            {
                if (_members[i].TvcMemberId == id)
                {
                    _members[i].TvcUserName = tvcMember.TvcUserName;
                    _members[i].TvcPassword = tvcMember.TvcPassword;
                    _members[i].TvcFullName = tvcMember.TvcFullName;
                    _members[i].TvcEmail = tvcMember.TvcEmail;

                    return RedirectToAction("Index");
                }

            }
            return View();
        }
        [HttpGet]
        public IActionResult TvcDetails(string id)
        {
            var member = _members.Where(x => x.TvcMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }
        [HttpGet]
        public IActionResult TvcDelete(string id)
        {
            var member = _members.Where(x => x.TvcMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }
        [HttpPost]
        public IActionResult TvcDeleted(string id)
        {
            foreach (var item in _members)
            {
                if (item.TvcMemberId.Equals(id))
                {
                    _members.Remove(item);
                    return RedirectToAction("Index");
                }
            }
            return View("TvcDelete");
        }
    }
}
