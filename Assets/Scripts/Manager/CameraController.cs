using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    public GameObject player;

    private void LateUpdate()
    {
        //Vector3 dir = player.transform.position - transform.position;
        //Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        //this.transform.Translate(moveVector);

        Vector3 targetPosition = player.transform.position;
        targetPosition.z = transform.position.z; // 카메라의 z 위치를 유지하려면 이 줄을 추가하세요.

        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    }
}
