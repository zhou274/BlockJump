using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    private Text txt;
    private Outline oline;

    void Start()
    {
        //txt = GetComponent<Text>();
        oline = GetComponent<Outline>();
    }

    void FixedUpdate()
    {
        //txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, Mathf.PingPong(Time.time, 1.0f));
    }
}
