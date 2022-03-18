using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Users.Requests;

// This Demonstrates a pattern when you want to "Format a Response" Before sending
public class CreateUserPayload
{
    public CreateUserPayload(User user)
    {
        User = user;
    }

    public User User { get; }
}