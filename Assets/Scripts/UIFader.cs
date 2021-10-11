using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFader : MonoBehaviour
{

    public CanvasGroup uiElement;

    public GameObject camera1;
    public GameObject sphere1;
    public GameObject water1;

    public GameObject camera2;
    public GameObject sphere2;
    public GameObject water2;

    public bool switchb;

    public void Start()
    {
        switchb = true;
    }

    public void FadeIn()
    {
        StartCoroutine(FadeCanvaGroup(uiElement, uiElement.alpha, 1));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvaGroup(uiElement, uiElement.alpha, 0));
    }

    public IEnumerator FadeCanvaGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {
        float timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageCompleted = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - timeStartedLerping;
            percentageCompleted = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageCompleted);
            cg.alpha = currentValue;

            if (percentageCompleted >= 1f) break;

            yield return new WaitForEndOfFrame();
        }

        Debug.Log("hello");
    }

     public void SwitchCamera()
    {
        switchb = !switchb;
        camera1.SetActive(switchb);
        sphere1.SetActive(switchb);
        water1.SetActive(switchb);

        camera2.SetActive(!switchb);
        sphere2.SetActive(!switchb);
        water2.SetActive(!switchb);
    }
}




