using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public float power /*= 0.7f*/;
    public float duration /*= 1.0f*/;
    public Transform camera;
    public float slowDownAmount /*= 1.0f*/;
    public bool shouldShake = false;

    Vector3 startPosition;
    float initialDuration;
    bool getPosition;

    // Start is called before the first frame update
    void Start()
    {
        getPosition = false;
        //camera = Camera.main.transform;
        //startPosition = camera.position;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldShake)
        {
            if(!getPosition)
            {
                camera = Camera.main.transform;
                startPosition = camera.position;
                getPosition = true;
            }

            if(duration > 0)
            {
                camera.transform.position = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                camera.transform.position = startPosition;
            }
        }
    }
}
