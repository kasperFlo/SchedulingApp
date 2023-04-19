using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AssetManagerApp.BusinessLogic
{
    /// <summary>
    /// Manages a collections of Assets
    /// </summary>
    public class AssetManager
    {
        List<Asset> _assets= new List<Asset>();

        //Define read only property Assets that returns the list of assets sorted on asset name.

        public void AddAsset(Asset asset)
        {
            _assets.Add(asset);
        }

        
        //Define a method ComputeAssetValue that returns the total price of all the assets
        //with a specific category, e.g. all Electronics products.
        //The category should be passed as a parameter to the method.



    }
}
