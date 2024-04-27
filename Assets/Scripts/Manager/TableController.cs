using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    private Vector3 previousCameraPosition;

    private Vector3 initialCameraPosition;

    private void Start()
    {
        initialCameraPosition = Camera.main.transform.position;
        previousCameraPosition = initialCameraPosition;
    }

    private void Update()
    {

        // 현재 카메라의 위치와 이전 카메라 위치를 비교하여 이동 거리를 계산합니다.
        Vector3 currentCameraPosition = Camera.main.transform.position;
        Vector3 moveDirection = currentCameraPosition - previousCameraPosition;

        // 이동 방향에 따라 오브젝트를 이동합니다.
        if (moveDirection != Vector3.zero)
        {
            transform.Translate(moveDirection * 0.25f);
        }

        // 현재 카메라 위치를 이전 카메라 위치로 업데이트합니다.
        previousCameraPosition = currentCameraPosition;
    }
}
