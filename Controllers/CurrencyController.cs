using System;
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

        [HttpPost]
        public ActionResult Create([FromBody] CurrencyDTO dto)
        {
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var currency = new Currency
                    {
                        Code = dto.Code,
                        DecimalDigits = dto.DecimalDigits,
                        Description = dto.Description
                    };

                    _dbContext.Currencies.Add(currency);
                    _dbContext.SaveChanges();
                    trans.Commit();
                    dto.Id = currency.Id;
                }
                catch (Exception e)
                {
                    return Json(new { status = "Fail", message = e.Message });
                }
            }
            return Json(new { status = "OK", currency = dto });
        }
    }
}