using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetControl : NetworkBehaviour
{
    public int numBuildingBet;


    public void ChangeNumBuildingBet(int num)
    {
        numBuildingBet = num;
    }




    public void VerifBet(int value, string Ressource)
    {
        Game game = GameManager.singleton.game;
        bool isOk = true;
        
        if (value == -1)
        {
            if (Ressource.Equals("Political"))
            {
                if(game.Market[numBuildingBet].FinancePolitical < 1)
                {
                    isOk = false;
                }   
            }
            else if (Ressource.Equals("Economical"))
            {
                if (game.Market[numBuildingBet].FinanceEconomical < 1)
                {
                    isOk = false;
                }
            }
            else
            {
                if (game.Market[numBuildingBet].FinanceSocial < 1)
                {
                    isOk = false;
                }
            }

        }
        if (value == 1)
        {
            if (Ressource.Equals("Political"))
            {
                if(GetComponent<Player>().role.ressourcePolitical < 1){
                    isOk = false;
                }
                if (game.Market[numBuildingBet].FinancePolitical >= game.Market[numBuildingBet].Political)
                {
                    isOk = false;
                }
            }
            else if (Ressource.Equals("Economical"))
            {
                if (GetComponent<Player>().role.ressourceEconomical < 1){
                    isOk = false;
                }
                if (game.Market[numBuildingBet].FinanceEconomical >= game.Market[numBuildingBet].Economical)
                {
                    isOk = false;
                }
            }
            else
            {
                if (GetComponent<Player>().role.ressourceSocial < 1){
                    isOk = false;
                }
                if (game.Market[numBuildingBet].FinanceSocial >= game.Market[numBuildingBet].Social)
                {
                    isOk = false;
                }
            }
        }
        if (isOk)
        {
            CmdBet(value, Ressource, numBuildingBet);
            ChangeRessourcePlayer(value, Ressource);
        }
    }


    private void ChangeRessourcePlayer(int value, string Ressource)
    {
        if (Ressource.Equals("Economical"))
        {
            GetComponent<Player>().role.ressourceEconomical -= value;
        }
        else if (Ressource.Equals("Political"))
        {
            GetComponent<Player>().role.ressourcePolitical -= value;
        }
        else
        {
            GetComponent<Player>().role.ressourceSocial -= value;
        }
    }

    [Command]
    public void CmdBet(int value, string Ressource, int num)
    {
        RpcBet(value, Ressource, num);
    }

    [ClientRpc]
    public void RpcBet(int value, string Ressource, int numBuildingBet)
    {
        Game game = GameManager.singleton.game;
        if (Ressource.Equals("Political"))
        {
            game.Market[numBuildingBet].FinancePolitical += value;
        }
        else if (Ressource.Equals("Economical"))
        {
            game.Market[numBuildingBet].FinanceEconomical += value;
        }
        else
        {
            game.Market[numBuildingBet].FinanceSocial += value;
        }
    }


}
