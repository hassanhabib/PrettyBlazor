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

        [Fact]
        public void ShouldRenderMatchComponentIfEvaluationIsTrue()
        {
            // given
            var expectedMatchFragment = CreateRenderFragment(typeof(SomeMatchComponent));
            var notMatchFragment = CreateRenderFragment(typeof(SomeNoMatchComponent));

            var componentParameters = new ComponentParameter[]
            {
                ComponentParameter.CreateParameter(
                    name: nameof(Condition.Evaluation),
                    value: true),

                ComponentParameter.CreateParameter(
                    name: nameof(Condition.Match),
                    value: expectedMatchFragment),

                ComponentParameter.CreateParameter(
                    name: nameof(Condition.NotMatch),
                    value: notMatchFragment)
            };

            // when
            this.renderedConditionComponent =
                RenderComponent<Condition>(componentParameters);

            // then
            this.renderedConditionComponent.Instance.Evaluation
                .Should().BeTrue();

            this.renderedConditionComponent.Instance.Match
                .Should().BeEquivalentTo(expectedMatchFragment);

            this.renderedConditionComponent.Instance.NotMatch
                .Should().BeEquivalentTo(notMatchFragment);

            this.renderedConditionComponent.FindComponent<SomeMatchComponent>().Instance
                .Should().NotBeNull();

            Assert.Throws<ComponentNotFoundException>(() =>
                this.renderedConditionComponent.FindComponent<SomeNoMatchComponent>());
        }

        [Fact]
        public void ShouldRenderNoMatchComponentIfEvaluationIsFalse()
        {
            // given
            var expectedNoMatchFragment = CreateRenderFragment(typeof(SomeNoMatchComponent));
            var matchFragment = CreateRenderFragment(typeof(SomeMatchComponent));

            var componentParameters = new ComponentParameter[] {
                ComponentParameter.CreateParameter(
                    name: nameof(Condition.Evaluation),
                    value: false),

                ComponentParameter.CreateParameter(
                    name: nameof(Condition.Match),
                    value: matchFragment),

                ComponentParameter.CreateParameter(
                    name: nameof(Condition.NotMatch),
                    value: expectedNoMatchFragment)
            };

            // when
            this.renderedConditionComponent =
                RenderComponent<Condition>(componentParameters);

            // then
            this.renderedConditionComponent.Instance.Evaluation
                .Should().BeFalse();

            this.renderedConditionComponent.Instance.Match
                .Should().BeEquivalentTo(matchFragment);

            this.renderedConditionComponent.Instance.NotMatch
                .Should().BeEquivalentTo(expectedNoMatchFragment);

            this.renderedConditionComponent.FindComponent<SomeNoMatchComponent>().Instance
                .Should().NotBeNull();

            Assert.Throws<ComponentNotFoundException>(() =>
                this.renderedConditionComponent.FindComponent<SomeMatchComponent>());
        }
    }
}
