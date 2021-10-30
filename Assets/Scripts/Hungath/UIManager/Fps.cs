using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace Hungath.UIManager
{
	public class Fps : MonoBehaviour
	{
		private Text _fpsDisplay;
		private bool _isDisplayed;

		private static int _frameCounter;
		private static float _timeCounter;
		private static float _lastFramerate;
		private const float RefreshTime = 0.5f;

		private void Awake()
		{
			_fpsDisplay = GetComponent<Text>();
			_isDisplayed = true;
		}

		private void Update()
		{
			if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) &&
			    Input.GetKeyDown(KeyCode.F))
			{
				ToggleFps();
			}
			
			if (_isDisplayed)
			{
				if (!_fpsDisplay.IsActive())
				{
					_fpsDisplay.enabled = true;
				}
				_fpsDisplay.text = GetFps().ToString(CultureInfo.CurrentCulture);
			}
			else
			{
				_fpsDisplay.enabled = false;
			}
		}

		public void ToggleFps()
		{
			_isDisplayed = !_isDisplayed;
		}

		private static float GetFps()
		{
			if( _timeCounter < RefreshTime )
			{
				_timeCounter += Time.deltaTime;
				_frameCounter++;
			}
			else
			{
				_lastFramerate = _frameCounter/_timeCounter;
				_frameCounter = 0;
				_timeCounter = 0.0f;
			}

			return (int)_lastFramerate;
		}
	}
}
