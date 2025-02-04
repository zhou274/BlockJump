using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Advertisements;

public class Buttons : MonoBehaviour{

	public GameObject shopBG;
	public Sprite mus_on, mus_off;
	public bool Opened = false;

	public static int advCount = 0;

	public GameObject FAQ, Music;

	void Start ()
	{
		if (gameObject.name == "Settings")
		{
			if (PlayerPrefs.GetString ("Music") == "off")
			{
				transform.GetChild (0).gameObject.GetComponent <Image> ().sprite = mus_off;
				Camera.main.GetComponent <AudioListener> ().enabled = false; //Switch off music 
			}
		}
	}

	void OnMouseDown () 
	{
		transform.localScale = new Vector3 (0.9f, 0.9f, 1f);
	}

	void OnMouseUp () 
	{
		transform.localScale = new Vector3 (0.80f, 0.80f, 1f);
	}


	void OnMouseUpAsButton  ()
	{
		switch (gameObject.name)
		{
		case "Music":
		if(PlayerPrefs.GetString ("Music") == "on") //Play music now
		{
			GetComponent <Image> ().sprite = mus_on;
			PlayerPrefs.SetString ("Music", "on");
			//Camera.main.GetComponent <AudioListener> ().enabled = true; //Switch on music 
		}
		else //Off music
		{
			GetComponent <Image> ().sprite = mus_off;
			PlayerPrefs.SetString ("Music", "off");
			//Camera.main.GetComponent <AudioListener> ().enabled = false; //Switch off music 
		}
			break;
		case "Shop":
			shopBG.SetActive (!shopBG.activeSelf);
			break;
		case "Close":
			shopBG.SetActive (false);
			break;
		case "Restart":
			SceneManager.LoadScene(0);
			advCount++;
			//if (Advertisement.IsReady () && advCount % 5 == 0)
			//{
			//	Advertisement.Show("Interstitial_Android");
			//}
			break;
		}
	}	
	public void Click ()
	{

		Opened = !Opened;
		if (Opened == true)
		{
			Debug.Log("Open");
			FAQ.SetActive(true);
			Music.SetActive(true);
		}
		else
		{
			Debug.Log ("Close");
			FAQ.SetActive(false);
			Music.SetActive(false);
		}
		
	}

	/*public void Restart()
	{
		SceneManager.LoadScene(0);
		advCount++;
		if (Advertisement.IsReady () && advCount % 5 == 0)
			{
				Advertisement.Show("Interstitial_Android");
			}
	}*/
	
}