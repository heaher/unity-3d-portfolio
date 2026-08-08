using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScreenFadeInController : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 2.0f;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float time = 0f;

        // ç≈èâÇÕäÆëSÇ…çï
        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;

            // 1 Å® 0 Ç÷ìßñæìxÇïœÇ¶ÇÈ
            color.a = Mathf.Lerp(1f, 0f, time / fadeDuration);
            fadeImage.color = color;

            yield return null;
        }

        // ç≈å„ÇÕäÆëSÇ…ìßñæÇ…Ç∑ÇÈ
        color.a = 0f;
        fadeImage.color = color;
    }
}