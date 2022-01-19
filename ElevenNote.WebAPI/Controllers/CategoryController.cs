using ElevenNote.Models.CategoryModels;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    [Authorize]
    public class CategoryController : ApiController
    {
        private CategoryService CreateCategoryService()
        {
            var categoryId = User.Identity.GetUserId();
            var categoryService = new CategoryService();
            return categoryService;
        }

        [HttpGet]
        public IHttpActionResult GetCategory()
        {
            CategoryService categoryService = CreateCategoryService();
            var category = categoryService.GetAllCategory();
            return Ok(category);
        }

        [HttpGet]
        public IHttpActionResult GetCategoryById(int id)
        {
            CategoryService categoryService = CreateCategoryService();
            var category = categoryService.GetCategoryById(id);
            return Ok(category);
        }

        [HttpPost]
        public IHttpActionResult PostCategory(CategoryCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryService = CreateCategoryService();

            if (!categoryService.CreateCategory(model))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult PutCategory(CategoryEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.UpdateCategory(model))
                return InternalServerError();

            return Ok();
        }
        
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            var service = CreateCategoryService();
            if (!service.DeleteCategory(id))
                return InternalServerError();

            return Ok();
        }
    }
}


