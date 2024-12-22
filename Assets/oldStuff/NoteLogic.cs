using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class NoteLogic : MonoBehaviour
{
    public static bool[] noteLogic;
    private int numOn;
    private int numOff;
    private int threshold = 32;
    private float noteInterval = 0.2267573f;
    private float[] lastNoteTime;
    

    // Start is called before the first frame update
    void Start()
    {
        
        noteLogic = new bool[7];
        for (int i = 0; i < 7; i++)
        {
            noteLogic[i] = false;
        }
        lastNoteTime = new float[7];
        numOn = 0;
        numOff = 0;

        StartCoroutine(Logic());
    }

    IEnumerator Logic()
    {
        while (true)
        {
            try
            {
                Debug.Log(NoteTrigger.subBandLogic[32]);
                numOn = (NoteTrigger.subBandLogic).Count(b => b);
                numOff = 64 - numOn;
                if (numOn > threshold && Time.time - lastNoteTime[3] > noteInterval * 2)
                {
                    noteLogic[3] = true;
                    lastNoteTime[3] = Time.time;
                }
                
            }
            catch (Exception ex)
            {
                Debug.LogError("An error occurred: " + ex.Message);
            }
            yield return new WaitForSeconds(0.00002267573f);

        }
    }
}
