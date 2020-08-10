using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CameraRotator1;
    public GameObject CameraRotatorZoom;

    public GameObject City;
    public GameObject DezoomButton;

    public void Zoom()
    {
        CameraRotator1.SetActive(false);
        CameraRotatorZoom.SetActive(true);
        DezoomButton.SetActive(true);
        City.SetActive(false);
    }

    public void Dezoom()
    {
        CameraRotator1.SetActive(true);
        CameraRotatorZoom.SetActive(false);
        DezoomButton.SetActive(false);

        City.SetActive(true);
    }



}
