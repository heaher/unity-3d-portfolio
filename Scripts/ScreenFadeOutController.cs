using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFadeOutController : MonoBehaviour
{
    [Header("Fade Image")]
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1.0f;

    [Header("Thank You Image")]
    [SerializeField] private Image thankYouImage;
    [SerializeField] private float thankYouFadeDuration = 0.5f;
    [SerializeField] private float delayBeforeThankYou = 0.2f;

    private bool isFading;

    private void Awake()
    {
        SetImageAlpha(fadeImage, 0f);

        if (thankYouImage != null)
        {
            SetImageAlpha(thankYouImage, 0f);
            thankYouImage.gameObject.SetActive(false);
        }
    }

    public void StartFadeOutWithThankYou()
    {
        if (isFading)
        {
            return;
        }

        StartCoroutine(FadeOutWithThankYouCoroutine());
    }

    private IEnumerator FadeOutWithThankYouCoroutine()
    {
        isFading = true;

        if (fadeImage != null)
        {
            yield return FadeImageAlpha(fadeImage, 0f, 1f, fadeDuration);
        }

        if (delayBeforeThankYou > 0f)
        {
            yield return new WaitForSeconds(delayBeforeThankYou);
        }

        if (thankYouImage != null)
        {
            thankYouImage.gameObject.SetActive(true);
            yield return FadeImageAlpha(thankYouImage, 0f, 1f, thankYouFadeDuration);
        }
    }

    private IEnumerator FadeImageAlpha(Image image, float fromAlpha, float toAlpha, float duration)
    {
        if (image == null)
        {
            yield break;
        }

        float elapsed = 0f;

        SetImageAlpha(image, fromAlpha);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float t = Mathf.Clamp01(elapsed / duration);
            float alpha = Mathf.Lerp(fromAlpha, toAlpha, t);

            SetImageAlpha(image, alpha);

            yield return null;
        }

        SetImageAlpha(image, toAlpha);
    }

    private void SetImageAlpha(Image image, float alpha)
    {
        if (image == null)
        {
            return;
        }

        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }
}