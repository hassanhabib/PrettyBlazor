// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Bunit;
using Bunit.Rendering;
using FluentAssertions;
using Xunit;

namespace PrettyBlazor.Tests.Conditions
{
    public partial class ConditionTests : TestContext
    {
        [Fact]
        public void ShouldHaveDefaultInitParameters()
        {
            // given . when
            var initialConditionComponent = new Condition();

            // then
            initialConditionComponent.Evaluation.Should().BeFalse();
            initialConditionComponent.Match.Should().BeNull();
            initialConditionComponent.NotMatch.Should().BeNull();
        }
    }
}
