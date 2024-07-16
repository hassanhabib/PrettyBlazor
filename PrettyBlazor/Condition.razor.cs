// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
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

        /// <summary>
        /// Only shown if <see cref="Evaluation"/> is <see cref="true"/> and <see cref="Match"/> is not set.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
