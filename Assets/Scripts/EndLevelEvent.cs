using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelEvent : MonoBehaviour
{

    public GameObject glassCup; // target
    public Vector3 targetPosition;
    [HideInInspector]
    public bool startDroping;


    //public PlatformScript platformScript;
    //public GameObject mainPlayer;
    //public Vector3 targetEndLevel;
    //public Vector3 cameraFinalTarget;
    //public GameObject cameraObj;
    //public int i;
    //public float fo;

    //public Text enemieText;
    //public Image enemieFlag;


    // Start is called before the first frame update
    void Start()
    {
        startDroping = false;
        //i = 0;
        //fo = 600f;
        //platformScript = FindObjectOfType<PlatformScript>().GetComponent<PlatformScript>();
    }

    public void OnTriggerEnter(Collider coll)
    {
        if(coll.transform.tag == "PLAYER" && !startDroping)
        {
            Time.timeScale = 1f;
            startDroping = true;
            MoveTheCup();

            //Debug.Log("LevelDone");
            //mainPlayer = coll.gameObject;
            //platformScript.canPlay = false;
            //platformScript.ResetPlatform();
            //platformScript.ResetPlatformZ();


            //Invoke("SendThePlayer", 0.5f);
            //MoveTheCamera();
            //AdjustEnemieUI();

        }
    }

    private void MoveTheCup()
    {
        if(glassCup.transform.position.z > targetPosition.z)
        {
            glassCup.transform.position = Vector3.MoveTowards(glassCup.transform.position, targetPosition, 0.1f);
            Invoke("MoveTheCup", 0.02f);
        }

    }

    //public void SendThePlayer()
    //{
    //    mainPlayer.GetComponent<Rigidbody>().isKinematic = true;
    //    i++;
        

    //    if (i < 30)
    //    {
    //        mainPlayer.transform.position = Vector3.MoveTowards(mainPlayer.transform.position,
    //        new Vector3(targetEndLevel.x, mainPlayer.transform.position.y, targetEndLevel.z),
    //        0.8f * Time.fixedDeltaTime);
    //        Invoke("SendThePlayer", 0.02f);
    //    }
    //    else if(!mainPlayer.GetComponent<BallBehaviour>().readyToExplod)
    //    {
    //        Invoke("SendThePlayer", 0.02f);
    //        mainPlayer.GetComponent<Rigidbody>().isKinematic = false;
    //        mainPlayer.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, fo), ForceMode.Acceleration);
    //        fo += 10f;

    //    }        
    //}

    //public void MoveTheCamera()
    //{
    //    cameraObj.transform.position = Vector3.MoveTowards(cameraObj.transform.position,
    //        cameraFinalTarget,
    //        5f * Time.fixedDeltaTime);

    //    if(cameraObj.transform.position.z < cameraFinalTarget.z)
    //    {
    //        Invoke("MoveTheCamera", 0.02f);
    //    }

    //}

    //public void AdjustEnemieUI()
    //{
    //    if (enemieText.fontSize > 94)
    //    {
    //        enemieText.fontSize--;
            
    //    }
    //    if (enemieFlag.rectTransform.sizeDelta.x > 170)
    //    {
    //        enemieFlag.rectTransform.sizeDelta = new Vector2(enemieFlag.rectTransform.sizeDelta.x - 2,
    //            enemieFlag.rectTransform.sizeDelta.y -2);

            
    //    }
    //    if (enemieFlag.rectTransform.anchoredPosition3D.x > -180)
    //    {
    //        enemieFlag.rectTransform.anchoredPosition3D = new Vector3(enemieFlag.rectTransform.anchoredPosition3D.x - 2,
    //            enemieFlag.rectTransform.anchoredPosition3D.y,
    //            enemieFlag.rectTransform.anchoredPosition3D.z);

            
    //    }
    //    if(enemieText.fontSize > 94 || enemieFlag.rectTransform.sizeDelta.x > 170 || enemieFlag.rectTransform.anchoredPosition3D.x > -180)
    //    {
    //        Invoke("AdjustEnemieUI", 0.1f);
    //    }

    //}
}
