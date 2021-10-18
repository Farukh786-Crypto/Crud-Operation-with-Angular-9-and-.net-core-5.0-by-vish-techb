using AngularWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DatabaseContext context;

        public CategoryController(DatabaseContext _context)
        {
            context = _context;
        }

        [HttpPost]
        public ActionResult<CategoryMst> AddCategory(CategoryMst category)
        {
            if(category == null)
            {
                return StatusCode(415,"Invalid Category !!");
            }
            context.Categories.Add(category);
            context.SaveChanges();
            return Ok(category);
        }
        [HttpGet("GetAllCategory")]
        public ActionResult<List<CategoryMst>> GetAllCategory()
        {
            // o means false
            return Ok(context.Categories.Where(a=>a.isdelete==0).ToList<CategoryMst>());
        }

        [HttpGet("GetAllCategoryForDDL")]
        public ActionResult<List<CategoryMst>> GetAllCategoryForDDL()
        {
            // o means false and 1 means true
            return Ok(context.Categories.Where(a => a.isdelete == 0 && a.isactive==1).ToList<CategoryMst>());
        }


        [HttpGet("GetCategoryById/{id}")]
        public ActionResult<CategoryMst> GetCategoryById(int id)
        {
            var category = context.Categories.FirstOrDefault<CategoryMst>(a => a.id == id && a.isdelete==0);
            return Ok(category);
        }

        [HttpPut("UpdateCategory")]
        public ActionResult<CategoryMst> UpdateCategory(CategoryMst category)
        {
            var categoryInDb = context.Categories.FirstOrDefault<CategoryMst>
                                (a => a.id == category.id && a.isdelete==0);
            categoryInDb.category = category.category;
            context.SaveChanges();
            return Ok(category);
        }
    }
}
