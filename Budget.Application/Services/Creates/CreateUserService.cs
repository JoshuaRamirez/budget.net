using Budget.Application.Events.Core;
using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Services.Creates
{
    public class CreateUserService : Receiver<UserRequested>
    {
        public CreateUserService()
        {
            UserRequested.Subscribe(this);
        }
        public override void Serve(UserRequested @event)
        {
            // Create UserProjection
            var userProjection = new User();
            userProjection.UserName = @event.UserName;
            User.Projections.Add(userProjection);
            // Publish UserCreatedEvent
            var userCreatedEvent = new UserCreated();
            userCreatedEvent.UserId = userProjection.Id;
            UserCreated.Publish(userCreatedEvent);
        }
    }
}
