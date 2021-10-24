using TMPro;
using UnityEngine;

namespace Hungath.UIManager
{
    public class Food : MonoBehaviour
    {
        private static float _food;
        [SerializeField] private TMP_Text foodText;

        private void Awake() => _food = (Population.TotalPop * 2) + 30;

        public static float GetFood()
        {
            return _food;
        }

        public static void AdjustFood(int amount)
        {
            _food += amount;
            if (_food < 0) _food = 0;
        }

        private void Update()
        {
            var rubberFood = (int) Mathf.Floor(_food);
            foodText.text = $"Food: {rubberFood.ToString()}";
        }
    }
}
