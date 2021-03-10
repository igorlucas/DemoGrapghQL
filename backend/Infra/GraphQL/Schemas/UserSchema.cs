using GraphQL.Types;
using GraphQL.Utilities;
using Infra.GraphQL.Queries;
using System;

namespace Infra.GraphQL.Schemas
{
    public class UserSchema : Schema
    {
        public UserSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<UserQuery>();
        }
    }
}