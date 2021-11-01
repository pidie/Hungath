using Hungath.UIManager;
using UnityEngine;

namespace Hungath.Main
{
    public class CameraHeight : MonoBehaviour
    {
        private int _mapMaximumDimension;
    
        private void Awake()
        {
            _mapMaximumDimension = GameManager.GetMapSize(Population.TotalPop)[0];
            transform.position = new Vector3(0, _mapMaximumDimension + 1, 0);
        }
    }
}
