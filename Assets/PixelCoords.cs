using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelCoords : MonoBehaviour
{
    public int xCoord;
    public int yCoord;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (yCoord == 0)
        {
            if (((xCoord < 16 && Input.GetKeyDown(KeyCode.A))
               || ((16 <= xCoord) && (xCoord < 32) && Input.GetKeyDown(KeyCode.S))
               || ((32 <= xCoord) && (xCoord < 48) && Input.GetKeyDown(KeyCode.D))
               || (48 <= xCoord && Input.GetKeyDown(KeyCode.F))))
            {
                StartCoroutine(ChangeColour(spriteRenderer));
            }
        }
        if (yCoord > 0 && spriteRenderer.color == Color.white)
        {
            if (CreatePixelGrid.pixelGrid[xCoord, yCoord - 1].GetComponent<SpriteRenderer>().color == KeyPress.pixelC)
            {
                spriteRenderer.color = KeyPress.pixelC;
            }
        }
    }
    IEnumerator ChangeColour(SpriteRenderer Sr)
    {

        yield return new WaitForEndOfFrame();
        Sr.color = KeyPress.pixelC;
        yield return new WaitForSeconds(0.1f);
        Sr.color = Color.white;
    }
}
