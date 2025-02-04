using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public GameObject detectClicks, allCubes;
    public GameObject monetiz;

    void OnEnable()
    {
        detectClicks.SetActive (false);
        allCubes.SetActive (true);
        monetiz.SetActive (true);
    }

    void OnDisable ()
    {
        detectClicks.SetActive (true);
        allCubes.SetActive (false);
        monetiz.SetActive (false);
    }

}
