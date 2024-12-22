using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LightOnHover : MonoBehaviour
{
    public string lightColour = "#df84a5";
    public string normalColour = "#ebede9";
    public static UnityEngine.Color lightC;
    public static UnityEngine.Color normalC;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.ColorUtility.TryParseHtmlString(lightColour, out lightC);
        UnityEngine.ColorUtility.TryParseHtmlString(normalColour, out normalC);
    }

    // Update is called once per frame
    private void OnMouseEnter()
    {
        text.color = lightC;
        StartCoroutine(SizeChange());

    }
    private void OnMouseExit()
    {
        text.color = normalC;
    }
    IEnumerator SizeChange()
    {
        float elapsedTime = 0f;
        float changeTime = 0.1f;
        float startSize = text.fontSize;
        float bigSize = text.fontSize + 4;
        text.fontSize = bigSize;
        while (elapsedTime < changeTime)
        {
            text.fontSize = Mathf.Lerp(bigSize, startSize, elapsedTime/changeTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        text.fontSize = startSize;
  
        
        
    }
}
