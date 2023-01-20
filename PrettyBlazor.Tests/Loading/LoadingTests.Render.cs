// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Bunit;
using Bunit.Rendering;
using FluentAssertions;
using System;
using Xunit;

namespace PrettyBlazor.Tests.Iterations
{
    public partial class LoadingTests : TestContext
    {
        [Fact]
        public void ShouldHaveDefaultInitParameters()
        {
            // given . when
            var initialConditionComponent = new Loading();

            // then
            initialConditionComponent.Evaluation.Should().BeNull();
            initialConditionComponent.Ready.Should().BeNull();
            initialConditionComponent.Pending.Should().BeNull();
            initialConditionComponent.Empty.Should().BeNull();
        }

        [Fact]
        public void ShouldRenderPendingComponentIfEvaluationIsNull()
        {
            // given
            var expectedPendingFragment = CreateRenderFragment(typeof(PendingComponent));
            var emptyFragment = CreateRenderFragment(typeof(EmptyComponent));
            var readyFragment = CreateRenderFragment(typeof(ReadyComponent));

            var componentParameters = new ComponentParameter[]
            {
                ComponentParameter.CreateParameter(
                    name: nameof(Loading.Evaluation),
                    value: null),

                ComponentParameter.CreateParameter(
                    name: nameof(Loading.Pending),
                    value: expectedPendingFragment),

                ComponentParameter.CreateParameter(
                    name: nameof(Loading.Empty),
                    value: emptyFragment),

                ComponentParameter.CreateParameter(
                    name: nameof(Loading.Ready),
                    value: readyFragment)
            };

            // when
            this.renderedConditionComponent =
                RenderComponent<Loading>(componentParameters);

            // then
            this.renderedConditionComponent.Instance.Evaluation
                .Should().BeNull();

            this.renderedConditionComponent.Instance.Empty
                .Should().BeEquivalentTo(emptyFragment);

            this.renderedConditionComponent.Instance.Ready
                .Should().BeEquivalentTo(readyFragment);

            this.renderedConditionComponent.Instance.Pending
                .Should().BeEquivalentTo(expectedPendingFragment);

            this.renderedConditionComponent.FindComponent<PendingComponent>().Instance
                .Should().NotBeNull();

            Assert.Throws<ComponentNotFoundException>(() =>
                this.renderedConditionComponent.FindComponent<EmptyComponent>());

            Assert.Throws<ComponentNotFoundException>(() =>
                this.renderedConditionComponent.FindComponent<ReadyComponent>());
        }

        [Fact]
        public void ShouldRenderReadyComponentIfEvaluationIsNotNull()
        {
            // given
            var expectedReadyFragment = CreateRenderFragment(typeof(ReadyComponent));
            var emptyFragment = CreateRenderFragment(typeof(EmptyComponent));
            var pendingFragment = CreateRenderFragment(typeof(PendingComponent));

            var componentParameters = new ComponentParameter[]
            {
                ComponentParameter.CreateParameter(
                    name: nameof(Loading.Evaluation),
                    value: new { }),

                ComponentParameter.CreateParameter(
                    name: nameof(Loading.Ready),
                    value: expectedReadyFragment),

                ComponentParameter.CreateParameter(
                    name: nameof(Loading.Pending),
                    value: pendingFragment),

                ComponentParameter.CreateParameter(
                    name: nameof(Loading.Empty),
                    value: emptyFragment)
            };

            // when
            this.renderedConditionComponent =
                RenderComponent<Loading>(componentParameters);

            // then
            this.renderedConditionComponent.Instance.Evaluation
                .Should().NotBeNull();

            this.renderedConditionComponent.Instance.Empty
                .Should().BeEquivalentTo(emptyFragment);

            this.renderedConditionComponent.Instance.Pending
                .Should().BeEquivalentTo(pendingFragment);

            this.renderedConditionComponent.Instance.Ready
                .Should().BeEquivalentTo(expectedReadyFragment);

            this.renderedConditionComponent.FindComponent<ReadyComponent>().Instance
                .Should().NotBeNull();

            Assert.Throws<ComponentNotFoundException>(() =>
                this.renderedConditionComponent.FindComponent<PendingComponent>());

            Assert.Throws<ComponentNotFoundException>(() =>
                this.renderedConditionComponent.FindComponent<EmptyComponent>());
        }

        [Fact]
        public void ShouldRenderEmptyComponentIfEvaluationIsEmptyCollection()
        {
            // given
            var expectedEmptyFragment = CreateRenderFragment(typeof(EmptyComponent));
            var readyFragment = CreateRenderFragment(typeof(ReadyComponent));
            var pendingFragment = CreateRenderFragment(typeof(PendingComponent));

            var componentParameters = new ComponentParameter[]
            {
                ComponentParameter.CreateParameter(
                    name: nameof(Loading.Evaluation),
                    value: Array.Empty<object>()),

                ComponentParameter.CreateParameter(
                    name: nameof(Loading.Empty),
                    value: expectedEmptyFragment),

                ComponentParameter.CreateParameter(
                    name: nameof(Loading.Ready),
                    value: readyFragment),

                ComponentParameter.CreateParameter(
                    name: nameof(Loading.Pending),
                    value: pendingFragment)
            };

            // when
            this.renderedConditionComponent =
                RenderComponent<Loading>(componentParameters);

            // then
            this.renderedConditionComponent.Instance.Evaluation
                .Should().NotBeNull();

            this.renderedConditionComponent.Instance.Ready
                .Should().BeEquivalentTo(readyFragment);

            this.renderedConditionComponent.Instance.Pending
                .Should().BeEquivalentTo(pendingFragment);

            this.renderedConditionComponent.Instance.Empty
                .Should().BeEquivalentTo(expectedEmptyFragment);

            this.renderedConditionComponent.FindComponent<EmptyComponent>().Instance
                .Should().NotBeNull();

            Assert.Throws<ComponentNotFoundException>(() =>
                this.renderedConditionComponent.FindComponent<PendingComponent>());

            Assert.Throws<ComponentNotFoundException>(() =>
                this.renderedConditionComponent.FindComponent<ReadyComponent>());
        }
    }
}