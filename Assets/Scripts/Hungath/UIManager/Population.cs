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
        public Slider slider;
        public TMP_Text hunterPopText;
        public TMP_Text gathererPopText;
        public TMP_Text totalPopText;

        private void Awake()
        {
            slider = FindObjectOfType<Slider>();
            slider.maxValue = TotalPop;
            slider.value = slider.maxValue / 2.0f;
        }

        private void Update()
        {
            slider.maxValue = TotalPop;
            
            GathererPop = (int) slider.value;
            HunterPop = TotalPop - GathererPop;

            hunterPopText.text = HunterPop.ToString();
            gathererPopText.text = GathererPop.ToString();
            totalPopText.text = TotalPop.ToString();
        }

        public void CenterSlider() => slider.value = slider.maxValue / 2.0f;
    }
}
