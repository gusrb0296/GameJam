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

        // ���� ī�޶��� ��ġ�� ���� ī�޶� ��ġ�� ���Ͽ� �̵� �Ÿ��� ����մϴ�.
        Vector3 currentCameraPosition = Camera.main.transform.position;
        Vector3 moveDirection = currentCameraPosition - previousCameraPosition;

        // �̵� ���⿡ ���� ������Ʈ�� �̵��մϴ�.
        if (moveDirection != Vector3.zero)
        {
            transform.Translate(moveDirection * 0.25f);
        }

        // ���� ī�޶� ��ġ�� ���� ī�޶� ��ġ�� ������Ʈ�մϴ�.
        previousCameraPosition = currentCameraPosition;
    }
}
