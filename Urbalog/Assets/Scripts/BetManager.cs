using Mirror;
using UnityEngine;

public class BetManager : NetworkBehaviour
{
    public static BetManager instanceRef;

    private void Awake()
    {
        if (instanceRef == null)
        {
            instanceRef = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instanceRef != this)
            Destroy(gameObject);
    }

    [SerializeField]
    private int numBuilding;
    
    public void ChangenumBuilding(int _num)
    {
        numBuilding = _num;
        Debug.Log("test");
    }

}
