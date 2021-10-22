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
        //makes the Banner invisible
        BannerMessage.CreateNewBannerMessage(BannerMessageType.DebugBlank);
    }
}
