using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallText : MonoBehaviour
{

    private Transform target;
    [HideInInspector]
    public Vector3 textOffset;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<BallManager>().transform;
        textOffset = new Vector3(0f, 0.6f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + textOffset;
    }
}
