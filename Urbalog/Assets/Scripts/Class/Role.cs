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

    public string RoleToString()
    {
        string _result = "\nnom : " + this.nameRole + "\n"
            + "hold : " + this.hold + "\n"
            + "improve : " + this.improve + "\n"
            + "social : " + this.ressourceSocial + "\n"
            + "political : " + this.ressourcePolitical + "\n"
            + "economical : " + this.ressourceEconomical + "\n";

        return _result;
    }

    public static bool RoleEquals(Role _role1, Role _role2)
    {
        Debug.Log("role 1.25 :\ncompare role \nrole1 : " + _role1.RoleToString() + "\nrole 2 : " + _role2.RoleToString());

        if (_role1.nameRole == _role2.nameRole
            && _role1.hold == _role2.hold
            && _role1.improve == _role2.improve
            && _role1.ressourceEconomical == _role2.ressourceEconomical
            && _role1.ressourcePolitical == _role2.ressourcePolitical
            && _role1.ressourceSocial == _role2.ressourceSocial)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
