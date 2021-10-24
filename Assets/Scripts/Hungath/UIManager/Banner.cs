using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hungath.UIManager
{
    public class Banner : MonoBehaviour
    {
        public TMP_Text bannerMessage;
        public Image background;
        public Transform spawnPoint;

        private void Awake()
        {
            bannerMessage = GetComponentInChildren<TMP_Text>();
            background = GetComponentInChildren<Image>();
            spawnPoint = GameObject.Find("BannerSpawnPoint").transform;
        }

        private void Update() => PositionBanners();

        private void PositionBanners()
        {
            var position = spawnPoint.position;
            var bannerOffset = 0;
            foreach (Transform banner in spawnPoint)
            {
                banner.position = new Vector3(position.x, position.y - bannerOffset, position.z);
                bannerOffset += 120;    //not sure why this is the magic number... :(
            }
        }

        //called by Event Trigger in inspector (on background)
        public void OnPointerClickBanner() => FadeBannerMessage();

        public void FadeBannerMessage() => StartCoroutine(nameof(FadeBannerMessageCoroutine));

        public IEnumerator FadeBannerMessageCoroutine()
        {
            while (background.color != Color.clear)
            {
                background.color = Color.Lerp(background.color, Color.clear, .05f);
                bannerMessage.color = Color.Lerp(bannerMessage.color, Color.clear, .05f);
                
                if (background.color.a < 0.1) Destroy(gameObject);
                yield return null;
            }
        }
    }
}
