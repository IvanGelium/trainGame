using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    //Git Push
    InputAction moveAction;
    InputAction jumpAction;
    InputAction sprintAction;
    bool isGrounded = false;
    public Rigidbody rigidBody;
    public float initSpeed = 250000f;
    public float sprintAccelerarion = 2f;
    public float initFallSpeed = 10000f;
    public float fallAcceleration = 50000f;
    public float sphereCastRadius = 0.4f;
    public float gravityScale = 1f;

    private float fallSpeed;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(
            new Vector3(transform.position.x, transform.position.y - 0.75f, transform.position.z),
            sphereCastRadius
        );
    }

    bool IsGroundedCheck()
    {
        return Physics.SphereCast(
            transform.position,
            sphereCastRadius,
            Vector3.down,
            out RaycastHit hitinfo,
            0.75f
        );
    }

    void Fall()
    {
        if (isGrounded)
        {
            fallSpeed = initFallSpeed;
        }
        if (!isGrounded)
        {
            fallSpeed -=
                (initFallSpeed + fallAcceleration) * Time.fixedDeltaTime * -1f * gravityScale;
            rigidBody.AddForce(Vector3.down * Math.Max(fallSpeed, -500000f));
        }
    }

    void PlaneMove()
    {
        //Добавить ускорение
        float speed;
        if (sprintAction.IsPressed())
        {
            speed = initSpeed * sprintAccelerarion;
        }
        else
        {
            speed = initSpeed;
        }
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        Vector3 moveValueVector3 = Vector2ToVector3(moveValue, speed);
        rigidBody.AddForce(moveValueVector3);
    }

    Vector3 Vector2ToVector3(Vector2 vector, float speed)
    {
        return new Vector3(
            vector.x * speed * Time.fixedDeltaTime,
            0,
            vector.y * speed * Time.fixedDeltaTime
        );
    }

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        sprintAction = InputSystem.actions.FindAction("Sprint");
        isGrounded = IsGroundedCheck();
    }

    void FixedUpdate()
    {
        isGrounded = IsGroundedCheck();
        Fall();
        PlaneMove();
    }

    void Update() { }
}
