using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AssetManagerApp.BusinessLogic
{
    /// <summary>
    /// Represents an asset like and electronic device, a vehicle etc.
    /// </summary>
    public class Asset
    {
        string _assetName;
        string _details;
        string _manufacturer;
        float _price;
        DateOnly _purchaseDate;

        //Add a field and corresponding readonly property for Category.

        //Add Read-Write properties for Name validation: required, blanks not allowed

        //Create read-only properties for manufacturer.

        //Add Read-Write properties for Price validation: should be greater than zero

        //Create read-only properties for purchase date.


        //Create a computed property that evaluates to the name of the category icon file representing the Category e.g., electronics.png)


        //Create a parameterized constructor to initialize all fields ensuring the validations implemented in the property setters above are enforced.


        //Implement IComparable, so that order of Assets is decided based on the Name of the Asset.

    }
}
