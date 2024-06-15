namespace BlazorServer.Components
{
    public partial class NavBarComponent
    {
        private bool isExpanded = false;


        public void ToggleNavbar()
        {
            isExpanded = !isExpanded;
        }

        public void CloseNavBar()
        {
            if (isExpanded)
            {
                isExpanded = false;
            }
        }
    }
}
