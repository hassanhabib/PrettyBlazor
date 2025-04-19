// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under The Standard Software License (TSSL v1.0).
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace PrettyBlazor
{
    public partial class Iterations<T> : ComponentBase
    {
        [Parameter]
        public IEnumerable<T> Items { get; set; }

        [Parameter]
        public RenderFragment<T> ChildContent { get; set; }
    }
}
