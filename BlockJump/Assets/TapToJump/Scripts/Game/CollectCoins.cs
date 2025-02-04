using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoins : MonoBehaviour
{

    public AudioClip collectCoin;
    public Text coin;
    public Transform ParentObject;
    public GameObject CurrentCube;
    
    
    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Coin")
        {
            Destroy (other.gameObject);
            PlayerPrefs.SetInt ("Coin", PlayerPrefs.GetInt ("Coin") + 2);
            coin.text = PlayerPrefs.GetInt ("Coin").ToString ();
            GetComponent <AudioSource> ().clip = collectCoin;
            GetComponent <AudioSource> ().Play ();
        }
        
    }
    public void Update()
    {
        CurrentCube = ParentObject.GetChild(2).gameObject;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
