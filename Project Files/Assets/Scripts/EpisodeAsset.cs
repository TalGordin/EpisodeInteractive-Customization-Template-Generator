using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpisodeAsset
{
    public readonly uint r_ID;
    public readonly string r_ScriptName;
    public string m_DisplayName;
    public readonly List<string> r_SupportedGenders;
    public readonly ICategory r_Category; //Will be a SubCategory if exists, MainCategory otherwise
    public readonly bool r_CanDelete;

    public EpisodeAsset(uint i_ID, string i_ScriptName, string i_DisplayName, List<string> i_SupportedGenders, 
        SubCategory i_SubCategory, bool i_CanDelete)
    {
        r_ID = i_ID;
        r_ScriptName = i_ScriptName;
        m_DisplayName = i_DisplayName;
        r_SupportedGenders = i_SupportedGenders;
        r_Category = i_SubCategory;
        r_CanDelete = i_CanDelete;
    }
}
