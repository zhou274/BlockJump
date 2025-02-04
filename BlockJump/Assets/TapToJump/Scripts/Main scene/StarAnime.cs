using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarAnime : MonoBehaviour
{
    private SpriteRenderer star;
    private float _movementSpeed = 0.3f;

    void Start()
    {
        star = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 10f);
    }

    void FixedUpdate()
    {
        star.color = new Color (star.color.r, star.color.g, star.color.b, Mathf.PingPong (Time.time / 2.5f, 1.0f));

        // Move star
        transform.position += transform.up * Time.deltaTime * _movementSpeed;
    }



}
