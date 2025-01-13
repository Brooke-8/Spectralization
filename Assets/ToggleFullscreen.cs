using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleFullscreen : MonoBehaviour
{
    public Button button;
    void Start()
    {
		button.onClick.AddListener(Toggle);


	}
    void Toggle(){
		Screen.fullScreen = !Screen.fullScreen;
		if (Screen.fullScreen) {
			Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
		}
		else {
			Screen.fullScreenMode = FullScreenMode.Windowed;
		}
	}

}
