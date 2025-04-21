// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Bunit;
using Microsoft.AspNetCore.Components;
using System;

namespace PrettyBlazor.Tests.Iterations
{
    public partial class LoadingTests : TestContext
    {
        private IRenderedComponent<Loading> renderedConditionComponent;

        private static RenderFragment CreateRenderFragment(Type type) => builder =>
        {
            builder.OpenComponent(sequence: 0, componentType: type);
            builder.CloseComponent();
        };

        public class PendingComponent : ComponentBase
        { }

        public class ReadyComponent : ComponentBase
        { }

        public class EmptyComponent : ComponentBase
        { }
    }
}