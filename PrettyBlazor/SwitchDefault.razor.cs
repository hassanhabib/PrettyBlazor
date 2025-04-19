// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under The Standard Software License (TSSL v1.0).
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Components;

namespace PrettyBlazor
{
    public partial class SwitchDefault<TValue> : ComponentBase
    {
        [CascadingParameter]
        public Switch<TValue> Switch { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private bool ShouldRenderDefaultCase() =>
            this.Switch is not null && this.Switch.HasMatchedCase is false;
    }
}
