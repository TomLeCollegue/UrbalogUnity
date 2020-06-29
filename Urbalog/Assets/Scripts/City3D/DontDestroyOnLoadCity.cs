using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadCity : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
