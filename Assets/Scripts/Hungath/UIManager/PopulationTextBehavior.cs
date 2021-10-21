using System;
using System.Collections;
using System.Collections.Generic;
using Hungath.UIManager;
using UnityEngine;

public class PopulationTextBehavior : MonoBehaviour
{
	[SerializeField]	private Population pop;
	
	private void OnMouseDown()
	{
		pop.CenterSlider();
	}
}
