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
                builder.OpenElement(
                    sequence: 0,
                    elementName: "p");

                builder.AddContent(
                    sequence: 1,
                    textContent: inputMatchContent);

                builder.CloseElement();
            };

            RenderFragment nonMatchingFragment = builder =>
            {
                builder.OpenElement(
                    sequence: 0,
                    elementName: "p");

                builder.AddContent(
                    sequence: 1,
                    textContent: inputNotMatchContent);

                builder.CloseElement();
            };

            var parameters = new ComponentParameter[]
            {
                ComponentParameter.CreateParameter(
                    name: nameof(Switch<int>.Value),
                    value: inputMatchValue),

                ComponentParameter.CreateParameter(
                    name: nameof(Switch<int>.ChildContent),
                    value: new RenderFragment(builder =>
                {
                    builder.OpenComponent<SwitchCase<int>>(sequence: 0);

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
            IRenderedComponent<Switch<int>> renderedComponent =
                RenderComponent<Switch<int>>(parameters);

            // then
            renderedComponent.Markup.Should().Contain(expectedMatchContent);
            renderedComponent.Markup.Should().NotContain(unexpectedNotMatchContent);
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
                builder.OpenElement(
                    sequence: 0,
                    elementName: "p");

                builder.AddContent(
                    sequence: 1,
                    textContent: inputDefaultContent);

                builder.CloseElement();
            };

            RenderFragment nonMatchingCaseFragment = builder =>
            {
                builder.OpenElement(
                    sequence: 0,
                    elementName: "p");

                builder.AddContent(
                    sequence: 1,
                    textContent: inputCaseContent);

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
                        builder.OpenComponent<SwitchCase<int>>(sequence: 0);

                        builder.AddAttribute(
                            sequence: 1,
                            name: nameof(SwitchCase<int>.When),
                            value: inputCaseValue);

                        builder.AddAttribute(
                            sequence: 2,
                            name: nameof(SwitchCase<int>.ChildContent),
                            value: nonMatchingCaseFragment);

                        builder.CloseComponent();

                        builder.OpenComponent<SwitchDefault<int>>(sequence: 3);

                        builder.AddAttribute(
                            sequence: 4,
                            name: nameof(SwitchDefault<int>.ChildContent),
                            value: defaultFragment);

                        builder.CloseComponent();
                    }))
            };

            // when
            IRenderedComponent<Switch<int>> renderedComponent =
                RenderComponent<Switch<int>>(parameters);

            // then
            renderedComponent.Markup.Should().Contain(expectedDefaultContent);
            renderedComponent.Markup.Should().NotContain(unexpectedCaseContent);
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
                builder.OpenElement(
                    sequence: 0,
                    elementName: "p");

                builder.AddContent(
                    sequence: 1,
                    textContent: inputCaseContent);

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
                        builder.OpenComponent<SwitchCase<int>>(sequence: 0);

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
            IRenderedComponent<Switch<int>> renderedComponent =
                RenderComponent<Switch<int>>(parameters);

            // then
            renderedComponent.Markup.Trim().Should().BeEmpty();
            renderedComponent.Markup.Should().NotContain(unexpectedCaseContent);
        }
    }
}
