using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCategory : ICategory
{
    public readonly string IdentifierName;
    public readonly string DisplayName;

    public MainCategory(string i_IdentifierName, string i_DisplayName)
    {
        DisplayName = i_DisplayName;
        IdentifierName = i_IdentifierName;
    }
}
