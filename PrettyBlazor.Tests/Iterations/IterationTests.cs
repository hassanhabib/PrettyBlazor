// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Bunit;
using Microsoft.AspNetCore.Components;

namespace PrettyBlazor.Tests.Iterations
{
    public partial class IterationTests : TestContext
    {
        private IRenderedComponent<Iterations<object>> renderedIterationsComponent;

        private static RenderFragment CreateRenderFragment(Type type) => builder =>
        {
            builder.OpenComponent(sequence: 0, componentType: type);
            builder.CloseComponent();
        };

        public class SomeMatchComponent : ComponentBase { }
    }
}
