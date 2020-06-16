using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Role
{
    public string nameRole;
    public string hold;
    public string improve;
    public int ressourceSocial;
    public int ressourcePolitical;
    public int ressourceEconomical;

    public string ressource1;
    public string ressource2;


    public Role(string _nameRole, string _hold, string _improve, int _ressourceSocial, int _ressourcePolitical, int _ressourceEconomical)
    {
        nameRole = _nameRole;
        hold = _hold;
        improve = _improve;
        ressourceSocial = _ressourceSocial;
        ressourcePolitical = _ressourcePolitical;
        ressourceEconomical = _ressourceEconomical;
        DetermineRessource();
    }

    void DetermineRessource()
    {
        if (ressourceEconomical == 0)
        {
            ressource1 = "Political";
            ressource2 = "Social";
        }
        else if (ressourcePolitical == 0)
        {
            ressource1 = "Economical";
            ressource2 = "Social";
        }
        else
        {
            ressource1 = "Economical";
            ressource2 = "Political";
        }
    }

}
