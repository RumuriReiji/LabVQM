using Microsoft.AspNetCore.Mvc;
using DemoDay6.Models;

namespace DemoDay6.Controllers
{
    public class SinhVienController : Controller
    {
        private static readonly List<SinhVien> _sinhViens = new List<SinhVien>() 
        {
             new SinhVien
            {
                Id = Guid.NewGuid().ToString(),
                Username = "minhminh",
                Password = "123456",
                Email = "vuminh20041@gmail.com",
                Fullname = "Vũ Quang Minh"
            },
            new SinhVien
            {
                Id = Guid.NewGuid().ToString(),
                Username = "sv002",
                Password = "123456",
                Email = "sv002@gmail.com",
                Fullname = "Trần Thị Bình"
            },
            new SinhVien

            {
                Id = Guid.NewGuid().ToString(),
                Username = "sv003",
                Password = "123456",
                Email = "sv003@gmail.com",
                Fullname = "Lê Minh Cường"
            },
            new SinhVien
            {
                Id = Guid.NewGuid().ToString(),
                Username = "sv004",
                Password = "123456",
                Email = "sv004@gmail.com",
                Fullname = "Phạm Thùy Dung"
            },
            new SinhVien
            {
                Id = Guid.NewGuid().ToString(),
                Username = "sv005",
                Password = "123456",
                Email = "sv005@gmail.com",
                Fullname = "Hoàng Văn Em"
            }
        };
        public IActionResult Index()
        {
            return View(_sinhViens);
        }
        //Create
        public IActionResult Create() {  return View(); }

        //Create - submit
        [HttpPost]
        public IActionResult Create(SinhVien sinhVien)
        {   
            sinhVien.Id = Guid.NewGuid().ToString();
            _sinhViens.Add(sinhVien);
            return RedirectToAction("Index");
        }

        //Edit
        public IActionResult Edit(string id) 
        {  
            var sinhVien = _sinhViens.FirstOrDefault(x => x.Id.Equals(id));
            return View(sinhVien); 
        }

        //Edit - submit
        [HttpPost]
        public IActionResult Edit(string id,SinhVien sinhVien)
        {
            for (int i = 0; i < _sinhViens.Count; i++)
            {
                if (_sinhViens[i].Id == id)
                {
                   
                    _sinhViens[i].Username = sinhVien.Username;
                    _sinhViens[i].Password = sinhVien.Password;
                    _sinhViens[i].Fullname = sinhVien.Fullname;
                    _sinhViens[i].Email = sinhVien.Email;
                    break;
                }
            }
            
            return RedirectToAction("Index");
        }
        public IActionResult SinhVienDetail()
        {
            var sinhVien = new SinhVien() 
            {
                Id = Guid.NewGuid().ToString(),
                Username = "Alahu Alakaba",
                Password = "quangminh1",
                Fullname = "Vũ Quang Minh",
                Email = "vuminh20041@gmail.com",
            };
            return View(sinhVien);
        }
    }
}
