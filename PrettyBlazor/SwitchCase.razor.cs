// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace PrettyBlazor
{
    public partial class SwitchCase<T> : ComponentBase
    {
        [CascadingParameter(Name = "SwitchValue")]
        public T SwitchValue { get; set; }

        [Parameter]
        public T When { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private bool ShouldRenderCase() =>
            EqualityComparer<T>.Default.Equals(SwitchValue, When);
    }
}
