// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Bunit;
using FluentAssertions;
using Microsoft.AspNetCore.Components;
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

        [Fact]
        public void ShouldRenderOnlyMatchingSwitchCase()
        {
            // given
            int randomMatchValue = GetRandomNumber();
            int randomNotMatchValue = GetRandomNumber();

            while (randomMatchValue == randomNotMatchValue)
            {
                randomNotMatchValue = GetRandomNumber();
            }

            int inputMatchValue = randomMatchValue;
            int inputNotMatchValue = randomNotMatchValue;
            string inputNotMatchContent = "This should not be rendered";
            string expectedMatchContent = "Test View: int";
            string unexpectedNotMatchContent = inputNotMatchContent;

            RenderFragment<int> matchingFragment = val => builder =>
            {
                builder.OpenComponent(0, typeof(SomeSwitchViewComponent<int>));
                builder.CloseComponent();
            };

            RenderFragment<int> nonMatchingFragment = val => builder =>
            {
                builder.OpenElement(0, "p");
                builder.AddContent(1, inputNotMatchContent);
                builder.CloseElement();
            };

            var parameters = new ComponentParameter[]
            {
                ComponentParameter.CreateParameter(
                    name: nameof(Switch<int>.Value),
                    value: inputMatchValue),

                ComponentParameter.CreateParameter(
                    name: nameof(Switch<string>.ChildContent),
                    value:new RenderFragment(builder =>
                {
                    builder.OpenComponent<SwitchCase<int>>(0);

                    builder.AddAttribute(
                        sequence: 1,
                        name: nameof(SwitchCase<int>.When),
                        value: inputNotMatchValue);

                    builder.AddAttribute(
                        sequence: 2,
                        name: nameof(SwitchCase<int>.ChildContent),
                        value: nonMatchingFragment);

                    builder.CloseComponent();
                    builder.OpenComponent<SwitchCase<int>>(3);

                    builder.AddAttribute(
                        sequence: 4,
                        name: nameof(SwitchCase<int>.When),
                        value: inputMatchValue);

                    builder.AddAttribute(
                        sequence: 5,
                        name: nameof(SwitchCase<int>.ChildContent),
                        value: matchingFragment);

                    builder.CloseComponent();
                }))
            };

            // when
            var rendered = RenderComponent<Switch<int>>(parameters);

            // then
            rendered.Markup.Should().Contain(expectedMatchContent);
            rendered.Markup.Should().NotContain(unexpectedNotMatchContent);
        }
    }
}
