// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under The Standard Software License (TSSL v1.0).
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Bunit;
using FluentAssertions;
using Microsoft.AspNetCore.Components;
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
            initialConditionComponent.ChildContent.Should().BeNull();
        }

        [Fact]
        public void ShouldRenderAllItermsInList()
        {
            // given
            List<int> randomItems = CreateRandomItems();
            List<int> inputItems = randomItems;

            Type expectedIterationComponentType =
                typeof(SomeIterationComponent<int>);

            RenderFragment<int> expectedIteration =
                CreateRenderFragment(expectedIterationComponentType);

            var componentParameters = new ComponentParameter[]
            {
                ComponentParameter.CreateParameter(
                    name: nameof(Iterations<int>.Items),
                    value: randomItems),

                ComponentParameter.CreateParameter(
                    name: nameof(Iterations<int>.ChildContent),
                    value: expectedIteration)
            };

            // when
            this.renderedIterationsComponent =
               RenderComponent<Iterations<int>>(componentParameters);

            // then
            this.renderedIterationsComponent.Instance.Items
                .Should().BeEquivalentTo(randomItems);

            IReadOnlyList<IRenderedComponent<SomeIterationComponent<int>>> actualIterations =
                this.renderedIterationsComponent.FindComponents<SomeIterationComponent<int>>();

            actualIterations.Count.Should().Be(randomItems.Count);

            actualIterations.ToList().ForEach(actualIteration =>
                actualIteration.Instance.Should().BeOfType(expectedIterationComponentType));
        }
    }
}
