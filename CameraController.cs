using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("ch1");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            float playerX = player.transform.position.x;
            float cameraX = transform.position.x;

            float smoothSpeed = 5f; // ī�޶� �̵� �ӵ� ����

            // �÷��̾�� ī�޶��� x ��ġ�� �����Ͽ� �ε巴�� �̵�
            float newX = Mathf.Lerp(cameraX, playerX, smoothSpeed * Time.deltaTime);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }
}
