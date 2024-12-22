using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticalBehaviour : MonoBehaviour
{
    public float sizeIncreaseAmount = 1.0f;
    public float sizeIncreaseDuration = 1.0f;
    public float lifespan = 3.0f;

    public Color color1;
    private SpriteRenderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        StartCoroutine(IncreaseSize());
        StartCoroutine(DestroyObject());
        
    }

    IEnumerator IncreaseSize()
    {
        float t = 0.0f;
        Vector3 originalScale = transform.localScale;

        while (t < sizeIncreaseDuration)
        {
            t += Time.deltaTime;
            color1 = render.color;
            color1.a -= Time.deltaTime * 2f;
            render.color = color1;
            float scale = Mathf.Lerp(originalScale.x, originalScale.x + sizeIncreaseAmount, t / sizeIncreaseDuration);
            transform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }

    }
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }

}
