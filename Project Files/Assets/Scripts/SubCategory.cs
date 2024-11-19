using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCategory : ICategory
{
    public readonly string IdentifierName;
    public readonly string DisplayName;
    public readonly MainCategory MainCat;

    public SubCategory(string i_IdentifierName, string i_DisplayName, MainCategory i_MainCategory)
    {
        IdentifierName = i_IdentifierName;
        DisplayName = i_DisplayName;
        MainCat = i_MainCategory;
    }
}