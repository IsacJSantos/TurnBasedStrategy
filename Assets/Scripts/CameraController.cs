using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera cinemachineVirtualCamera;


    CinemachineTransposer cinemachineTransposer;
    Vector3 targetFollowOffset;


    private const float MIN_FOLLOW_Y_OFFSET = 2f;
    private const float MAX_FOLLOW_Y_OFFSET = 12f;

    private void Start()
    {
        cinemachineTransposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        targetFollowOffset = cinemachineTransposer.m_FollowOffset;
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleZoom();

    }

    private void HandleMovement()
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
    }
    private void HandleRotation()
    {
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
    private void HandleZoom()
    {

        float zoomAmount = 1f;

        if (Input.mouseScrollDelta.y > 0)
        {
            targetFollowOffset.y -= zoomAmount;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            targetFollowOffset.y += zoomAmount;
        }


        float zoomSpeed = 5f; ;

        targetFollowOffset.y = Mathf.Clamp(targetFollowOffset.y, MIN_FOLLOW_Y_OFFSET, MAX_FOLLOW_Y_OFFSET);
        cinemachineTransposer.m_FollowOffset =
            Vector3.Lerp(cinemachineTransposer.m_FollowOffset, targetFollowOffset, Time.deltaTime * zoomSpeed);
    }

}