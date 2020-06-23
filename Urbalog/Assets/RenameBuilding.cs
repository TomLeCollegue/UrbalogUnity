using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RenameBuilding : MonoBehaviour
{

    public TextMeshProUGUI BuldingName;
    public int test;

    // Start is called before the first frame update
    void Start()
    {
        test = 0;
        BuldingName.text = "Poste" + test;
    }

    // Update is called once per frame
    void Update()
    {
        test += 1;
        BuldingName.text = "Poste" + test;
    }
}
