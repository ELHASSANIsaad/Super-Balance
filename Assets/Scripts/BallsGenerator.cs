using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsGenerator : MonoBehaviour
{

    public GameObject ballToGenerate;  //
    public Vector3 ofsetForBalChild;  //

    public int totalBalls;             //
    public int generatedBalls;         //

    void Start()
    {
        totalBalls = 1;
        generatedBalls = 1;
    }

    public void GenerateBalls(GameObject targetM)
    {
        targetM.gameObject.transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
        totalBalls = totalBalls * targetM.gameObject.GetComponent<Multiplier>().weightMultiplication;
        totalBalls += targetM.gameObject.GetComponent<Multiplier>().weightAddition;

        ofsetForBalChild = targetM.transform.position +
             new Vector3(Random.Range(-0.35f, 0.35f), 0.8f, Random.Range(-0.35f, 0.35f));
            
            Invoke("GenerateBallsLocal", 0.06f);
        

    }

    public void GenerateBallsLocal()
    {
        if (generatedBalls < totalBalls)
        {
            generatedBalls++;
            
            var ballz = Instantiate(ballToGenerate, ofsetForBalChild, Quaternion.identity);
            Invoke("GenerateBallsLocal", 0.1f);
        }

    }

}





