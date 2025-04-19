// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under The Standard Software License (TSSL).
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Components;

namespace PrettyBlazor
{
    public partial class Condition : ComponentBase
    {
        [Parameter]
        public bool Evaluation { get; set; }

        [Parameter]
        public RenderFragment Match { get; set; }

        [Parameter]
        public RenderFragment NotMatch { get; set; }
    }
}
