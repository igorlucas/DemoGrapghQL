using Domain.Entities;
using GraphQL;
using GraphQL.Types;
using Infra.GraphQL.GraphTypes;
using Infra.IRepositories;

namespace Infra.GraphQL.Queries
{
    public class UserQuery : ObjectGraphType
    {
        private readonly ICrudRepository<User> _crudRepositiry;

        public UserQuery(ICrudRepository<User> crudRepositiry)
        {
            _crudRepositiry = crudRepositiry;
            Name = "QueryUser";
            Field<ListGraphType<UserGraphType>>("users", "Returns a list of users", resolve: context => _crudRepositiry.Read());
            //Field<CountryGraphType>("user", "Returns a Single user",
            //    new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "User Id" }),
            //        context => _crudRepositiry.Read(context.Arguments["id"].GetPropertyValue<int>()));
        }
    }
}
