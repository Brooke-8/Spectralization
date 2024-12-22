using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptions{
    public static GameOptions Instance {
        get { 
            if (instance == null){
                instance = new GameOptions();
            }
            return instance; 
        } 
    }
    private static GameOptions instance;

    public int DeviceNumber { get; private set; } = 0;
    public void SetDeviceNumber(int deviceNumber) {
        this.DeviceNumber = deviceNumber;
    }
    private GameOptions(){ }
}
