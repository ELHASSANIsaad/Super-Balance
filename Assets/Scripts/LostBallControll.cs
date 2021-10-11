using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostBallControll : MonoBehaviour
{
    public int lostBallCount;

    // Start is called before the first frame update
    void Start()
    {
        lostBallCount = 0;
    }

    public void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.tag == "PLAYER")
        {
            lostBallCount++;
            coll.gameObject.SetActive(false);
        }
    }

}
