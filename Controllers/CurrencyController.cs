using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using TestApp.Model;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    public class CurrencyController : Controller
    {
        private readonly GeneralDbContext _dbContext;

        public CurrencyController(GeneralDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<CurrencyDTO> Get()
        {
            var currencies = _dbContext.Currencies.Where(c => !c.Disabled).OrderBy(c => c.SortOrder).ProjectTo<CurrencyDTO>().ToList();
            return currencies;
        }
    }
}