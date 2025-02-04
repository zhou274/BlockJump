using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBlocks : MonoBehaviour
{
    public CubeJump script;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube")
            Destroy(other.gameObject);
            Debug.Log("Destroy Block");
    
       /* if (other.tag == "Player")
        { 
            Destroy(other.gameObject);
            Debug.Log("Destroy MainCube");
            script.GetComponent<CubeJump>().lose = true;
        }*/
    }
}