using UnityEngine;
using UnityEngine.Playables;

public class VictoryTimelineController : MonoBehaviour
{
    [Header("Timelines")]
    [SerializeField] private PlayableDirector introDirector;
    [SerializeField] private PlayableDirector idleLoopDirector;

    [Header("Fade")]
    [SerializeField] private ScreenFadeOutController screenFadeOutController;

    [Header("Options")]
    [SerializeField] private bool playIntroOnStart = true;

    private bool isIdleLoopPlaying;
    private bool hasRequestedEnding;

    private void Start()
    {
        if (introDirector == null || idleLoopDirector == null)
        {
            Debug.LogError("PlayableDirector が設定されていません。", this);
            return;
        }

        if (screenFadeOutController == null)
        {
            Debug.LogError("ScreenFadeOutController が設定されていません。", this);
            return;
        }

        // Intro終了時に呼ばれるイベントを登録
        introDirector.stopped += OnIntroStopped;

        // IdleLoopは最初は止めておく
        idleLoopDirector.Stop();

        isIdleLoopPlaying = false;
        hasRequestedEnding = false;

        if (playIntroOnStart)
        {
            introDirector.time = 0;
            introDirector.Play();
        }
    }

    private void Update()
    {
        // IdleLoop中以外はEnterを受け付けない
        if (!isIdleLoopPlaying)
        {
            return;
        }

        // すでに終了処理を開始していたら何もしない
        if (hasRequestedEnding)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            hasRequestedEnding = true;

            // ループ中のTimelineを一時停止
            idleLoopDirector.Pause();

            // フェードアウト + Thank you 表示
            screenFadeOutController.StartFadeOutWithThankYou();
        }
    }

    private void OnDestroy()
    {
        if (introDirector != null)
        {
            introDirector.stopped -= OnIntroStopped;
        }
    }

    private void OnIntroStopped(PlayableDirector director)
    {
        // 念のため、Intro以外の停止イベントなら無視
        if (director != introDirector) return;

        PlayIdleLoop();
    }

    private void PlayIdleLoop()
    {
        idleLoopDirector.time = 0;
        idleLoopDirector.Play();

        isIdleLoopPlaying = true;
    }
}