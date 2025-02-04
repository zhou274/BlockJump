using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubes : MonoBehaviour
{

    public bool moved = true;
    private Vector3 target;

    void Start()
    {
        target = new Vector3(-3.48f, 6.97f, 0.33f);
    }


    void Update() // Every frame
    {
        if (CubeJump.nextBlock)
        {
            if (transform.position != target)
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 5f);
            else if (transform.position == target && !moved)
            {
                target = new Vector3(transform.position.x - 3.07f, transform.position.y + 4.18f, transform.position.z);
                CubeJump.jump = false;
                moved = true;
            }
        

            if (CubeJump.jump)
                moved = false;

        }
    }
}
