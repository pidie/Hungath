using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Banner : MonoBehaviour
{
    public TMP_Text bannerMessage;
    public Image background;

    private void Awake()
    {
        bannerMessage.text = "";
    }

    private void Update()
    {
        ActivateBanner();
    }

    private void ActivateBanner()
    {
        if (bannerMessage.text == "")
        {
            background.enabled = false;
        }
        else
        {
            background.enabled = true;
        }
    }
}
