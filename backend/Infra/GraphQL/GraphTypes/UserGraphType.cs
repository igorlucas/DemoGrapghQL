using Domain.Entities;
using GraphQL.Types;

namespace Infra.GraphQL.GraphTypes
{
    class UserGraphType : ObjectGraphType<User>
    {
        public UserGraphType()
        {
            Name = "User";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("User Id");
            Field(x => x.UserName).Description("User's UserName");
            Field(x => x.Phone).Description("User's Phone");
            Field(x => x.Email).Description("User's Email");
            Field(x => x.Password).Description("User's Password");
        }
    }
}
