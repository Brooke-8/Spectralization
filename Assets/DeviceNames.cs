using NAudio.Wave;
using System;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using System.Collections.Generic;

public class DeviceNames : MonoBehaviour {

	private TMP_Dropdown dropdown;
	void Start() {
		dropdown = GetComponent<TMP_Dropdown>();
		dropdown.ClearOptions();
		List<string> devices = new List<string>();

		for (int n = 0; n < WaveIn.DeviceCount; n++) {
			WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(n); //Fixed later: https://stackoverflow.com/questions/1449162/get-the-full-name-of-a-wavein-device
			string deviceName = deviceInfo.ProductName;
			int deviceNumber = n;
			string deviceString = "Device #" + deviceNumber + ": " + deviceName;
			devices.Add(deviceString);
			Debug.Log(deviceString);
		}
		dropdown.AddOptions(devices);
		dropdown.SetValueWithoutNotify(GameOptions.Instance.DeviceNumber);
		dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
	}

	void OnDropdownValueChanged(int index) {
		Debug.Log("Selected: " + dropdown.options[index].text);
		GameOptions.Instance.SetDeviceNumber(index);
	}
	
}
