// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Bunit;
using FluentAssertions;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace PrettyBlazor.Tests.Fixeds
{
    public partial class FixedIterationsTests
    {
        [Fact]
        public void ShouldHaveDefaultInitParameters()
        {
            // given . when
            var fixedIterationsComponent = new FixedIterations();

            // then
            fixedIterationsComponent.Count.Should().Be(0);
            fixedIterationsComponent.ChildContent.Should().BeNull();
        }

        [Fact]
        public void ShouldRenderAllIterationsByCount()
        {
            // given
            int randomCount = GetRandomNumber();
            int inputCount = randomCount;
            int expectedCount = inputCount;

            Type expectedIterationComponentType =
                typeof(SomeFixedIterationComponent);

            RenderFragment<int> inputIteration =
                CreateRenderFragment(expectedIterationComponentType);

            ComponentParameter countParameter =
                 ComponentParameter.CreateParameter(
                     name: nameof(FixedIterations.Count),
                     value: inputCount);

            ComponentParameter childContentParameter =
                ComponentParameter.CreateParameter(
                    name: nameof(FixedIterations.ChildContent),
                    value: inputIteration);

            // when
            this.renderedFixedIterationsComponent =
                RenderComponent<FixedIterations>(
                    countParameter,
                    childContentParameter);

            // then
            this.renderedFixedIterationsComponent.Instance.Count
                .Should().Be(expectedCount);

            IReadOnlyList<IRenderedComponent<SomeFixedIterationComponent>> actualIterations =
                this.renderedFixedIterationsComponent.FindComponents<SomeFixedIterationComponent>();

            actualIterations.Count.Should().Be(expectedCount);

            actualIterations.ToList().ForEach(actualIteration =>
                actualIteration.Instance.Should().BeOfType(expectedIterationComponentType));
        }
    }
}
