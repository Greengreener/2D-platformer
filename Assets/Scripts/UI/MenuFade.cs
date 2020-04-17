using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFade : MonoBehaviour
{
    public CanvasGroup panelfrom;
    public CanvasGroup panelto;
    public GameObject screenfrom;
    public GameObject screento;
    
    public void Fade()
    {
        screento.SetActive(true);
        StartCoroutine(FadeCanvasGroup(panelto, panelto.alpha, 1));
        StartCoroutine(FadeCanvasGroup(panelfrom, panelfrom.alpha, 0));
        screenfrom.SetActive(false);
    }
    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {
        float _timeStarted = Time.time;
        float timeRunning = Time.time - _timeStarted;
        float percentageComplete = timeRunning / lerpTime;

        while (true)
        {
            timeRunning = Time.time - _timeStarted;
            percentageComplete = timeRunning / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }
    }
}
