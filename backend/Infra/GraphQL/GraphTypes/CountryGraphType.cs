using Domain.Entities;
using GraphQL.Types;

namespace Infra.GraphQL.GraphTypes
{
    public class CountryGraphType : ObjectGraphType<Country>
    {
        public CountryGraphType()
        {
            Name = "Country";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Country Id");
            Field(x => x.Name).Description("Country's Name");
            Field(x => x.Capital).Description("Country's Capital");
            Field(x => x.Area).Description("Country's Area");
            Field(x => x.Population).Description("Country's Population");
            Field(x => x.PopulationDensity).Description("Country's Population Density");
        }
    }
}
