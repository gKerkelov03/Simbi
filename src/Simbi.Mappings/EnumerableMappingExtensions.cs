using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Simbi.Mappings;

public static class EnumerableMappingExtensions
{
    private static readonly IMapper mapper = new Mapper(new MapperConfiguration(config =>
    {
        config.AddProfile<EntitiesToServiceModelsProfile>();
        config.AddProfile<ServiceModelsToViewModelsProfile>();
    }));

    public static IEnumerable<TDestination> To<TDestination>(
        this IEnumerable source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        foreach (var src in source)
        {
            yield return mapper.Map<TDestination>(src);
        }
    }
}
