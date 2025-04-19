// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under The Standard Software License (TSSL).
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace PrettyBlazor
{
    public partial class SwitchCase<TValue> : ComponentBase
    {
        [CascadingParameter]
        public TValue Value { get; set; }

        [CascadingParameter]
        public Switch<TValue> Switch { get; set; }

        [Parameter]
        public TValue When { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected override void OnParametersSet()
        {
            if (ShouldRenderCase())
            {
                this.Switch?.NotifyMatched();
            }
        }

        private bool ShouldRenderCase()
        {
            return EqualityComparer<TValue>.Default.Equals(
                x: this.Value,
                y: this.When);
        }
    }
}
