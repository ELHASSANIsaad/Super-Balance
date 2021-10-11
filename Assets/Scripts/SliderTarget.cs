using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderTarget : MonoBehaviour
{
    private float mousePos1;
    private float mousePos2;
    private float mousePos1X;
    private float mousePos2X;
    private float swipingStrenght;
    private float swipingStrenghtX;
    //private float goUpFactor;
    private float goSideFactor;
    private float goForwardFactor;
    //private float rotUpFactor;
    //private float rotSideFactor;
    //private bool miCycle1;

    //public bool canPlay;



    // Start is called before the first frame update
    void Start()
    {
        //canPlay = false;

        ////goUpFactor = 5f;

        goForwardFactor = 4f;
        mousePos1 = 0f;
        mousePos2 = 0f;

        goSideFactor = 4f;

        mousePos1X = 0f;
        mousePos2X = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        //if (!canPlay) return;

        //transform.position += transform.forward * Time.deltaTime * goForwardFactor;

        if (Input.GetMouseButtonDown(0))
        {
            mousePos1 = Input.mousePosition.y;
            mousePos1X = Input.mousePosition.x;
            return;


        }
        if (Input.GetMouseButton(0))
        {
            mousePos2 = Input.mousePosition.y;
            mousePos2X = Input.mousePosition.x;
            swipingStrenght = ((mousePos2 - mousePos1) * 100f) / Screen.height;
            swipingStrenghtX = ((mousePos2X - mousePos1X) * 100f) / Screen.width;

            //Debug.Log(transform.rotation.eulerAngles.y);

            transform.position += transform.forward * swipingStrenght * Time.deltaTime * goForwardFactor;


            transform.position += transform.right * swipingStrenghtX * Time.deltaTime * goSideFactor;
            if (transform.position.x < -5f)
            {
                transform.position = new Vector3(-5f, transform.position.y, transform.position.z);
            }
            if (transform.position.x > 5f)
            {
                transform.position = new Vector3(5f, transform.position.y, transform.position.z);
            }

            if (transform.position.z < -5f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -5f);
            }
            if (transform.position.z > 5f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 5f);
            }

            mousePos1 = Input.mousePosition.y;
            mousePos1X = Input.mousePosition.x;

        }
        if (Input.GetMouseButtonUp(0))
        {
            mousePos1 = 0f;
            mousePos2 = 0f;

            mousePos1X = 0f;
            mousePos2X = 0f;
        }
    }
}




