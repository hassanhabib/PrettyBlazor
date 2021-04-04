// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Bunit;
using FluentAssertions;
using Xunit;

namespace PrettyBlazor.Tests.Iterations
{
    public partial class IterationTests : TestContext
    {
        [Fact]
        public void ShouldHaveDefaultInitParameters()
        {
            // given . when
            var initialConditionComponent = new Iterations<object>();

            // then
            initialConditionComponent.Items.Should().BeNull();
            initialConditionComponent.Iteration.Should().BeNull();
        }
    }
}
