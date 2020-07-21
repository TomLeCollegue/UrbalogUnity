using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillListPlayer : MonoBehaviour
{
    public GameObject PlayerItem;
    public Transform listHolder;
    public List<GameObject> PlayerItemInList = new List<GameObject>();


    private void Start()
    {
        InvokeRepeating("UpdateList", 0, 1f);
    }

    public void UpdateList()
    {
        DestroyList();

        for (int i = 0; i < GameManager.singleton.players.Count; i++)
        {
            if (i >= 2)
            {
                SpawnPlayerItem(GameManager.singleton.players[i]);
            }
        }

    }
    public void SpawnPlayerItem(Player _player)
    {
        GameObject Item = Instantiate(PlayerItem, listHolder);
        Item.GetComponent<NamePlayerInList>().Rename(_player.namePlayer);
        
        PlayerItemInList.Add(Item);
    }

    void DestroyList()
    {
        for (int i = 0; i < PlayerItemInList.Count; i++)
        {
            Destroy(PlayerItemInList[i]);
        }
        PlayerItemInList.Clear();
    }
}
