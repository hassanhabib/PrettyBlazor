// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
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
            Switch is not null && Switch.HasMatchedCase is false;
    }
}
