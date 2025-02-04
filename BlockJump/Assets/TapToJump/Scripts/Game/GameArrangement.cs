using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class GameArrangement : MonoBehaviour
{
    public GameObject[] cubes;
    public GameObject buttons, m_cube;
    public GameObject spawn_blocks, currency;
    public Light dirLight, dirLight2;
    public Animation cubes_anim, block;
    public TextMeshProUGUI Gametext;
    public TextMeshProUGUI study;
    public TextMeshProUGUI   record;
    public TextMeshProUGUI playtext;

    private bool clicked;

     void Update()
    {
            if (clicked)
            Destroy(dirLight);
    }

    void OnMouseDown ()
    {   
        if (!clicked)
        {
            StartCoroutine(delCubes ());
            clicked = true; // Works only ones
            playtext.gameObject.SetActive(false);
            study.gameObject.SetActive (true);
            record.gameObject.SetActive (true);
            currency.SetActive (true);
            Gametext.text = "0";
            buttons.GetComponent<ScrollObjects>().speed = -10f;
            buttons.GetComponent<ScrollObjects>().checkPos = -200f;
            m_cube.GetComponent<Animation>().Play ("StarGameCube");
            StartCoroutine(cubeToBlock());
            m_cube.transform.localScale = new Vector3(1f, 1f, 1f);
            cubes_anim.Play();
        }
        else if (clicked && study.gameObject.activeSelf)
            study.gameObject.SetActive (false);

    }

    IEnumerator delCubes ()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            (cubes[i]).GetComponent <FallCube> ().enabled = true;
        }

        spawn_blocks.GetComponent<SpawnBlocks> ().enabled = true;

    }

    IEnumerator cubeToBlock ()
    {
        yield return new WaitForSeconds(m_cube.GetComponent<Animation>().clip.length + 0.5f);
        block.Play();

        //Add Rigidbody component
        m_cube.AddComponent <Rigidbody> ();

    }

}