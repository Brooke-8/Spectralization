using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VisualizationPixelHit : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        SpriteRenderer otherRenderer = other.GetComponent<SpriteRenderer>();
        int x = other.GetComponent<PixelCoords>().xCoord;
        int y =other.GetComponent<PixelCoords>().yCoord;
        if (other.tag == "VisualizationPixel" && y > 0)
        {
            if (CreatePixelGrid.pixelGrid[x, y - 1].GetComponent<SpriteRenderer>().color == KeyPress.pixelC)
            {
                otherRenderer.color = KeyPress.pixelC;
            }
            else
            {
                otherRenderer.color = new Color(1f, 1f, 1f, 1f);
                CreatePixelGrid.grid[other.GetComponent<PixelCoords>().xCoord, other.GetComponent<PixelCoords>().yCoord] = 1;
            }
        }
    }
   
    private void OnTriggerExit2D(Collider2D other)
    {
        SpriteRenderer otherRenderer = other.GetComponent<SpriteRenderer>();
        if (other.tag == "VisualizationPixel")
        {
            //Debug.Log("Exited trigger with: " + other.gameObject.name);
            otherRenderer.color = new Color(1f, 1f, 1f, 0f);
            CreatePixelGrid.grid[other.GetComponent<PixelCoords>().xCoord, other.GetComponent<PixelCoords>().yCoord] = 0;
        }
    }

}
