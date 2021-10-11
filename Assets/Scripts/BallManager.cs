using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{

    private Rigidbody rb;
    private PlatformScript platformScript;
    public float maximumVelocityX;
    public float maximumVelocityZ;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.3f; //1.2
        rb = GetComponent<Rigidbody>();
        platformScript = FindObjectOfType<PlatformScript>().GetComponent<PlatformScript>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(platformScript.isStrongBalanced)
        {
            rb.velocity = Vector3.MoveTowards(rb.velocity, Vector3.zero, 7.5f * Time.fixedDeltaTime);   //10
        }
        if (platformScript.isBalancedx && platformScript.isDescendingx)
        {
            //Debug.Log("hello");
            rb.velocity = Vector3.MoveTowards(rb.velocity, Vector3.zero, 5.5f * Time.fixedDeltaTime);  //8
        }
        if (platformScript.isBalancedz && platformScript.isDescendingz)
        {
            rb.velocity = Vector3.MoveTowards(rb.velocity, Vector3.zero, 5.5f * Time.fixedDeltaTime);  //8
        }
        
        if(!platformScript.isDescendingx 
            && !platformScript.isDescendingz 
            && !platformScript.isStrongBalanced 
            && rb.velocity.x < maximumVelocityX 
            && rb.velocity.z < maximumVelocityZ)
        {
            Vector3 tempVect = rb.velocity;
            rb.velocity = Vector3.MoveTowards(rb.velocity,
                new Vector3(tempVect.x * 1.8f, tempVect.y, tempVect.z * 1.8f),  //1.5f
                1.3f * Time.fixedDeltaTime);                                   // 1f
            //Debug.Log(rb.velocity);
        }
    }

    

}





