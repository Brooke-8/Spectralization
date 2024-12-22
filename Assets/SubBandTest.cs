using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SubBandTest : MonoBehaviour
{
    public int objectNum;

    public float targetYScale1 = 7f;
    public float targetYScale2 = 0.05f;

    private float currentY;

    private bool[] isWaiting;

    // Start is called before the first frame update
    void Start()
    {
        isWaiting = new bool[64];
        for (int i = 0; i < isWaiting.Length; i++)
        {
            isWaiting[i] = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

        for (int o = 0; o < 64; o++)
        {
            if (NoteTrigger.subBandLogic[o] == true && objectNum == o)
            {
                currentY = gameObject.transform.localScale.y;
                
                currentY = Mathf.Lerp(currentY, targetYScale1, NoteTrigger.lerpSpeed * Time.deltaTime);
                gameObject.transform.localScale = new Vector3(0.5f, currentY, 1);
                transform.localScale = new Vector3(0.2f, currentY, 1);
            }
            if (NoteTrigger.subBandLogic[o] == false && objectNum == o)
            {
                currentY = gameObject.transform.localScale.y;
                
                currentY = Mathf.Lerp(currentY, targetYScale2, NoteTrigger.lerpSpeed * Time.deltaTime);
                gameObject.transform.localScale = new Vector3(0.5f, currentY, 1);
                transform.localScale = new Vector3(0.2f, currentY, 1);
            }
        }
    }
}
