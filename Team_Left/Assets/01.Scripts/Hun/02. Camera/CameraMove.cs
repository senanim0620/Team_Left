using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Camera Target")]
    public GameObject Target;           // ī�޶� ����ٴ� ��ǥ

    [Header("Camera Speed")]
    public float CameraSpeed = 0.0f;    // ī�޶��� �ӵ�

    [Header("Camera Distance")]
    public float DistanceLimit = 0.0f;  // ī�޶��� �ӵ��� ������ �Ÿ�
    public float CameraMaxSpeed = 0.0f; // ī�޶��� �ְ�ӵ�
    public float AccelSpeed = 0.0f;     // ī�޶��� ���ӵ�

    [Header("Camera Offset")]
    public float offsetX = 0.0f;        // ī�޶��� x��ǥ
    public float offsetY = 0.0f;        // ī�޶��� y��ǥ
    public float offsetZ = 0.0f;        // ī�޶��� z��ǥ

    [Header("Camera Angle")]
    public float angleX = 0.0f;         // ī�޶��� x����
    public float angleY = 0.0f;         // ī�޶��� y����
    public float angleZ = 0.0f;         // ī�޶��� z����

    private Vector3 TargetPos;          // Ÿ���� ��ġ
    float saveCameraSpeed;

    private void Awake()
    {
        saveCameraSpeed = CameraSpeed;
    }

    void FixedUpdate()
    {

        // Ÿ���� x, y, z ��ǥ�� ī�޶��� ��ǥ�� ���Ͽ� ī�޶��� ��ġ�� ����
        TargetPos = new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ
            );

        // ī�޶� ���� ����
        transform.rotation = Quaternion.Euler(angleX, angleY, angleZ);

        //�Ÿ��� ���� �ӵ� �ٲٱ�
        float Distance = Vector3.Distance(transform.position, TargetPos);
        if (Distance >= DistanceLimit)
        {
            StartCoroutine(SetCameraSpeed(CameraMaxSpeed, AccelSpeed));
        }
        else if (CameraSpeed != saveCameraSpeed)
        {
            StartCoroutine(SetCameraSpeed(saveCameraSpeed, AccelSpeed));
        }

        // ī�޶��� �������� �ε巴�� �ϴ� �Լ�(Lerp)
        // ī�޶��� �̵�(MoveTowards)
        transform.position = Vector3.MoveTowards(transform.position, TargetPos, Time.deltaTime * CameraSpeed);

    }

    private IEnumerator SetCameraSpeed(float Speed, float Accel)
    {
        StopAllCoroutines();

        if (Speed > CameraSpeed)
        {
            while (Speed >= CameraSpeed)
            {
                CameraSpeed += Accel * Time.deltaTime;
                yield return null;
            }
        }
        else if (Speed < CameraSpeed)
        {
            while (Speed <= CameraSpeed)
            {
                CameraSpeed -= Accel * Time.deltaTime;
                yield return null;
            }
        }
    }
}
