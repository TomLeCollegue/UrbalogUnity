using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role
{
    private string nameRole;
    private string hold;
    private string improve;
    private int ressourceSocial;
    private int ressourcePolitical;
    private int ressourceEconomical;


    public Role(string _nameRole, string _hold, string _improve, int _ressourceSocial, int _ressourcePolitical, int _ressourceEconomical)
    {
        nameRole = _nameRole;
        hold = _hold;
        improve = _improve;
        ressourceSocial = _ressourceSocial;
        ressourcePolitical = _ressourcePolitical;
        ressourceEconomical = _ressourceEconomical;
    }

}
