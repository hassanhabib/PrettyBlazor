// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using FluentAssertions;
using Xunit;

namespace PrettyBlazor.Tests.Switchs
{
    public partial class SwitchTests
    {
        [Fact]
        public void ShouldHaveDefaultInitParametersForSwitch()
        {
            // when
            var component = new Switch<string>();

            // then
            component.Value.Should().BeNull();
            component.ChildContent.Should().BeNull();
        }
    }
}
