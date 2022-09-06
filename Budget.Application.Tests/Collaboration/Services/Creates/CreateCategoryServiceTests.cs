﻿using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateCategoryServiceTests
    {
        [Fact]
        public void ShouldCreateProjection()
        {
            var service = new CreateCategoryService();
            var @event = new CategoryRequested();
            @event.Publish();
            var projection = Category.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
