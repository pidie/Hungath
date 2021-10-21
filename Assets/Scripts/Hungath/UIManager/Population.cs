using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hungath.UIManager
{
    public class Population : MonoBehaviour
    {
        public static int HunterPop;
        public static int GathererPop;
        public static int TotalPop = 10;
        public static Slider Slider;
        public TMP_Text hunterPopText;
        public TMP_Text gathererPopText;
        public TMP_Text totalPopText;

        private void Awake()
        {
            Slider = FindObjectOfType<Slider>();
            Slider.maxValue = TotalPop;
            CenterSlider();
        }

        private void Update()
        {
            Slider.maxValue = TotalPop;
            
            GathererPop = (int) Slider.value;
            HunterPop = TotalPop - GathererPop;

            hunterPopText.text = HunterPop.ToString();
            gathererPopText.text = GathererPop.ToString();
            totalPopText.text = TotalPop.ToString();
        }

        public static void CenterSlider() => Slider.value = Slider.maxValue / 2.0f;
    }
}
