 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{

    public int collectedBall;
    public float ballToCollect;
    public Image progressImg;
    public Text progressText;

    public LostBallControll lostBallControl;
    public BallsGenerator ballGenerator;
    public PlatformScript platformScript;

    // Lose and win UI
    public Image winImage;
    public Image loseImage;


    // Start is called before the first frame update
    void Start()
    {
        collectedBall = 0;
        progressText.text = "0";
        progressImg.fillAmount = 0f;
        winImage.gameObject.SetActive(false);
        loseImage.gameObject.SetActive(false);
        Invoke("CheckLevelStatu", 3f);
        
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "PLAYER")
        {
            Debug.Log("collect ONE");
            collectedBall++;
            //progressImg.fillAmount += (1 / ballToCollect);
            float a;
            a = progressImg.fillAmount;
            a += 1f / ballToCollect;
            progressImg.fillAmount = a;
            progressText.text = collectedBall.ToString();
            //col.gameObject.transform.localScale = new Vector3(0.58f, 0.58f, 0.58f);
            
        }
    }

    public void CheckLevelStatu()
    {

        if(collectedBall >= (int)ballToCollect)
        {
            // You win
            Debug.Log("win");
            winImage.gameObject.SetActive(true);
            platformScript.canPlay = false;
        }

        if((lostBallControl.lostBallCount + collectedBall) == ballGenerator.totalBalls && collectedBall < (int)ballToCollect)
        {
            //you lose
            loseImage.gameObject.SetActive(true);
            platformScript.canPlay = false;
            Debug.Log("lose");
            //Debug.Log(lostBallControl.lostBallCount + collectedBall);
            //Debug.Log(ballGenerator.totalBalls);
        }

        Invoke("CheckLevelStatu", 1.5f);
    }

    //private void ProgressBarGrow()
    //{
    //    if(progressImg.fillAmount < ())
    //    progressImg.fillAmount += 0.05f;
    //    Invoke("ProgressBarGrow", 0.02f);
    //}

    //private void ProgressTextGrow()
    //{
    //    Invoke("ProgressTextGrow", 0.02f);
    //}

}
