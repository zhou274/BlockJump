using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Url : MonoBehaviour
{
    public string URL;

    public void Browser()
    {
        Application.OpenURL(URL);
        Debug.Log("Open URL");
    }
}
