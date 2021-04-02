using System;
using System.Collections.Generic;
using Bunit;
using Bunit.Rendering;
using FluentAssertions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Xunit;

namespace PrettyBlazor.Tests
{
    public class ConditionTests : TestContext
    {
        private IRenderedComponent<Condition> renderedConditionComponent;

        [Fact]
        public void ShouldHaveDefaultInitParameters()
        {
            // given
            bool expectedInitialEvaluation = default;

            // when
            var initialConditionComponent = new Condition();

            // then
            initialConditionComponent.Evaluation
                .Should().Be(expectedInitialEvaluation);

            initialConditionComponent.Match.Should().BeNull();
            initialConditionComponent.NotMatch.Should().BeNull();
        }


        RenderFragment CreateRenderFragment(Type type) => builder =>
        {
            builder.OpenComponent(0, type);
            builder.AddAttribute(1, "Title", "Some title");
            builder.CloseComponent();
        };

        [Fact]
        public void ShouldRenderMatchComponentIfEvaluationIsTrue()
        {
            // given
            var expectedMatchFragment = CreateRenderFragment(typeof(InputText));
            var expectedNoMatchFragment = CreateRenderFragment(typeof(InputNumber<int>));

            var componentParameters = new List<ComponentParameter> {
                ComponentParameter.CreateParameter(nameof(Condition.Evaluation), true),
                ComponentParameter.CreateParameter(nameof(Condition.Match), expectedMatchFragment),
                ComponentParameter.CreateParameter(nameof(Condition.NotMatch), expectedNoMatchFragment)
            };

            // when
            this.renderedConditionComponent = 
                RenderComponent<Condition>(componentParameters.ToArray());

            // then
            this.renderedConditionComponent.Instance.Evaluation
                .Should().BeTrue();

            this.renderedConditionComponent.Instance.Match
                .Should().BeEquivalentTo(expectedMatchFragment);

            this.renderedConditionComponent.Instance.NotMatch
                .Should().BeEquivalentTo(expectedNoMatchFragment);

            this.renderedConditionComponent.FindComponent<InputText>()
                .Should().BeEquivalentTo(expectedMatchFragment);

            this.renderedConditionComponent.FindComponent<InputNumber<int>>()
                .Should().BeNull();
        }

        public class SomeComponent: ComponentBase { }
    }
}
