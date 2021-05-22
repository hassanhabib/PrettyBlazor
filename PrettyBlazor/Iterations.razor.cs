// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
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
