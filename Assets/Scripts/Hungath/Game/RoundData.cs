using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hungath.Game
{
	public class RoundData : MonoBehaviour
	{
		[Header("Map Size")] 
		[Range(3, 8)] [SerializeField]
		private static int _mapWidth;
		[Range(3, 8)] [SerializeField] 
		private static int _mapHeight;

		private void Awake()
		{
			_mapHeight = 8;
			_mapWidth = 8;
		}

		public static int GetMapWidth()
		{
			return _mapWidth;
		}

		public static int GetMapHeight()
		{
			return _mapHeight;
		}
	}
}