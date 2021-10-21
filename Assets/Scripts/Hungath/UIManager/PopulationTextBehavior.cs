using System;
using System.Collections;
using System.Collections.Generic;
using Hungath.UIManager;
using UnityEngine;

public class PopulationTextBehavior : MonoBehaviour
{
	private void OnMouseDown()
	{
		Population.CenterSlider();
		Debug.Log("click");
	}
}
