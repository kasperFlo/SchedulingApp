using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AssetManagerApp.BusinessLogic
{
    /// <summary>
    /// Represents an asset like and electronic device, a vehicle etc.
    /// </summary>
    public class Asset : IComparable<Asset>
    {
        string _assetName;
        string _details;
        string _manufacturer;
        float _price;
        DateOnly _purchaseDate;

        //public string Details { get => _details; set => _details = value ; }

        //Add a field and corresponding readonly property for Category.
        Category _category = new Category();
        public Category Category { get => _category; }

        //Add Read-Write properties for Name validation: required, blanks not allowed
        public string AssetName
        {
            get => _assetName;
            set => _assetName = value.Trim() != "" ? value.Trim() : throw new ArgumentException("AssetName must not be blank");
        }

        //Create read-only properties for manufacturer.
        public string Manufacturer { get => _manufacturer; }

        //Add Read-Write properties for Price validation: should be greater than zero
        public float Price
        {
            get => _price; set => _price = value > 0 ? value : throw new ArgumentException("AssetName must be greater then 0");
        }
        //Create read-only properties for purchase date.
        public DateOnly PurchaseDate { get => _purchaseDate; }

        //Create a computed property that evaluates to the name of the category icon file representing the Category e.g., electronics.png)
        string _categoryIconFile;
        public string CategoryIconFile
        {
            get => _categoryIconFile; set => _categoryIconFile = $"{Category}.png";
        }

        //Create a parameterized constructor to initialize all fields ensuring the validations implemented in the property setters above are enforced.
        public Asset(string assetName , string details , string manufacturer , float price , DateOnly purchaseDate,Category category)
        {
            AssetName = assetName;
            _details = details;
            _manufacturer = manufacturer;
            Price = price;
            _purchaseDate = purchaseDate;
            _category = category;
        }

        //Implement IComparable, so that order of Assets is decided based on the Name of the Asset.

        public int CompareTo(Asset obj)
        {
            return this.AssetName.CompareTo(obj.AssetName);
        }

    }
}
