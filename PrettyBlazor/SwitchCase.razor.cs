// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
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
                Switch?.NotifyMatched();
            }
        }

        private bool ShouldRenderCase()
        {
            return EqualityComparer<TValue>.Default.Equals(
                x: Value,
                y: When);
        }
    }
}
