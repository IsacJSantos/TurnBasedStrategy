using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void Update()
    {
        Vector3 inputMoveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDir.z = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDir.z = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDir.x = +1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDir.x = -1;
        }

        Vector3 moveDirection = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x;
        float moveSpeed = 10f;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        Vector3 rotationVector = Vector3.zero;

        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector.y = +1;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationVector.y = -1;
        }

        float rotationSpeed = 100f;
        transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime;
    }
}
