﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal; // Vignette 효과 사용을 위한 네임스페이스


public class TakeDamagePost : MonoBehaviour
{
    Volume volume;
    Vignette vignette;

    public void TakeDMG()
    {
        if(volume == null)
            volume = GetComponent<Volume>();
        if (volume.profile.TryGet<Vignette>(out vignette))
        {
            vignette.intensity.value = 0f;
        }
        gameObject.SetActive(true);
        if (vignette != null )
        {
            StartCoroutine(ReduceVignetteIntensity());
        }
    }

    private IEnumerator ReduceVignetteIntensity()
    {
        volume.priority = 10;
        float duration = 1.0f; // 감소에 걸리는 시간
        float startIntensity = 0.3f;
        float endIntensity = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            vignette.intensity.value = Mathf.Lerp(startIntensity, endIntensity, elapsedTime / duration);
            yield return null;
        }
        gameObject.SetActive(false);
    }
}