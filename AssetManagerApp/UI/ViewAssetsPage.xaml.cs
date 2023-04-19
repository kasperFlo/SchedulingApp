namespace AssetManagerApp.UI;
using BusinessLogic;

public partial class ViewAssetsPage : ContentPage
{
    public AssetManager Manager { get; set; }

    public ViewAssetsPage(AssetManager manager)
	{
		InitializeComponent();
        Manager = manager;

    }
}