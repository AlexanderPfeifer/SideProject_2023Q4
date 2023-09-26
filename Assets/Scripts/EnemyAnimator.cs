using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private GameObject targetingVisuals;

    private void Start()
    {
        targetingVisuals.SetActive(false);
    }

    public void ShowTargetingAnimation(float duration)
    {
        StartCoroutine(ShowTargetingAnimationCoroutine(duration));
    }

    private IEnumerator ShowTargetingAnimationCoroutine(float duration)
    {
        targetingVisuals.SetActive(true);
        Transform targetingVisualsTransform = this.targetingVisuals.transform;
        targetingVisualsTransform.localScale = Vector3.zero;

        float passedTime = 0;
        while (passedTime < duration)
        {
            passedTime += Time.deltaTime;
            yield return null;
            float scale = passedTime / duration;
            scale = Mathf.Clamp01(scale);
            targetingVisualsTransform.localScale = new Vector3(scale, scale, scale);
        }
        
        targetingVisuals.SetActive(false);
    }
}
