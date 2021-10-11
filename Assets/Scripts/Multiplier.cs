using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Multiplier : MonoBehaviour
{

    public int weightAddition;
    public int weightMultiplication;

    public GameObject vfxCoollectHol;
    
    public float scaleAddition;

    public bool isTouched;

    //public GameObject textHolder;
    public GameObject imageHolder;

    // Start is called before the first frame update
    void Start()
    {
        isTouched = false;
        
        vfxCoollectHol.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}






