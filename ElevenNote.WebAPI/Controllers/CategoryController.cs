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

        public IHttpActionResult GetCategory()
        {
            CategoryService categoryService = CreateCategoryService();
            var category = categoryService.GetAllCategory();
            return Ok(category);
        }
    }
}
