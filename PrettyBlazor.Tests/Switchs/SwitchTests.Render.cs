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
            string inputMatchContent = "This should be rendered";
            string inputNotMatchContent = "This should not be rendered";
            string expectedMatchContent = inputMatchContent;
            string unexpectedNotMatchContent = inputNotMatchContent;

            RenderFragment matchingFragment = builder =>
            {
                builder.OpenElement(0, "p");
                builder.AddContent(1, inputMatchContent);
                builder.CloseElement();
            };

            RenderFragment nonMatchingFragment = builder =>
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
                    name: nameof(Switch<int>.ChildContent),
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

        [Fact]
        public void ShouldRenderDefaultWhenNoCaseMatches()
        {
            // given
            int randomSwitchValue = GetRandomNumber();
            int randomCaseValue = GetRandomNumber();

            while (randomSwitchValue == randomCaseValue)
            {
                randomCaseValue = GetRandomNumber();
            }

            int inputSwitchValue = randomSwitchValue;
            int inputCaseValue = randomCaseValue;
            string inputDefaultContent = "This is the default content";
            string inputCaseContent = "This should not be rendered";
            string expectedDefaultContent = inputDefaultContent;
            string unexpectedCaseContent = inputCaseContent;

            RenderFragment defaultFragment = builder =>
            {
                builder.OpenElement(0, "p");
                builder.AddContent(1, inputDefaultContent);
                builder.CloseElement();
            };

            RenderFragment nonMatchingCaseFragment = builder =>
            {
                builder.OpenElement(0, "p");
                builder.AddContent(1, inputCaseContent);
                builder.CloseElement();
            };

            var parameters = new ComponentParameter[]
            {
                ComponentParameter.CreateParameter(
                    name: nameof(Switch<int>.Value),
                    value: inputSwitchValue),

                ComponentParameter.CreateParameter(
                    name: nameof(Switch<int>.ChildContent),
                    value: new RenderFragment(builder =>
                    {
                        builder.OpenComponent<SwitchCase<int>>(0);

                        builder.AddAttribute(
                            sequence: 1,
                            name: nameof(SwitchCase<int>.When),
                            value: inputCaseValue);

                        builder.AddAttribute(
                            sequence: 2,
                            name: nameof(SwitchCase<int>.ChildContent),
                            value: nonMatchingCaseFragment);

                        builder.CloseComponent();

                        builder.OpenComponent<SwitchDefault<int>>(3);

                        builder.AddAttribute(
                            sequence: 4,
                            name: nameof(SwitchDefault<int>.ChildContent),
                            value: defaultFragment);

                        builder.CloseComponent();
                    }))
            };

            // when
            var rendered = RenderComponent<Switch<int>>(parameters);

            // then
            rendered.Markup.Should().Contain(expectedDefaultContent);
            rendered.Markup.Should().NotContain(unexpectedCaseContent);
        }

        [Fact]
        public void ShouldRenderNothingWhenNoMatchAndNoDefault()
        {
            // given
            int randomSwitchValue = GetRandomNumber();
            int randomCaseValue = GetRandomNumber();

            while (randomSwitchValue == randomCaseValue)
            {
                randomCaseValue = GetRandomNumber();
            }

            int inputSwitchValue = randomSwitchValue;
            int inputCaseValue = randomCaseValue;
            string inputCaseContent = "This should not be rendered";
            string unexpectedCaseContent = inputCaseContent;

            RenderFragment nonMatchingCaseFragment = builder =>
            {
                builder.OpenElement(0, "p");
                builder.AddContent(1, inputCaseContent);
                builder.CloseElement();
            };

            var parameters = new ComponentParameter[]
            {
                ComponentParameter.CreateParameter(
                    name: nameof(Switch<int>.Value),
                    value: inputSwitchValue),

                ComponentParameter.CreateParameter(
                    name: nameof(Switch<int>.ChildContent),
                    value: new RenderFragment(builder =>
                    {
                        builder.OpenComponent<SwitchCase<int>>(0);

                        builder.AddAttribute(
                            sequence: 1,
                            name: nameof(SwitchCase<int>.When),
                            value: inputCaseValue);

                        builder.AddAttribute(
                            sequence: 2,
                            name: nameof(SwitchCase<int>.ChildContent),
                            value: nonMatchingCaseFragment);

                        builder.CloseComponent();
                    }))
            };

            // when
            var rendered = RenderComponent<Switch<int>>(parameters);

            // then
            rendered.Markup.Trim().Should().BeEmpty();
            rendered.Markup.Should().NotContain(unexpectedCaseContent);
        }
    }
}
