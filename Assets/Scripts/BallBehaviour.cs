using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallBehaviour : MonoBehaviour
{

    [HideInInspector]
    public Multiplier multiplier;
    [HideInInspector]
    public GameObject currentTarget;

    public GameObject secondPlayer;

    //public GameObject textHolder;
    private Vector3 tempTextOffset;
    private float tempTextOffsetindex;
    [HideInInspector]
    public int mainWeight;
    [HideInInspector]
    public int mainWeight2;

    public GameObject enemieExplosion;
    public GameObject playerExplosion;

    public int secondPlayerWeight; // to be adjusted in the inspector

    public GameObject playerUiHolder;
    public GameObject enemieUiHolder;

    private Vector3 currentScale;
    private Vector3 targetScale;
    private int weightMulti;
    private int WeightAddi;
    private float scaleAddi;
    [HideInInspector]
    public bool readyToExplod;

    public GameObject winParticle;
    public GameObject loseParticle;

    //public GameObject ballToGenerate;  //
    //private Vector3 ofsetForBalChild;  //

    //public int totalBalls;             //
    //public int generatedBalls;         //

    private int index1;
    // Start is called before the first frame update
    void Start()
    {
        //totalBalls = 1;
        //generatedBalls = 1;

        secondPlayer = GameObject.FindGameObjectWithTag("SECONDPLAYER");
        readyToExplod = false;
        mainWeight = 2;
        mainWeight2 = 2;

        tempTextOffsetindex = 0.11f;

        //textHolder = FindObjectOfType<BallText>().gameObject;        
        //textHolder.GetComponentInChildren<Text>().text = mainWeight + " Kg";
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "SECONDPLAYER")
        {
            readyToExplod = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            EndLevelCeremoni();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "TARGET" && !col.gameObject.GetComponent<Multiplier>().isTouched )
        {
            // this part of code should be organized later
            col.gameObject.GetComponent<Multiplier>().isTouched = true;

            //totalBalls = totalBalls * col.gameObject.GetComponent<Multiplier>().weightMultiplication;
            //totalBalls += col.gameObject.GetComponent<Multiplier>().weightAddition;
            //Invoke("GenerateBalls", 0.1f);
            FindObjectOfType<BallsGenerator>().GetComponent<BallsGenerator>().GenerateBalls(col.gameObject);
            //GenerateBalls(col.gameObject);

            index1 = 50;
            col.gameObject.GetComponent<Multiplier>().isTouched = true;
            currentTarget = col.gameObject;
            currentScale = transform.localScale;
            //scaleMulti = col.gameObject.GetComponent<Multiplier>().scaleMultiplication;
            scaleAddi = col.gameObject.GetComponent<Multiplier>().scaleAddition;
            targetScale = currentScale + new Vector3(scaleAddi * 0.1f, scaleAddi * 0.1f, scaleAddi * 0.1f);
            //scaleUpAddi();
            Invoke("DestroyTarget", 0.5f);
            //tempTextOffset = new Vector3(0f,
            //textHolder.GetComponent<BallText>().textOffset.y + tempTextOffsetindex,
            //0f);
            tempTextOffsetindex += col.gameObject.GetComponent<Multiplier>().scaleAddition * 0.1f * 0.025f;
            //Invoke("AdjustText", 0.4f);
            // update Text
            weightMulti = col.gameObject.GetComponent<Multiplier>().weightMultiplication;
            WeightAddi = col.gameObject.GetComponent<Multiplier>().weightAddition;
            //Debug.Log(col.name);

            mainWeight2 = (mainWeight + WeightAddi) * weightMulti;
            //AdjustWeightText();

        }
    }
    
    private void scaleUpAddi()
    {
        if(transform.localScale.x < targetScale.x + 0.5f)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale,
            new Vector3(targetScale.x + 0.5f, targetScale.y + 0.5f, targetScale.z + 0.5f),
            2f * Time.fixedDeltaTime);
            Invoke("scaleUpAddi", 0.01f);
        }else
        {
            scaleDownAddi();
        }
    }

    private void scaleDownAddi()
    {
        if (transform.localScale.x > targetScale.x)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale,
            targetScale,
            2.2f * Time.fixedDeltaTime);
            Invoke("scaleDownAddi", 0.01f);
        }       
    }

    private void DestroyTarget()
    {
        currentTarget.GetComponent<Multiplier>().vfxCoollectHol.SetActive(true);
        // fade out
        currentTarget.GetComponent<UIFader>().FadeOut();
        //ScaleUpImage();
        ScaleDownImage();
        //currentTarget.SetActive(false);
    }

    public void ScaleDownImage()
    {
        index1--;

        currentTarget.GetComponent<Multiplier>().imageHolder.GetComponent<RectTransform>().localScale =
            new Vector3(currentTarget.GetComponent<Multiplier>().imageHolder.GetComponent<RectTransform>().localScale.x - 0.06f,
            currentTarget.GetComponent<Multiplier>().imageHolder.GetComponent<RectTransform>().localScale.y - 0.06f,
            currentTarget.GetComponent<Multiplier>().imageHolder.GetComponent<RectTransform>().localScale.z - 0.06f);

        if (index1 > 0)
        {
            Invoke("ScaleDownImage", 0.01f);
        }
    }

    //public void ScaleUpImage()
    //{
    //    index1--;

    //    currentTarget.GetComponent<Multiplier>().imageHolder.GetComponent<RectTransform>().localScale = 
    //        new Vector3(currentTarget.GetComponent<Multiplier>().imageHolder.GetComponent<RectTransform>().localScale.x + 0.06f,
    //        currentTarget.GetComponent<Multiplier>().imageHolder.GetComponent<RectTransform>().localScale.y + 0.06f,
    //        currentTarget.GetComponent<Multiplier>().imageHolder.GetComponent<RectTransform>().localScale.z + 0.06f);

    //    if (index1 > 0)
    //    {
    //        Invoke("ScaleUpImage", 0.01f);
    //    }
    //}

    //private void AdjustWeightText()
    //{

    //    textHolder.GetComponentInChildren<Text>().text = mainWeight2 + " Kg";
    //    mainWeight = mainWeight2;
    //}
    //private void AdjustText()
    //{
    //    textHolder.GetComponent<BallText>().textOffset = Vector3.MoveTowards(textHolder.GetComponent<BallText>().textOffset,
    //        tempTextOffset, 1.3f * Time.fixedDeltaTime);
    //    if(textHolder.GetComponent<BallText>().textOffset.y < tempTextOffset.y)
    //    {
    //        Invoke("AdjustText", 0.02f);
    //    }
        
    //}

    public void EndLevelCeremoni()
    {
        if(mainWeight < secondPlayerWeight)
        {
            PlayerLose();
        }
        else if(mainWeight >= secondPlayerWeight)
        {
            PlayerWon();
        }
    }

    public void PlayerWon()
    {
        Debug.Log("i win");
        secondPlayer.transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
        enemieExplosion.SetActive(true);
        enemieUiHolder.SetActive(false);
        FindObjectOfType<CameraShake>().GetComponent<CameraShake>().shouldShake = true;
        Invoke("PlayWinParticle", 1f);

        Invoke("NewLevel", 4.5f);

    }
    public void PlayerLose()
    {
        Debug.Log("i lose");
        transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
        playerExplosion.SetActive(true);
        playerUiHolder.SetActive(false);
        FindObjectOfType<CameraShake>().GetComponent<CameraShake>().shouldShake = true;
        Invoke("PlayLoseParticle", 1f);

        Invoke("PlayAgain", 4.5f);
    }

    private void PlayWinParticle()
    {
        winParticle.SetActive(true);
        Invoke("StopeParticle", 3f);
    }

    private void PlayLoseParticle()
    {
        loseParticle.SetActive(true);
        Invoke("StopeParticle", 3f);
    }
    private void StopeParticle()
    {
        winParticle.SetActive(false);
        loseParticle.SetActive(false);
    }

    private void PlayAgain()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void NewLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }


    //public void GenerateBalls()
    //{
    //    if(generatedBalls < totalBalls)
    //    {
    //        generatedBalls++;
    //        ofsetForBalChild = currentTarget.transform.position +
    //         new Vector3(Random.Range(-0.3f, 0.3f), 0.6f , Random.Range(-0.3f, 0.3f));
    //        var ballz = Instantiate(ballToGenerate, ofsetForBalChild, Quaternion.identity);
    //        Invoke("GenerateBalls", 0.06f);
    //    }
        
    //}

}






