using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHitDetection : MonoBehaviour
{
    public static bool[] hitting;
    public int targetNum;
    public GameObject hitPartical;

    private void Start()
    {
        hitting = new bool[7];
        for (int i = 0; i < 7; i++) 
        {
            hitting[i] = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Note")
        {
            hitting[targetNum] = true;
            Instantiate(hitPartical, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Note")
        {
            hitting[targetNum] = false;
        }
    }
}
