// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Bunit;
using Microsoft.AspNetCore.Components;
using Tynamix.ObjectFiller;

namespace PrettyBlazor.Tests.Fixeds
{
    public partial class FixedIterationsTests : TestContext
    {
        private IRenderedComponent<FixedIterations>
            renderedFixedIterationsComponent;

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static RenderFragment<int> CreateRenderFragment(Type type) =>
        context => builder =>
        {
            builder.OpenComponent(0, type);
            builder.CloseComponent();
        };

        public class SomeFixedIterationComponent : ComponentBase { }
    }
}
