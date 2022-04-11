// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Bunit;
using Microsoft.AspNetCore.Components;
using Tynamix.ObjectFiller;

namespace PrettyBlazor.Tests.Iterations
{
    public partial class IterationTests : TestContext
    {
        private IRenderedComponent<Iterations<int>> renderedIterationsComponent;

        private static List<int> CreateRandomItems() =>
            Enumerable.Range(start: 0, count: GetRandomNumber()).ToList();

        private static int GetRandomNumber() => new IntRange(min: 2, max: 10).GetValue();

        private static RenderFragment<int> CreateRenderFragment(Type type) =>
        context => builder =>
        {
            builder.OpenComponent(0, type);
            builder.CloseComponent();
        };

        public class SomeIterationComponent<T> : ComponentBase { }
    }
}
