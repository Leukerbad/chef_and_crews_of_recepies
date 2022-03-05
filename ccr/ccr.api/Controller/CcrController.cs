using ccr.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ccr.api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CcrController : ControllerBase
    {
        private CcrContext _db;

        public CcrController(CcrContext ccrContext)
        {
            _db = ccrContext;
        }

        [HttpGet]
        public async Task<List<Recipe>> GetRecipes()
        {
            var recipes = await _db.Recipes.ToListAsync();
            return recipes;
        }
    }
}
