// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Components;

namespace PrettyBlazor
{
    public partial class Loading : ComponentBase
    {
        [Parameter]
        public object Evaluation { get; set; }
        
        [Parameter]
        public RenderFragment Pending { get; set; }

        [Parameter]
        public RenderFragment Ready { get; set; }

        [Parameter]
        public RenderFragment Empty { get; set; }
    }
}
