using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    public GameObject Note;
    private GameObject TargetS;
    private GameObject TargetD;
    private GameObject TargetF;
    private GameObject TargetSpace;
    private GameObject TargetJ;
    private GameObject TargetK;
    private GameObject TargetL;


    // Start is called before the first frame update
    void Start()
    {
        TargetS = GameObject.Find("TargetS");
        TargetD = GameObject.Find("TargetD");
        TargetF = GameObject.Find("TargetF");
        TargetSpace = GameObject.Find("TargetSpace");
        TargetJ = GameObject.Find("TargetJ");
        TargetK = GameObject.Find("TargetK");
        TargetL = GameObject.Find("TargetL");
        StartCoroutine(Spawning());
    }
    IEnumerator Spawning()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            //Debug.Log("0:" + noteLogic[0] + ", 1:" + noteLogic[1] + ", 2:" + noteLogic[2] + ", 3:" + noteLogic[3] + ", 4:" + noteLogic[4] + ", 5:" + noteLogic[5] + ", 6:" + noteLogic[6]);
            if (NoteLogic.noteLogic[0] == true) //S
            {
                gameObject.transform.rotation = Quaternion.LookRotation((TargetS.transform.position - gameObject.transform.position), Vector3.up);
                Quaternion currentRotation = gameObject.transform.rotation;
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, currentRotation.eulerAngles.x);
                Instantiate(Note, gameObject.transform.position, gameObject.transform.rotation);
                NoteLogic.noteLogic[0] = false;
            }
            if (NoteLogic.noteLogic[1] == true) //D
            {
                gameObject.transform.rotation = Quaternion.LookRotation((TargetD.transform.position - gameObject.transform.position), Vector3.up);
                Quaternion currentRotation = gameObject.transform.rotation;
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, currentRotation.eulerAngles.x);
                Instantiate(Note, gameObject.transform.position, gameObject.transform.rotation);
                NoteLogic.noteLogic[1] = false;
            }
            if (NoteLogic.noteLogic[2] == true) //F
            {
                gameObject.transform.rotation = Quaternion.LookRotation((TargetF.transform.position - gameObject.transform.position), Vector3.up);
                Quaternion currentRotation = gameObject.transform.rotation;
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, currentRotation.eulerAngles.x);
                Instantiate(Note, gameObject.transform.position, gameObject.transform.rotation);
                NoteLogic.noteLogic[2] = false;
            }
            if (NoteLogic.noteLogic[3] == true) //Space
            {
                gameObject.transform.rotation = Quaternion.LookRotation((TargetSpace.transform.position - gameObject.transform.position), Vector3.up);
                Quaternion currentRotation = gameObject.transform.rotation;
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, currentRotation.eulerAngles.x);
                Instantiate(Note, gameObject.transform.position, gameObject.transform.rotation);
                NoteLogic.noteLogic[3] = false;
            }
            if (NoteLogic.noteLogic[4] == true) //J
            {
                gameObject.transform.rotation = Quaternion.LookRotation((TargetJ.transform.position - gameObject.transform.position), Vector3.up);
                Quaternion currentRotation = gameObject.transform.rotation;
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, (currentRotation.eulerAngles.x * -1) + 180);
                Instantiate(Note, gameObject.transform.position, gameObject.transform.rotation);
                NoteLogic.noteLogic[4] = false;
            }
            if (NoteLogic.noteLogic[5] == true) //K
            {
                gameObject.transform.rotation = Quaternion.LookRotation((TargetK.transform.position - gameObject.transform.position), Vector3.up);
                Quaternion currentRotation = gameObject.transform.rotation;
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, (currentRotation.eulerAngles.x * -1) + 180);
                Instantiate(Note, gameObject.transform.position, gameObject.transform.rotation);
                NoteLogic.noteLogic[5] = false;
            }
            if (NoteLogic.noteLogic[6] == true) //L
            {
                gameObject.transform.rotation = Quaternion.LookRotation((TargetL.transform.position - gameObject.transform.position), Vector3.up);
                Quaternion currentRotation = gameObject.transform.rotation;
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, (currentRotation.eulerAngles.x * -1) + 180);
                Instantiate(Note, gameObject.transform.position, gameObject.transform.rotation);
                NoteLogic.noteLogic[6] = false;
            }
            yield return new WaitForSeconds(0.00002267573f);
        }
        
    }
}