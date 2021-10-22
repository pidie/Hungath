using System.Collections;
using Hungath.UIManager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Banner : MonoBehaviour
{
    public TMP_Text bannerMessage;
    public Image background;

    private void Awake()
    {
        ResetBanner();
    }

    public void ResetBanner()
    {
        BannerMessage.CreateNewBannerMessage(BannerMessageType.DebugBlank);
    }
    
    public void OnPointerClickBanner()
    {
        // called by Event Trigger in the inspector
        FadeBannerMessage();
    }

    public void FadeBannerMessage()
    {
        float startTime = Time.deltaTime;
        float duration = 1.5f;
        var alpha = FadeBannerMessage(startTime, duration);
    }

    public IEnumerator FadeBannerMessage(float startTime, float duration)
    {
        //use current frame rate and last frame rate to determine the next alphaDrop so the whole thing lasts 1.5s
        for (float i = 0; i < duration; i++)
        {
            background.color = new Color(background.color.r, background.color.g, background.color.b, i);
            yield return null;
        }
    }
}
