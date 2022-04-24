using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System;

namespace Simbi.Mappings;

public static class ObjectMappingExtensions
{
    private static readonly IMapper mapper = new Mapper(new MapperConfiguration(config =>
    {
        config.AddExpressionMapping();

        config.AddProfile<EntitiesToServiceModelsProfile>();
        config.AddProfile<ServiceModelsToViewModelsProfile>();
    }));    
    public static T To<T>(this object origin)
    {

        if (origin == null)
        {
            throw new ArgumentNullException(nameof(origin));
        }

        return mapper.Map<T>(origin);
    }
}
