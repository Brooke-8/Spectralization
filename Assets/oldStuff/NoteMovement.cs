using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class NoteMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(hitDetection());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);


    }
    IEnumerator hitDetection()
    {
        while (true)
        {

            if (TargetHitDetection.hitting[0] == true && Input.GetKeyDown(KeyCode.S))
            {
                Destroy(gameObject);
            }
            if (TargetHitDetection.hitting[1] == true && Input.GetKeyDown(KeyCode.D))
            {
                Destroy(gameObject);
            }
            if (TargetHitDetection.hitting[2] == true && Input.GetKeyDown(KeyCode.F))
            {
                Destroy(gameObject);
            }
            if (TargetHitDetection.hitting[3] == true && Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(gameObject);
            }
            if (TargetHitDetection.hitting[4] == true && Input.GetKeyDown(KeyCode.J))
            {
                Destroy(gameObject);
            }
            if (TargetHitDetection.hitting[5] == true && Input.GetKeyDown(KeyCode.K))
            {
                Destroy(gameObject);
            }
            if (TargetHitDetection.hitting[6] == true && Input.GetKeyDown(KeyCode.L))
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
