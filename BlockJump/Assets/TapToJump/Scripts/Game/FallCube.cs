using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCube : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    void FixedUpdate()
    {
        transform.position += new Vector3 (0, 0.1f, 0);
    }
}
