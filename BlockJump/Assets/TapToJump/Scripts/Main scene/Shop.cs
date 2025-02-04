using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBG : MonoBehaviour
{

    private bool activeLose, activePlaytext;
    public GameObject detectClicks, allCubes, playtext, loseBtns, currency, monetiz;

    void OnEnable()
    {
        if (playtext.activeSelf)
        {
            activePlaytext = true;
            playtext.SetActive (false);
        }
        detectClicks.GetComponent <BoxCollider> ().enabled = false;
        allCubes.SetActive (true);
        currency.SetActive (true);
        monetiz.SetActive (true);
        if (loseBtns.activeSelf)
        {
            activeLose = true;
            loseBtns.SetActive (false);
        }
    }

    void OnDisable ()
    {
        if (activeLose)
            loseBtns.SetActive (true);
        if (activePlaytext)
            playtext.SetActive (true);
        detectClicks.GetComponent <BoxCollider> ().enabled = true;
        allCubes.SetActive (false);
        currency.SetActive (false);
        monetiz.SetActive (false);
    }

}
