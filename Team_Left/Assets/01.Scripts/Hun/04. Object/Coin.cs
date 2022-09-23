using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public  int DropMoney;

    private Vector3 StartVector;
    private Vector3 EndVector;
    
    [Header("Drop")]
    public float Height;
    public float HeightSpeed;
    public float RotateSpeed;
    
    private void Start()
    {
        transform.Rotate(90, 0, 0);
        StartVector = transform.position;
        EndVector = transform.position;
        EndVector.y += Height;

        StartCoroutine(MoveCoin());
        StartCoroutine(RotateCoin());
    }

    private IEnumerator RotateCoin()
    {
        while (true)
        {
            transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator MoveCoin()
    {
        while (transform.position != EndVector)
        {
            transform.position = Vector3.MoveTowards(transform.position, EndVector, HeightSpeed * Time.deltaTime);
            yield return null;
        }
        while (transform.position != StartVector)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartVector, HeightSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
