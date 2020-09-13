using System;
using AutoMapper;

namespace Msk.Ordering.Application.Mapper
{
    /// <summary>
    /// https://www.abhith.net/blog/using-automapper-in-a-net-core-class-library/
    /// </summary>
    public static class OrderMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<OrderMappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
