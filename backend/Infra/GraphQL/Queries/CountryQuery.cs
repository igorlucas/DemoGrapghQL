using Domain.Entities;
using GraphQL;
using GraphQL.Types;
using Infra.GraphQL.GraphTypes;
using Infra.IRepositories;
using System.Linq;
using Web.Contracts.IRepositories;

namespace Infra.GraphQL.Queries
{
    public class CountryQuery : ObjectGraphType
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICrudRepository<User> _crudRepositiry;

        public CountryQuery(ICountryRepository countryRepository, ICrudRepository<User> crudRepositiry)
        {
            _countryRepository = countryRepository;
            _crudRepositiry = crudRepositiry;

            Name = "Query";
            Field<ListGraphType<CountryGraphType>>("countries", "Returns a list of Country", resolve: context => _countryRepository.Countries);
            Field<CountryGraphType>("country", "Returns a Single country",
                new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Country Id" }),
                    context => _countryRepository.Countries.Single(x => x.Id == context.Arguments["id"].GetPropertyValue<string>()));

            Field<ListGraphType<UserGraphType>>("users", "Returns a list of users", resolve: context => _crudRepositiry.Read());
        }
    }
}
