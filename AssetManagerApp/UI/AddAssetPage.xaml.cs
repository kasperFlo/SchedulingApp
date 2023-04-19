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

        Manager.AddAsset(new Asset("Microwave","Bought in china", "panasonic", 3300, (new DateOnly(2022,12, 21)) , Category.electronics));
        Manager.AddAsset(new Asset("Sofa", "Bought in sweeden", "IKEA", 3300, (new DateOnly(2020, 2, 27)), Category.furniture));
        Manager.AddAsset(new Asset("Subaru Forester", "Bought in Japan", "Subaru", 3300, (new DateOnly(2018, 4, 3)), Category.vehicles));


        //BindingContext = this;
    }

    void AddAssetButtonClicked(System.Object sender, System.EventArgs e)
    {
        

        try
        {
            string Name = NameEntry.Text.ToString();
            string Manufacturer = ManufacturerEntry.Text.ToString();
            string Details = DetailsEntry.Text.ToString();
            DateOnly Purchase = DateOnly.FromDateTime(PurchaseDatePicker.Date);
            float price = float.Parse(PriceEntry.Text);
            Enum.TryParse("Active", out Category category);
            if (price <= 0)
                throw new ArgumentException("AssetPrice must be greater then 0");

            //DisplayAlert("k", $"{Name}, {Details}, {Manufacturer}, {price}, {Purchase}, {category}", "k");

            Asset tempAsset = new Asset(Name, Details, Manufacturer, price, Purchase, category);
            Manager.AddAsset(tempAsset);
        }
        catch (Exception)
        {
            DisplayAlert("invalid input error", "check your inputs", "OK");
        }

    }

    private async void ViewAssetsClicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new ViewAssetsPage(Manager));
    }
}
