namespace AssetManagerApp.UI;
using BusinessLogic;

public partial class AddAssetPage : ContentPage
{
    
    public AssetManager Manager { get; set; }

	public AddAssetPage()
	{

    InitializeComponent();

		AssetManager manager = new AssetManager();

        Manager = manager;
        List<Category> _CatPicker = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();
        List<string> CatPicker = new List<string>();

        foreach (Category category in _CatPicker)
            CatPicker.Add(category.ToString());

        CategoryPicker.ItemsSource = CatPicker;
        //DisplayAlert("j", $"{CatPicker[0]} {CatPicker[1]} {CatPicker[2]}", "j");

        Manager.AddAsset(new Asset("Microwave","Bought in china", "panasonic", 3300, (new DateOnly(2022,12, 21)) , Category.Electronics));
        Manager.AddAsset(new Asset("Sofa", "Bought in sweeden", "IKEA", 3300, (new DateOnly(2020, 2, 27)), Category.Furniture));
        Manager.AddAsset(new Asset("Subaru Forester", "Bought in Japan", "Subaru", 3300, (new DateOnly(2018, 4, 3)), Category.Vehicle));


        //BindingContext = this;
    }

    void AddAssetButtonClicked(System.Object sender, System.EventArgs e)
    {
        string Name = NameEntry.Text.ToString();
        string Manufacturer = ManufacturerEntry.Text.ToString();
        string Details = DetailsEntry.Text.ToString();
        float.TryParse(PriceEntry.Text, out float price);
        DateOnly Purchase = DateOnly.FromDateTime(PurchaseDatePicker.Date);
        Enum.TryParse("Active", out Category category);
        

        DisplayAlert("k", $"{Name}, {Details}, {Manufacturer}, {price}, {Purchase}, {category}", "k");

        Asset tempAsset = new Asset(Name, Details, Manufacturer, price, Purchase, category);
        Manager.AddAsset(tempAsset);
    }

    private async void ViewAssetsClicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new ViewAssetsPage(Manager));
    }
}
