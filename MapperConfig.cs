using AutoMapper;
using TestApp.Model;

namespace TestApp
{
    public class MapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Currency, CurrencyDTO>();
            });
        }
    }
}