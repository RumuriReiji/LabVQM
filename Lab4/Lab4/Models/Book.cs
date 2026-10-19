using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
namespace Lab4.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId {  get; set; }
        public int GenreId { get; set; }
        public string Image {  get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Summary { get; set; }

        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Chí Phèo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/b1.png",
                    Price = 500000,
                    Summary = "Truyện ngắn hiện thực xuất sắc của nhà văn Nam Cao.",
                    TotalPage = 250
                },
                new Book()
                {
                    Id = 2,
                    Title = "Lão Hạc",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/b2.png",
                    Price = 700000,
                    Summary = "Tác phẩm nổi tiếng viết về người nông dân trước Cách mạng tháng Tám.",
                    TotalPage = 200
                },
                new Book()
                {
                    Id = 3,
                    Title = "Tiệm sách của nàng",
                    AuthorId = 2,
                    GenreId = 1,
                    Image = "/images/products/b3.png",
                    Price = 550000,
                    Summary = "Cuốn tiểu thuyết nhẹ nhàng, sâu lắng về tình yêu và sách.",
                    TotalPage = 320
                },
                new Book()
                {
                    Id = 4,
                    Title = "Đi tìm lẽ sống",
                    AuthorId = 3,
                    GenreId = 1,
                    Image = "/images/products/b4.png",
                    Price = 850000,
                    Summary = "Man's Search for Meaning - Tác phẩm kinh điển về tâm lý học.",
                    TotalPage = 350
                }
            };

            return books;
        }
       
        public Book GetBookById(int id)
        {
            Book book = this.GetBookList().FirstOrDefault(b => b.Id == id);
            return book;
        }
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Nam Cao" },
            new SelectListItem { Value = "2", Text = "Toshikazu Kawaguchi" },
            new SelectListItem { Value = "3", Text = "Viktor E. Frankl" },
            new SelectListItem { Value = "4", Text = "Nguyễn Nhật Ánh" }
        };

        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Văn học" },
            new SelectListItem { Value = "2", Text = "Tâm lý học" },
            new SelectListItem { Value = "3", Text = "Tiểu thuyết" },
            new SelectListItem { Value = "4", Text = "Truyện ngắn" }
        };
    }
}
