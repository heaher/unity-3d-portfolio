using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// 画面全体のフェードアウトと、その後に表示する「Thank You」画像の
// フェードインを制御するクラス。
public class ScreenFadeOutController : MonoBehaviour
{
    [Header("Fade Image")]
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1.0f;

    [Header("Thank You Image")]
    [SerializeField] private Image thankYouImage;
    [SerializeField] private float thankYouFadeDuration = 0.5f;
    [SerializeField] private float delayBeforeThankYou = 0.2f;

    // フェード処理の多重実行を防止するためのフラグ
    private bool isFading;

    private void Awake()
    {
        // 開始時はフェード用画像を透明にしておく
        SetImageAlpha(fadeImage, 0f);

        if (thankYouImage != null)
        {
            // Thank You画像は非表示・透明の状態で初期化する
            SetImageAlpha(thankYouImage, 0f);
            thankYouImage.gameObject.SetActive(false);
        }
    }

    // 画面のフェードアウト後にThank You画像を表示する処理を開始する。
    // すでに処理中の場合は再実行しない。
    public void StartFadeOutWithThankYou()
    {
        if (isFading)
        {
            return;
        }

        StartCoroutine(FadeOutWithThankYouCoroutine());
    }

    // 画面フェードアウトからThank You画像表示までの一連の演出を実行する。
    private IEnumerator FadeOutWithThankYouCoroutine()
    {
        isFading = true;

        // フェード用画像を透明から不透明へ変化させ、画面全体を暗転させる
        if (fadeImage != null)
        {
            yield return FadeImageAlpha(fadeImage, 0f, 1f, fadeDuration);
        }

        // Thank You画像を表示する前に、必要に応じて待機する
        if (delayBeforeThankYou > 0f)
        {
            yield return new WaitForSeconds(delayBeforeThankYou);
        }

        // Thank You画像を有効化し、透明から不透明へフェードインする
        if (thankYouImage != null)
        {
            thankYouImage.gameObject.SetActive(true);
            yield return FadeImageAlpha(thankYouImage, 0f, 1f, thankYouFadeDuration);
        }
    }

    // 指定したImageのアルファ値を、一定時間かけて変化させる。
    private IEnumerator FadeImageAlpha(
        Image image,
        float fromAlpha,
        float toAlpha,
        float duration)
    {
        if (image == null)
        {
            yield break;
        }

        float elapsed = 0f;

        // 補間開始前に、画像を指定した開始アルファ値へ設定する
        SetImageAlpha(image, fromAlpha);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            // 経過時間を0～1の範囲へ変換し、アルファ値を線形補間する
            float t = Mathf.Clamp01(elapsed / duration);
            float alpha = Mathf.Lerp(fromAlpha, toAlpha, t);

            SetImageAlpha(image, alpha);

            // 次のフレームまで待機する
            yield return null;
        }

        // 浮動小数点誤差に関係なく、最後は終了値へ確実に合わせる
        SetImageAlpha(image, toAlpha);
    }

    // ImageのRGB値を維持したまま、アルファ値だけを変更する。
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