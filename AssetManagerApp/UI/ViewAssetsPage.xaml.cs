namespace AssetManagerApp.UI;
using BusinessLogic;

public partial class ViewAssetsPage : ContentPage
{
    public AssetManager Manager { get; set; }

    public ViewAssetsPage(AssetManager manager)
	{
		InitializeComponent();
        Manager = manager;
        AssetsListView.ItemsSource = manager.Assets;
        //BindingContext = manager.Assets;
    }

    void AssetListViewSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
        Asset selectedAsset = (Asset)AssetsListView.SelectedItem;

        SelectedAssetImage.Source = selectedAsset.CategoryIconFile;
        AssetNameLabel.Text = selectedAsset.AssetName;
        ManufacturerLabel.Text = selectedAsset.Manufacturer;
        PurchaseDateLabel.Text = selectedAsset.PurchaseDate.ToString();
        PriceLabel.Text = $"{selectedAsset.Price.ToString()}";
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
    }

    async void BackButtonClicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}