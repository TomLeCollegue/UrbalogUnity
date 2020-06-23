using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private Transform cam;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Transform>();
    }
}
