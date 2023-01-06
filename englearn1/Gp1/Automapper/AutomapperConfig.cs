using AutoMapper;

namespace Gp1.Automapper
{
     
    public class AutomapperConfig
    {
        public static MapperConfiguration RegisterMapping()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.AddProfile(new ModelsMappingProfile());

            });
        }
    }
}
