using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TTSDK.UNBridgeLib.LitJson;
using TTSDK;
using StarkSDKSpace;


public class CubeJump : MonoBehaviour
{

    public static bool jump, nextBlock;
    public GameObject mainCube, buttons1, lose_buttons;
    private bool animate, lose, addLose;
    /*public bool lose;*/
    private float scratch_speed = 0.5f, startTime, yPosCube;
    public static int count_blocks;
    public Buttons script;
    public int advCount;
    private bool isVibration = false;
    public string clickid;
    private StarkAdManager starkAdManager;
    void Awake ()
    {
        Debug.Log(gameObject.name);
        jump = false;
        nextBlock = false;
    }
    void Start()
    {
        jump = false;
        StartCoroutine(CanJump()); 
        /*script = gameObject.GetComponent<Buttons>();
        advCount = script.advCount;*/
    }

    void FixedUpdate()
    {
        //if(isVibration == true) Handheld.Vibrate();
        if (animate && mainCube.transform.localScale.y > 0.4f)
            PressCube(-scratch_speed);
        else if (!animate &&  mainCube != null)
        {
            if (mainCube.transform.localScale.y < 1f)
                PressCube(scratch_speed * 3f);
            else if (mainCube.transform.localScale.y != 1f)
                mainCube.transform.localScale = new Vector3(1f, 1f, 1f);

        }

        if(mainCube != null) 
        {
            if (mainCube.transform.position.y < -6f)
            {
                //Destroy(mainCube, 0.5f);
                print("Player Lose");
                lose = true;
            }

        }

        if (lose && !addLose)
            PlayerLose ();
    }

    void PlayerLose ()
    {
        addLose = true;
        buttons1.GetComponent <ScrollObjects> ().speed = 5f;
        buttons1.GetComponent <ScrollObjects> ().checkPos = 50;
        if(!lose_buttons.activeSelf)
            lose_buttons.SetActive (true);
        lose_buttons.GetComponent <ScrollObjects> ().checkPos = 130;
        lose_buttons.GetComponent <AudioSource> ().Play ();
        //mainCube.GetComponent<Rigidbody>().isKinematic = true;
        //advCount++;
        //Handheld.Vibrate();
        ShowInterstitialAd("1lcaf5895d5l1293dc",
            () => {
                Debug.LogError("--插屏广告完成--");

            },
            (it, str) => {
                Debug.LogError("Error->" + str);
            });
        Debug.Log("Vibration");
    }
    public void Respawn()
    {
        ShowVideoAd("192if3b93qo6991ed0",
            (bol) => {
                if (bol)
                {

                    addLose = false;
                    lose = false;
                    lose_buttons.SetActive(false);
                    mainCube.transform.position = mainCube.GetComponent<CollectCoins>().CurrentCube.transform.position;
                    mainCube.transform.position = new Vector3(mainCube.GetComponent<CollectCoins>().CurrentCube.transform.position.x, mainCube.GetComponent<CollectCoins>().CurrentCube.transform.position.y + 0.2f, mainCube.GetComponent<CollectCoins>().CurrentCube.transform.position.z);
                    mainCube.transform.localRotation = Quaternion.identity;
                    Debug.Log(mainCube.transform.position);


                    clickid = "";
                    getClickid();
                    apiSend("game_addiction", clickid);
                    apiSend("lt_roi", clickid);


                }
                else
                {
                    StarkSDKSpace.AndroidUIManager.ShowToast("观看完整视频才能获取奖励哦！");
                }
            },
            (it, str) => {
                Debug.LogError("Error->" + str);
                //AndroidUIManager.ShowToast("广告加载异常，请重新看广告！");
            });
        
        //mainCube.GetComponent<Rigidbody>().isKinematic = false;
    }
    void OnMouseDown()
    {
        if (nextBlock && mainCube.GetComponent<Rigidbody>())
        {
            animate = true;
            startTime = Time.time;

            yPosCube = mainCube.transform.localPosition.y;
        }
    }

    void OnMouseUp()
    {
        if (nextBlock && mainCube.GetComponent<Rigidbody>())
        {
            animate = false;


            // Jump
            jump = true;
            float force, diff;
            diff = Time.time - startTime;
            if (diff < 3f)
                force = 190 * diff;
            else
                force = 300f;
            if (force < 60f)
                force = 60f;

            mainCube.GetComponent<Rigidbody>().AddForce(mainCube.transform.up * force);
            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.right * -force);
            

            StartCoroutine(checkCubePos());
            nextBlock = false;
        }
    }

    void PressCube (float force)
    {
        mainCube.transform.localPosition += new Vector3(0f, force * Time.deltaTime, 0f);
        mainCube.transform.localScale += new Vector3(0f, force * Time.deltaTime, 0f);

    }

    IEnumerator checkCubePos ()
    {
        yield return new WaitForSeconds(0.5f);
        if (yPosCube == mainCube.transform.position.y)
        {
            print("Player Lose");
            lose = true;
        }

        else
        {
            while (!mainCube.GetComponent<Rigidbody>().IsSleeping())
            {
                yield return new WaitForSeconds(0.05f);
                if (mainCube == null) 
                    break;
                
                
            }

            if (!lose)
            {
                nextBlock = true;
                count_blocks++;
                print("Next one");
                mainCube.transform.localPosition = new Vector3(-0.3f, mainCube.transform.localPosition.y, mainCube.transform.localPosition.z);
                mainCube.transform.eulerAngles = new Vector3(0f, mainCube.transform.eulerAngles.y, 0f);
            }
        }
    }

    IEnumerator CanJump ()
    {
        while (!mainCube.GetComponent<Rigidbody>())
            yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(0.1f);
        nextBlock = true;
    }
    public void getClickid()
    {
        var launchOpt = StarkSDK.API.GetLaunchOptionsSync();
        if (launchOpt.Query != null)
        {
            foreach (KeyValuePair<string, string> kv in launchOpt.Query)
                if (kv.Value != null)
                {
                    Debug.Log(kv.Key + "<-参数-> " + kv.Value);
                    if (kv.Key.ToString() == "clickid")
                    {
                        clickid = kv.Value.ToString();
                    }
                }
                else
                {
                    Debug.Log(kv.Key + "<-参数-> " + "null ");
                }
        }
    }
    /// <summary>
    /// 播放插屏广告
    /// </summary>
    /// <param name="adId"></param>
    /// <param name="errorCallBack"></param>
    /// <param name="closeCallBack"></param>
    public void ShowInterstitialAd(string adId, System.Action closeCallBack, System.Action<int, string> errorCallBack)
    {
        starkAdManager = StarkSDK.API.GetStarkAdManager();
        if (starkAdManager != null)
        {
            var mInterstitialAd = starkAdManager.CreateInterstitialAd(adId, errorCallBack, closeCallBack);
            mInterstitialAd.Load();
            mInterstitialAd.Show();
        }
    }
    public void apiSend(string eventname, string clickid)
    {
        TTRequest.InnerOptions options = new TTRequest.InnerOptions();
        options.Header["content-type"] = "application/json";
        options.Method = "POST";

        JsonData data1 = new JsonData();

        data1["event_type"] = eventname;
        data1["context"] = new JsonData();
        data1["context"]["ad"] = new JsonData();
        data1["context"]["ad"]["callback"] = clickid;

        Debug.Log("<-data1-> " + data1.ToJson());

        options.Data = data1.ToJson();

        TT.Request("https://analytics.oceanengine.com/api/v2/conversion", options,
           response => { Debug.Log(response); },
           response => { Debug.Log(response); });
    }


    /// <summary>
    /// </summary>
    /// <param name="adId"></param>
    /// <param name="closeCallBack"></param>
    /// <param name="errorCallBack"></param>
    public void ShowVideoAd(string adId, System.Action<bool> closeCallBack, System.Action<int, string> errorCallBack)
    {
        starkAdManager = StarkSDK.API.GetStarkAdManager();
        if (starkAdManager != null)
        {
            starkAdManager.ShowVideoAdWithId(adId, closeCallBack, errorCallBack);
        }
    }
}
