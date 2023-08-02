using UnityEngine;
using TMPro;
using System.Collections;

public class UISwitcher : MonoBehaviour
{
    public TextMeshProUGUI nextText; // 다음으로 전환할 TextMeshPro 오브젝트
    public float switchDelay = 10f; // 전환 딜레이 (10초)

    private void OnEnable()
    {
        // 현재 UI 객체가 활성화되면 코루틴 실행
        StartCoroutine(SwitchUI());
    }

    private IEnumerator SwitchUI()
    {
        // 10초를 기다린 후 현재 UI 객체를 투명하게 만들고 비활성화
        yield return new WaitForSeconds(switchDelay);
        SetUIAlpha(0f);
        gameObject.SetActive(false);

        // 다음 TextMeshPro 오브젝트가 할당되어 있다면 보이도록 설정
        if (nextText != null)
        {
            SetUIAlpha(1f);
            nextText.gameObject.SetActive(true);
        }
    }

    private void SetUIAlpha(float alpha)
    {
        // CanvasGroup 컴포넌트의 투명도(alpha)를 조절하여 UI를 보이거나 숨길 수 있습니다.
        if (nextText != null)
        {
            CanvasGroup canvasGroup = nextText.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = alpha;
            }
        }
    }
}
