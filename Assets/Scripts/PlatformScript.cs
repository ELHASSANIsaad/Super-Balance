using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private float mousePos1;
    private float mousePos2;
    private float mousePos1X;
    private float mousePos2X;
    private float swipingStrenght;
    private float swipingStrenghtX;
   
    private float goSideFactor;
    private float goSideFactorx;

    private float minForBallance;
    private float minForBallanceEuler;

    private float rot1x, rot2x, rot1z, rot2z;

    //private bool xRotAdjusted;
    //private bool zRotAdjusted;

    public bool canPlay;

    public float minSwipeDist;

    public bool isBalancedx;
    public bool isBalancedz;
    public bool isStrongBalanced;

    public bool isDescendingx;
    public bool isDescendingz;


    // Start is called before the first frame update
    void Start()
    {
        canPlay = true;
        minForBallance = 3f;
        minForBallanceEuler = 360f - minForBallance;

        isBalancedx = true;
        isBalancedz = true;
        isStrongBalanced = true;

        isDescendingx = false;
        isDescendingz = false;
        
        mousePos1 = 0f;
        mousePos2 = 0f;

        goSideFactor = 10f;  //25
        goSideFactorx = 10f;  //25

        mousePos1X = 0f;
        mousePos2X = 0f;

        //CheeckForBalance();
    }

    // Update is called once per frame
    private void Update()
    {
        CheeckForBalance();
        CheeckForDescending();

        

        if (Input.GetMouseButtonDown(0))
        {
            mousePos1 = Input.mousePosition.y;
            mousePos1X = Input.mousePosition.x;
            return;
        }
        if (Input.GetMouseButton(0) && canPlay)
        {
            mousePos2 = Input.mousePosition.y;
            mousePos2X = Input.mousePosition.x;
            swipingStrenght = ((mousePos2 - mousePos1) * 100f) / Screen.height;
            swipingStrenghtX = ((mousePos2X - mousePos1X) * 100f) / Screen.width;

            //Debug.Log(transform.rotation.eulerAngles.y);

            if(Mathf.Abs(swipingStrenght)  > minSwipeDist )
            {
                mousePos1 = Input.mousePosition.y;
                transform.Rotate(Vector3.right, swipingStrenght * Time.deltaTime * goSideFactor);
                if (transform.rotation.eulerAngles.x < 150f)
                {
                    if (transform.rotation.eulerAngles.x > 25f)
                    {
                        Vector3 eulerRotationl = transform.rotation.eulerAngles;
                        transform.rotation = Quaternion.Euler(25f, 0f, eulerRotationl.z);
                    }
                }
                if (transform.rotation.eulerAngles.x > 180f)
                {
                    if (transform.rotation.eulerAngles.x < 335f)
                    {
                        Vector3 eulerRotationl = transform.rotation.eulerAngles;
                        transform.rotation = Quaternion.Euler(-25f, 0f, eulerRotationl.z);
                    }
                }
            }

            if (Mathf.Abs(swipingStrenghtX) > minSwipeDist)
            {
                mousePos1X = Input.mousePosition.x;
                transform.Rotate(Vector3.forward, -swipingStrenghtX * Time.deltaTime * goSideFactorx);
                if (transform.rotation.eulerAngles.z < 150f)
                {
                    if (transform.rotation.eulerAngles.z > 25f)
                    {
                        Vector3 eulerRotationl = transform.rotation.eulerAngles;
                        transform.rotation = Quaternion.Euler(eulerRotationl.x, 0f, 25f);
                    }
                }
                if (transform.rotation.eulerAngles.z > 180f)
                {
                    if (transform.rotation.eulerAngles.z < 335f)
                    {
                        Vector3 eulerRotationl = transform.rotation.eulerAngles;
                        transform.rotation = Quaternion.Euler(eulerRotationl.x, 0f, -25f);
                    }
                }


            }


            //transform.RotateAroundLocal(Vector3.right, swipingStrenghtX * Time.deltaTime * goSideFactor);

            //transform.Rotate(Vector3.forward, -swipingStrenghtX * Time.deltaTime * goSideFactor);
            //transform.Rotate(Vector3.right, swipingStrenght * Time.deltaTime * goSideFactor);

            Vector3 eulerRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(eulerRotation.x, 0f, eulerRotation.z);


            //transform.position += transform.right * swipingStrenghtX * Time.deltaTime * goSideFactor;
            //if (transform.position.x < -5f)
            //{
            //    transform.position = new Vector3(-5f, transform.position.y, transform.position.z);
            //}
            //if (transform.position.x > 5f)
            //{
            //    transform.position = new Vector3(5f, transform.position.y, transform.position.z);
            //}

            //if (transform.position.z < -5f)
            //{
            //    transform.position = new Vector3(transform.position.x, transform.position.y, -5f);
            //}
            //if (transform.position.z > 5f)
            //{
            //    transform.position = new Vector3(transform.position.x, transform.position.y, 5f);
            //}

            //mousePos1 = Input.mousePosition.y;
            //mousePos1X = Input.mousePosition.x;

        }
        if (Input.GetMouseButtonUp(0))
        {
            mousePos1 = 0f;
            mousePos2 = 0f;

            mousePos1X = 0f;
            mousePos2X = 0f;

            //xRotAdjusted = false;
            //zRotAdjusted = false;
            ResetPlatform();
            ResetPlatformZ();
            //Debug.Log(transform.rotation.x * 100f);
            //Debug.Log(transform.rotation.eulerAngles.x);

            //Debug.Log(transform.rotation.z * 100f);
        }
    }


    //private void ResetPlatform()
    //{
    //    Vector3 eulerRotation = transform.rotation.eulerAngles;
    //    if (eulerRotation.x != 0f && !xRotAdjusted)
    //    {

    //        transform.Rotate(Vector3.right, 1f * Time.deltaTime);
    //        if(transform.rotation.eulerAngles.x < eulerRotation.x)
    //        {
    //            xRotAdjusted = true;
    //            transform.rotation = Quaternion.Euler(0f, 0f, eulerRotation.z);
    //        }
    //        //Vector3 zawiya = Vector3.MoveTowards(new Vector3(eulerRotation.x, eulerRotation.y, eulerRotation.z), Vector3.zero, 1);
    //        //transform.rotation = Quaternion.Euler(zawiya);

    //    }
    //    if (eulerRotation.z != 0f && !zRotAdjusted)
    //    {
    //        transform.Rotate(Vector3.forward, 1f * Time.deltaTime);
    //        if (transform.rotation.eulerAngles.z < eulerRotation.z)
    //        {
    //            zRotAdjusted = true;
    //            transform.rotation = Quaternion.Euler(eulerRotation.x, 0f, 0f);
    //        }
    //        //transform.Rotate(Vector3.forward, 5f * Time.deltaTime);
    //        //Vector3 zawiya = Vector3.MoveTowards(new Vector3(eulerRotation.x, eulerRotation.y, eulerRotation.z), Vector3.zero, 1);
    //        //transform.rotation = Quaternion.Euler(zawiya);
    //    }
    //    //transform.rotation = Quaternion.Euler(eulerRotation.x, 0f, eulerRotation.z);
    //    if (eulerRotation.x != 0f || eulerRotation.z != 0f)
    //    {
    //        Invoke("ResetPlatform", 0.02f);
    //    }
    //}

    public void ResetPlatform()
    {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        if (eulerRotation.x != 0f && eulerRotation.x < 50f)
        {
            float a = eulerRotation.x;
            transform.rotation = Quaternion.Euler(a - 0.3f , 0f, eulerRotation.z);
            if(eulerRotation.x <= 0.35f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, eulerRotation.z);
                return;
            }
        }
        else if(eulerRotation.x != 0f && eulerRotation.x > 310f)
        {
            float a = 360f - eulerRotation.x;
            transform.rotation = Quaternion.Euler(-a + 0.3f, 0f, eulerRotation.z);
            if (eulerRotation.x >= 359.65f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, eulerRotation.z);
                return;
            }
        }
        if (eulerRotation.x != 0f)
        {
            Invoke("ResetPlatform", 0.001f);
            
        }
    }

    public void ResetPlatformZ()
    {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        if (eulerRotation.z != 0f && eulerRotation.z < 50f)
        {
            float a = eulerRotation.z;
            transform.rotation = Quaternion.Euler(eulerRotation.x, 0f, a - 0.3f);
            if (eulerRotation.z <= 0.35f)
            {
                transform.rotation = Quaternion.Euler(eulerRotation.x, 0f, 0f);
                return;
            }
        }
        else if (eulerRotation.z != 0f && eulerRotation.z > 310f)
        {
            float a = 360f - eulerRotation.z;
            transform.rotation = Quaternion.Euler(eulerRotation.x, 0f, -a + 0.3f);
            if (eulerRotation.z >= 359.65f)
            {
                transform.rotation = Quaternion.Euler(eulerRotation.x, 0f, 0f);
                return;
            }
        }
        if (eulerRotation.z != 0f)
        {
            Invoke("ResetPlatformZ", 0.001f);

        }
    }
    

    private void CheeckForBalance()
    {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        if (eulerRotation.z == 0f && eulerRotation.x == 0f)
        {
            isStrongBalanced = true;
            isBalancedx = true;
            isBalancedz = true;
            //Invoke("CheeckForBalance", 0.2f);
            return;
        }

        if (eulerRotation.z < 50f && eulerRotation.x < 50f)
        {
            if(eulerRotation.z < minForBallance && eulerRotation.x < minForBallance)
            {
                isBalancedx = true;
                isBalancedz = true;
                isStrongBalanced = false;
                
            }else if(eulerRotation.z < minForBallance)
            {
                isBalancedz = true;
                isBalancedx = false;
                isStrongBalanced = false;
                //return;
            }else if(eulerRotation.x < minForBallance)
            {
                isBalancedz = false;
                isBalancedx = true;
                isStrongBalanced = false;
                //return;
            }else
            {
                isBalancedz = false;
                isBalancedx = false;
                isStrongBalanced = false;
            }
        }

        else if (eulerRotation.z < 50f && eulerRotation.x > 310f)
        {
            if (eulerRotation.z < minForBallance && eulerRotation.x > minForBallanceEuler)
            {
                isBalancedx = true;
                isBalancedz = true;
                isStrongBalanced = false;
                //return;
            }
            else if (eulerRotation.z < minForBallance)
            {
                isBalancedx = false;
                isBalancedz = true;
                isStrongBalanced = false;
                //return;
            }
            else if (eulerRotation.x > minForBallanceEuler)
            {
                isBalancedx = true;
                isBalancedz = false;
                isStrongBalanced = false;
                //return;
            }
            else
            {
                isBalancedz = false;
                isBalancedx = false;
                isStrongBalanced = false;
            }
        }

        else if (eulerRotation.z > 310f && eulerRotation.x < 50f)
        {
            if (eulerRotation.z > minForBallanceEuler && eulerRotation.x < minForBallance)
            {
                isBalancedx = true;
                isBalancedz = true;
                isStrongBalanced = false;
                //return;
            }
            else if (eulerRotation.z > minForBallanceEuler)
            {
                isBalancedx = false;
                isBalancedz = true;
                isStrongBalanced = false;
                //return;
            }
            else if (eulerRotation.x < minForBallance)
            {
                isBalancedx = true;
                isBalancedz = false;
                isStrongBalanced = false;
                //return;
            }
            else
            {
                isBalancedz = false;
                isBalancedx = false;
                isStrongBalanced = false;
            }
        }
        else if (eulerRotation.z > 310f && eulerRotation.x > 310f)
        {
            if (eulerRotation.z > minForBallanceEuler && eulerRotation.x > minForBallanceEuler)
            {
                isBalancedx = true;
                isBalancedz = true;
                isStrongBalanced = false;
                //return;
            }
            else if (eulerRotation.z > minForBallanceEuler)
            {
                isBalancedx = false;
                isBalancedz = true;
                isStrongBalanced = false;
                //return;
            }
            else if (eulerRotation.x > minForBallanceEuler)
            {
                isBalancedx = true;
                isBalancedz = false;
                isStrongBalanced = false;
                //return;
            }
            else
            {
                isBalancedz = false;
                isBalancedx = false;
                isStrongBalanced = false;
            }
        }
        //if (eulerRotation.z > 310f && eulerRotation.x > 310f)
        //{
        //    isBalancedx = false;
        //    isBalancedz = false;
        //    isStrongBalanced = false;
        //}


        //if (eulerRotation.z < 50f || eulerRotation.z > 310f || eulerRotation.x < 50f || eulerRotation.x > 310f)
        //{
        //    if (eulerRotation.z < 8f 
        //        && (eulerRotation.z > 352f || eulerRotation.z == 0f) 
        //        && eulerRotation.x < 8f 
        //        && ( eulerRotation.x > 352f || eulerRotation.x == 0f))
        //    {
        //        isBalanced = true;
        //        //Invoke("CheeckForBalance", 0.2f);
        //        return;
        //    }else
        //    {
        //        isBalanced = false;
        //        //Invoke("CheeckForBalance", 0.2f);
        //        return;
        //    }

        //}
        //Invoke("CheeckForBalance", 0.2f);

    }

    private void CheeckForDescending()
    {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        if (eulerRotation.z == 0f && eulerRotation.x == 0f)
        {
            isDescendingx = false;
            isDescendingz = false;
            return;
        }

        if (eulerRotation.z < 50f && eulerRotation.x < 50f)
        {
            rot1x = rot2x;
            rot2x = eulerRotation.x;
            rot1z = rot2z;
            rot2z = eulerRotation.z;
            if(rot2x < rot1x)
            {
                isDescendingx = true;
            }
            else
            {
                isDescendingx = false;
            }
            if (rot2z < rot1z)
            {
                isDescendingz = true;
            }
            else
            {
                isDescendingz = false;
            }


        }

        else if (eulerRotation.z < 50f && eulerRotation.x > 310f)
        {
            rot1x = rot2x;
            rot2x = eulerRotation.x;
            rot1z = rot2z;
            rot2z = eulerRotation.z;
            if (rot2x > rot1x)
            {
                isDescendingx = true;
            }
            else
            {
                isDescendingx = false;
            }
            if (rot2z < rot1z)
            {
                isDescendingz = true;
            }
            else
            {
                isDescendingz = false;
            }
        }

        else if (eulerRotation.z > 310f && eulerRotation.x < 50f)
        {
            rot1x = rot2x;
            rot2x = eulerRotation.x;
            rot1z = rot2z;
            rot2z = eulerRotation.z;
            if (rot2x < rot1x)
            {
                isDescendingx = true;
            }
            else
            {
                isDescendingx = false;
            }
            if (rot2z > rot1z)
            {
                isDescendingz = true;
            }
            else
            {
                isDescendingz = false;
            }
        }
        else if (eulerRotation.z > 310f && eulerRotation.x > 310f)
        {
            rot1x = rot2x;
            rot2x = eulerRotation.x;
            rot1z = rot2z;
            rot2z = eulerRotation.z;
            if (rot2x > rot1x)
            {
                isDescendingx = true;
            }
            else
            {
                isDescendingx = false;
            }
            if (rot2z > rot1z)
            {
                isDescendingz = true;
            }
            else
            {
                isDescendingz = false;
            }
        }
        

    }

}
