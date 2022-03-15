using System.Collections.Generic;
using System.Threading.Tasks;
using SuggestionAppLibrary.Models;

namespace SuggestionAppLibrary.DataAccess
{
    public interface ICategoryData
    {
        Task CreateCategory(CategoryModel category);
        Task<List<CategoryModel>> GetAllCategories();
    }
}