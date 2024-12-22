using NAudio.Wave;
using System;
using UnityEngine;

public class DeviceNames : MonoBehaviour
{
    void Start()
    {
        for (int n = 0; n < WaveIn.DeviceCount; n++)
        {
            WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(n);
            string deviceName = deviceInfo.ProductName;
            int deviceNumber = n;

            Debug.Log("Device #" + deviceNumber + ": " + deviceName);
        }
    }
}
