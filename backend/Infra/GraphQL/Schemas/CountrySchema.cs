using GraphQL.Types;
using GraphQL.Utilities;
using Infra.GraphQL.Queries;
using System;

namespace Infra.GraphQL.Schemas
{
    public class CountrySchema : Schema
    {
        public CountrySchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<CountryQuery>();
        }
    }
}
