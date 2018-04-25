namespace ControlLibrary.View
{
    public partial class MainControl
    {
        private void InitialControlHandlers()
        {
            //Adds other UserControl to the tabbed page
            this.tabPage1.Controls.Add(new ListControl());
            this.tabPage2.Controls.Add(new GraphControl());
        }
    }
}
