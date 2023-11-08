using Budget.Application.Events.Core;
using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Projections.Core;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Services.Creates
{
    public class CreateUserService : Receiver<UserRequested>
    {
        public static CreateUserService Instance { get; } = new CreateUserService();
        public override void Serve(UserRequested @event)
        {
            // Create UserProjection
            var projection = new User();
            projection.UserName = @event.UserName;
            projection.Save();
            // Publish UserCreatedEvent
            var userCreatedEvent = new UserCreated();
            userCreatedEvent.UserId = projection.Id;
            UserCreated.Publish(userCreatedEvent);
        }
    }
}
