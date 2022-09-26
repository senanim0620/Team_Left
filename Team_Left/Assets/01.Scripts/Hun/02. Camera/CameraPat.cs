using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraPat : MonoBehaviour
{
    public GameObject Start;
    public GameObject End;


    private Vector3 StartV;
    private Vector3 EndV;

    private void Awake()
    {
        StartV = Start.transform.position;
        EndV = End.transform.position;

        StartCoroutine(PatCam1());
    }

    IEnumerator PatCam1()
    {
        while (transform.position != EndV)
        {
            transform.position = Vector3.MoveTowards(transform.position, EndV, 2*Time.deltaTime);
            yield return null;
        }
        StartCoroutine(PatCam2());
    }

    IEnumerator PatCam2()
    {
        while (transform.position != StartV)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartV, 2 * Time.deltaTime);
            yield return null;
        }
        StartCoroutine(PatCam1());
    }
}
