// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Components;

namespace PrettyBlazor
{
    public partial class FixedIterations : ComponentBase
    {
        [Parameter]
        public int Count { get; set; }

        [Parameter]
        public RenderFragment<int> ChildContent { get; set; }
    }
}
