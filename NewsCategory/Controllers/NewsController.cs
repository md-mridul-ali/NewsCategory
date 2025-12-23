using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsCategory.DTOs;
using NewsCategory.EF;
using NewsCategory.EF.Models;

namespace NewsCategory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        //auto mapper
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewsDTO, News>().ReverseMap();
                cfg.CreateMap<CategoryDTO, Category>().ReverseMap();

            });
            return new Mapper(config);
        }


        readonly NewsContext db;
        public NewsController(NewsContext db)
        {
            this.db = db;
        }

        //show category
        [HttpGet("categories")]
        public IActionResult Categories()
        {
            var data = db.Categories.ToList();
            return Ok(data);
        }

        //create category
        [HttpPost("createcategory")]
        public IActionResult CreateCategory(CategoryDTO c)
        {
            if (ModelState.IsValid)
            {
                var category = GetMapper().Map<Category>(c);
                db.Categories.Add(category);
                db.SaveChanges();
            }
            return Ok("Category Added");
        }

        //Shows news
        [HttpGet("all")]
        public IActionResult All()
        {
            var data = db.Newss.ToList();
            return Ok(data);
        }

        //create news
        [HttpPost("create")]

        public IActionResult Create(NewsDTO n)
        {

            if (ModelState.IsValid)
            {
                var news = GetMapper().Map<News>(n);
                db.Newss.Add(news);
                db.SaveChanges();
            }
            return Ok("News Added");
        }

        //get news by id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var news = db.Newss.Find(id);
            if (news == null)
            {
                return NotFound();
            }
            return Ok(news);
        }

        //update news
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, NewsDTO n)
        {
            var existingNews = db.Newss.Find(id);
            if (existingNews == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                existingNews.Title = n.Title;
                existingNews.DateTime = n.DateTime;
                existingNews.C_Id = n.C_Id;
                db.Newss.Update(existingNews);
                db.SaveChanges();
                return Ok("News Updated");
            }
            return BadRequest("Invalid data");

        }

        //delete news by id
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var news = db.Newss.Find(id);
            if (news == null)
            {
                return NotFound();
            }
            db.Newss.Remove(news);
            db.SaveChanges();
            return Ok("News Deleted");
        }

    }
}
