using System;
using System.Collections;
using System.Collections.Generic;
using Hungath.Game;
using Hungath.UIManager;
using UnityEngine;

public class CameraHeight : MonoBehaviour
{
    private int mapMaximumDimension;
    
    private void Awake()
    {
        mapMaximumDimension = GameManager.GetMapSize(Population.TotalPop)[0];
        transform.position = new Vector3(0, mapMaximumDimension + 1, 0);
    }
}
