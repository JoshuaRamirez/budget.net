using Budget.Application.Events.Core;
using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Services.Creates
{
    public class CreateUserService : Receiver<UserRequestedEvent>
    {
        public CreateUserService()
        {
            UserRequestedEvent.Subscribe(this);
        }
        public override void Serve(UserRequestedEvent @event)
        {
            // Create UserProjection
            var userProjection = new UserProjection();
            userProjection.UserName = @event.UserName;
            UserProjection.Projections.Add(userProjection);
            // Publish UserCreatedEvent
            var userCreatedEvent = new UserCreatedEvent();
            userCreatedEvent.UserId = userProjection.Id;
            UserCreatedEvent.Publish(userCreatedEvent);
        }
    }
}
