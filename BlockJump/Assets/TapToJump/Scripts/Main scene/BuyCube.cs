using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCube : MonoBehaviour
{

    public GameObject whichCube, selectBtn, mainCube;
    public Text coin, coinShop;

    void OnMouseDown ()
    {
        GetComponentInParent <AudioSource> ().Play ();
        if (PlayerPrefs.GetInt ("Coin") >= 20)
        {
            PlayerPrefs.SetString (whichCube.GetComponent <SelectCube> ().nowCube, "Open");
            PlayerPrefs.SetString ("Now Cube", whichCube.GetComponent <SelectCube> ().nowCube);
            PlayerPrefs.SetInt ("Coin", PlayerPrefs.GetInt ("Coin") - 20);
            coin.text = PlayerPrefs.GetInt ("Coin").ToString ();
            coinShop.text = PlayerPrefs.GetInt ("Coin").ToString ();
            mainCube.GetComponent <MeshRenderer> ().material = GameObject.Find (whichCube.GetComponent <SelectCube> ().nowCube).GetComponent <MeshRenderer> ().material;
            selectBtn.SetActive (true);
            gameObject.SetActive (false);
        }

    }

}
