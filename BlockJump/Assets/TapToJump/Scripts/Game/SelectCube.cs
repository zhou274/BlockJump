using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCube : MonoBehaviour
{

    [HideInInspector]
    public string nowCube;
    public GameObject selectCube, buyCube, mainCube;

    void Start ()
    {
        if (PlayerPrefs.GetString ("Cube 1") != "Open")
            PlayerPrefs.SetString ("Cube 1", "Open");
        

    }

    void OnTriggerEnter (Collider other)
    {
        nowCube = other.gameObject.name;
        other.transform.localScale = new Vector3 (1.5f, 1.5f, 1.5f);
        GetComponent <AudioSource> ().Play ();
        if (PlayerPrefs.GetString(other.gameObject.name) == "Open")
        {
            selectCube.SetActive (true);
            buyCube.SetActive (false);
        }
        else
        {
            selectCube.SetActive (false);
            buyCube.SetActive (true);
        }
    }

    void OnTriggerExit (Collider other)
    {
        other.transform.localScale -= new  Vector3 (0.4f, 0.4f, 0.4f);
    }


}
