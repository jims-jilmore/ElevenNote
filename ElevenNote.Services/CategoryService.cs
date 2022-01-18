using ElevenNote.Data;
using ElevenNote.Models.CategoryModels;
using ElevenNote.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        public CategoryService() { }

        public bool CreateCategory(CategoryCreate catModel)
        {
            var entity =
                new Category()
                {
                    CategoryTitle = catModel.CategoryTitle
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
