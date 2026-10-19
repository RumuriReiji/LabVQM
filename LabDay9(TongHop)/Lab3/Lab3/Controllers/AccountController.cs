using Lab3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace Lab3.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,
                    Name = "Hoàng Anh",
                    Email = "anh@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/Avatar/01.png"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)
                },
                new Account()
                {
                    Id = 2,
                    Name = "Trường Giang",
                    Email = "giang@gmail.com",
                    Phone = "0986123456",
                    Address = "TP. Hồ Chí Minh",
                    Avatar = Url.Content("~/images/Avatar/02.png"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1999, 3, 20)
                },
                new Account()
                {
                    Id = 3,
                    Name = "Hoàng Thúy",
                    Email = "thuy@gmail.com",
                    Phone = "0986789012",
                    Address = "Đà Nẵng",
                    Avatar = Url.Content("~/images/Avatar/03.png"),
                    Gender = 0,
                    Bio = "My name is small",
                    Birthday = new DateTime(2000, 11, 5)
                },
                new Account()
                {
                    Id = 4,
                    Name = "Nguyễn Văn A",
                    Email = "vana@gmail.com",
                    Phone = "0987123456",
                    Address = "Hải Phòng",
                    Avatar = Url.Content("~/images/Avatar/04.png"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1997, 5, 10)
                },
                new Account()
                {
                    Id = 5,
                    Name = "Trần Thị B",
                    Email = "thib@gmail.com",
                    Phone = "0987234567",
                    Address = "Cần Thơ",
                    Avatar = Url.Content("~/images/Avatar/05.png"),
                    Gender = 0,
                    Bio = "My name is small",
                    Birthday = new DateTime(2001, 9, 25)
                },
                new Account()
                {
                    Id = 6,
                    Name = "Lê Văn C",
                    Email = "vanc@gmail.com",
                    Phone = "0987345678",
                    Address = "Nha Trang",
                    Avatar = Url.Content("~/images/Avatar/06.png"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1996, 12, 30)
                }
            };

            ViewBag.Accounts = accounts;
            return View();
        }
        [Route("ho-so-cua-toi", Name = "profile")]
        public IActionResult Profile(int id)
        {
           List<Account> accounts = new List<Account>
        {
                new Account()
                {
                    Id = 1,
                    Name = "Hoàng Anh",
                    Email = "anh@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/Avatar/01.png"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)
                },
                new Account()
                {
                    Id = 2,
                    Name = "Trường Giang",
                    Email = "giang@gmail.com",
                    Phone = "0986123456",
                    Address = "TP. Hồ Chí Minh",
                    Avatar = Url.Content("~/images/Avatar/02.png"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1999, 3, 20)
                },
                new Account()
                {
                    Id = 3,
                    Name = "Hoàng Thúy",
                    Email = "thuy@gmail.com",
                    Phone = "0986789012",
                    Address = "Đà Nẵng",
                    Avatar = Url.Content("~/images/Avatar/03.png"),
                    Gender = 0,
                    Bio = "My name is small",
                    Birthday = new DateTime(2000, 11, 5)
                },
                new Account()
                {
                    Id = 4,
                    Name = "Nguyễn Văn A",
                    Email = "vana@gmail.com",
                    Phone = "0987123456",
                    Address = "Hải Phòng",
                    Avatar = Url.Content("~/images/Avatar/04.png"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1997, 5, 10)
                },
                new Account()
                {
                    Id = 5,
                    Name = "Trần Thị B",
                    Email = "thib@gmail.com",
                    Phone = "0987234567",
                    Address = "Cần Thơ",
                    Avatar = Url.Content("~/images/Avatar/05.png"),
                    Gender = 0,
                    Bio = "My name is small",
                    Birthday = new DateTime(2001, 9, 25)
                },
                new Account()
                {
                    Id = 6,
                    Name = "Lê Văn C",
                    Email = "vanc@gmail.com",
                    Phone = "0987345678",
                    Address = "Nha Trang",
                    Avatar = Url.Content("~/images/Avatar/06.png"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1996, 12, 30)
                }
        };
            Account account = accounts.FirstOrDefault(ac => ac.Id == id);
            ViewBag.account = account;
            return View();
        }

    }
}
