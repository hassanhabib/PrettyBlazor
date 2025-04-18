// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Tynamix.ObjectFiller;

namespace PrettyBlazor.Tests.Switchs
{
    public partial class SwitchTests : TestContext
    {
        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 9).GetValue();

        public class SomeSwitchViewComponent<T> : ComponentBase
        {
            protected override void BuildRenderTree(RenderTreeBuilder builder)
            {
                builder.OpenElement(
                    sequence: 0,
                    elementName: "p");

                builder.AddContent(
                    sequence: 1,
                    textContent: $"Switch View: {typeof(T).Name}");

                builder.CloseElement();
            }
        }
    }
}
