// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under The Standard Software License (TSSL v1.0).
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Bunit;
using Microsoft.AspNetCore.Components;

namespace PrettyBlazor.Tests.Conditions
{
    public partial class ConditionTests : TestContext
    {
        private IRenderedComponent<Condition> renderedConditionComponent;

        private static RenderFragment CreateRenderFragment(Type type) => builder =>
        {
            builder.OpenComponent(sequence: 0, componentType: type);
            builder.CloseComponent();
        };

        public class SomeMatchComponent : ComponentBase { }
        public class SomeNoMatchComponent : ComponentBase { }
    }
}
