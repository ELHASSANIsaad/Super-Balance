using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseBallance : MonoBehaviour
{

    

    public GameObject loseParticle;

    public void OnTriggerEnter(Collider col)
    {
        if(col.tag == "PLAYER")
        {
            Invoke("PlayParticle", 0.5f);
            Invoke("PlayAgain", 3f);
        }
    }

    private void PlayParticle()
    {
        loseParticle.SetActive(true);
        Invoke("StopParticle", 2f);
    }

    private void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void StopParticle()
    {
        loseParticle.SetActive(false);
    }
}
