using UnityEngine;
using UnityEngine.UI;

namespace Hungath.UIManager
{
    public class PopulationSliderColor : MonoBehaviour
    {
        private Image _background;
        private Slider _slider;
        private float _sliderValue;

        private void Awake()
        {
            _background = GetComponent<Image>();
            _slider = GetComponentInParent<Slider>();
            _sliderValue = _slider.value;
            ChangeBackgroundColor();
        }

        private void Update()
        {
            if ((int)_sliderValue != (int)_slider.value)
            {
                _sliderValue = _slider.value;
                ChangeBackgroundColor();
            }
        }
        
        private void ChangeBackgroundColor()
        {
            var percentage = _slider.value / _slider.maxValue;
            _background.color = Color32.Lerp(Globals.HunterColor, Globals.GathererColor, percentage);
        }
    }
}
