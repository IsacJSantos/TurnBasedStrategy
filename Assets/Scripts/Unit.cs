using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed = 10f;

    [SerializeField]
    private Animator unitAnimator;
    private Vector3 targetPosition;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move(MouseWorld.GetPosition());
        }


        float stoppingDistance = .1f;
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float moveSpeed = 4.0f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;


            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

            unitAnimator.SetBool("IsWalking", true);
        }
        else
        {
            unitAnimator.SetBool("IsWalking", false);
        }

    }
    private void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}
