using UnityEngine;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.IO;

public class DataManager : MonoBehaviour
{
    public readonly string AssetsConnectionString;
    public readonly string TemplatesConnectionString;
    public List<MainCategory> MainCategories;
    public List<SubCategory> SubCategories;
    private EpisodeAssetsList m_DefaultAssetsFemale, m_DefaultAssetsMale;

    void Start()
    {
        EpisodeAssetsList m_DefaultAssetsFemale = new EpisodeAssetsList("female");

        bool createAssetsDatabase = File.Exists(AssetsConnectionString) ? false : true;
        using (SQLiteConnection assetsConnection = new SQLiteConnection(AssetsConnectionString))
        {
            assetsConnection.Open();

            if(createAssetsDatabase)
            {
                Debug.LogWarning("Assets database was not found. Creating new database & initializing data.");

                MainCategories = GetMainCategories();
                SubCategories = GetSubCategories();
                //GenerateAssetsTables(assetsConnection); -TODO
            }
            else
            {

            }

        }
    }


    private List<MainCategory> GetMainCategories()
    {
        List<MainCategory> MainCategories = new List<MainCategory>();

        MainCategories.Add(new MainCategory("body", "body types"));
        MainCategories.Add(new MainCategory("bodyColor", "skin tones"));
        MainCategories.Add(new MainCategory("hair", "hairstyles"));
        MainCategories.Add(new MainCategory("hairColor", "hair colors"));
        MainCategories.Add(new MainCategory("face", "face shapes"));
        MainCategories.Add(new MainCategory("nose", "nose shapes"));
        MainCategories.Add(new MainCategory("eyes", "eye shapes"));
        MainCategories.Add(new MainCategory("eyesColor", "eye colors"));
        MainCategories.Add(new MainCategory("eyebrows", "eyebrow shapes"));
        MainCategories.Add(new MainCategory("eyebrowsColor", "eyebrow colors"));
        MainCategories.Add(new MainCategory("mouth", "lip shapes"));
        MainCategories.Add(new MainCategory("mouthColor", "lip colors"));

        return MainCategories;
    }

    private List<SubCategory> GetSubCategories()
    {
        List<SubCategory> SubCategories = new List<SubCategory>();
        Dictionary<string, MainCategory> mainCategories = MainCategories.ToDictionary(mainCat => mainCat.IdentifierName);

        TextAsset jsonFile = Resources.Load<TextAsset>("subcategories");
        if (jsonFile == null)
            throw new NullReferenceException();

        JObject json = JObject.Parse(jsonFile.text);
        foreach (var subcatProperty in json.Properties())
        {
            string identifierName = subcatProperty.Name;
            string displayName = subcatProperty.Value["displayName"].ToString();
            string mainCategoryName = subcatProperty.Name.Substring(0, subcatProperty.Name.IndexOf('_'));

            SubCategory currentSubcat = new SubCategory(identifierName, displayName, mainCategories[mainCategoryName]);
            SubCategories.Add(currentSubcat);

            Debug.Log($"Created subcategory {identifierName} with display name {displayName} belonging to main category {mainCategoryName}");
        }

        return SubCategories;
    }
}
