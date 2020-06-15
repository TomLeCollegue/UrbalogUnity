using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Role role;

    [SerializeField]
    public string namePlayer { get; set; }
    public string ID { get; set; }

    [SerializeField]
    private int num;

    public void ChangeNum()
    {
        GameManager.singleton.ChangeValueNum();
        num++;
    }
}
