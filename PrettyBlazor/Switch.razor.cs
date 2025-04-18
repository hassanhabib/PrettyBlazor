// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Components;

namespace PrettyBlazor
{
    public partial class Switch<TValue> : ComponentBase
    {
        [Parameter]
        public TValue Value { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
