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
        private readonly int _categoryId;

        public CategoryService(int categoryId)
        {
            _categoryId = categoryId;
        }

        public bool CreateCategory(CategoryCreate catModel)
        {
            var entity =
                new Category()
                {
                    CategoryId = _categoryId,
                    CategoryTitle = catModel.CategoryTitle,
                    CreatedUtc = DateTimeOffset.UtcNow
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CategoryListItem> GetAllCategory()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Categories
                    .Select(
                        e =>
                        new CategoryListItem()
                        {
                            CategoryId = e.CategoryId,
                            CategoryTitle = e.CategoryTitle,
                            CreatedUtc = e.CreatedUtc
                        });
                return query.ToArray();
            }

        }
        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == id);
                return
                    new CategoryDetail()
                    {
                        CategoryId = entity.CategoryId,
                        CategoryTitle = entity.CategoryTitle,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == model.CategoryId);
                entity.CategoryId = model.CategoryId;
                entity.CategoryTitle = model.CategoryTitle;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == categoryId);
                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
