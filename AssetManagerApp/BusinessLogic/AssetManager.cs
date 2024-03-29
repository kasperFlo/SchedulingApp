﻿using System;
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
        List<Asset> _assets = new List<Asset>();
        public AssetJsonDataManager JsonManager { get; set; }

        public AssetManager()
        {
            JsonManager = new AssetJsonDataManager(Path.Combine(FileSystem.Current.AppDataDirectory, "AssetList.json"));
            ReadData(JsonManager);
        }

        //Define read only property Assets that returns the list of assets sorted on asset name.
        public List<Asset> Assets
        {
            get
            {
                _assets.Sort();
                return _assets;
            }
        }

        public void AddAsset(Asset asset)
        {
            _assets.Add(asset);
        }


        //Define a method ComputeAssetValue that returns the total price of all the assets
        //with a specific category, e.g. all Electronics products.
        //The category should be passed as a parameter to the method.

        public float ComputeAssetValue(Category category)
        {
            float total = 0;
            foreach (Asset currerntA in _assets)
            {
                if (currerntA.Category == category)
                    total += currerntA.Price;
            }
            return total;
        }

        public void SaveData(AssetJsonDataManager dataManager)
        {
            dataManager.WriteAllUserRecords(_assets);
        }

        public void ReadData(AssetJsonDataManager dataManager)
        {
            try
            {
                _assets = dataManager.ReadAllUserRecords();
            }
            catch (Exception)
            {
                _assets = new List<Asset>();
            }
        }

    }
}
