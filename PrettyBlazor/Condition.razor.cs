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
