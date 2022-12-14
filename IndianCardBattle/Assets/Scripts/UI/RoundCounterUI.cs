using DG.Tweening;
using TMPro;
using UnityEngine;

public class RoundCounterUI : MonoBehaviour
{
    [SerializeField] private RectTransform selfTransform;
    [SerializeField] private TextMeshProUGUI roundCounterText;
    [SerializeField] private TurnTimerUI turnTimerUI;
    private int TotalRoundCount;
    private Vector3 startPosition;

    private void OnEnable()
    {
        CustomEventManager.Instance.AddListener(RoundEvents.ROUND_START,ShowRoundCounterUI);
    }

    private void OnDisable()
    {
        CustomEventManager.Instance.RemoveListener(RoundEvents.ROUND_START,ShowRoundCounterUI);
    }

    private void Start()
    {
        TotalRoundCount = GameData.Instance.GameConfiguration.numberOfRounds;
        startPosition = selfTransform.anchoredPosition;
    }

    private void ShowRoundCounterUI(params object [] args)
    {
        
        roundCounterText.text = $"{(int)args[0]}/{TotalRoundCount}";

        selfTransform.anchoredPosition = startPosition;
        Tween slideIn = selfTransform.DOAnchorPosX(0, 0.5f);
        Tween slideOut = selfTransform.DOAnchorPosX(-1500f, 0.5f);
        Sequence animationSequence = DOTween.Sequence();
        animationSequence.Append(slideIn);
        animationSequence.AppendInterval(0.7f);
        animationSequence.Append(slideOut);
        animationSequence.Play().OnComplete(RoundCounterUIAnimationComplete);
    }

    private void RoundCounterUIAnimationComplete()
    {
        CustomEventManager.Instance.Invoke(UIEvents.ROUND_COMPLETE_UI_ANIM_COMPLETE);
    }
    
}
