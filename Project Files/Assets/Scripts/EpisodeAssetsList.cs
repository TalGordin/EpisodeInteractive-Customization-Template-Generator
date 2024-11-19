using System;
using System.Collections.Generic;
using UnityEngine;

public class EpisodeAssetsList
{
    private readonly string r_Gender;
    private readonly List<EpisodeAsset> r_Assets;

    public EpisodeAssetsList(string Gender)
    {
        if (Gender == "female" || Gender == "male")
            r_Gender = Gender;
        else
            throw new InvalidOperationException("Invalid gender assigned!");

        r_Assets = new List<EpisodeAsset>();
    }

    public bool Init()
    {
        Debug.Log("Beginning default assets database Init");



        return true;
    }
}
