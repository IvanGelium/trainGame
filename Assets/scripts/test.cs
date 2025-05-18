using UnityEngine;
using UnityEngine.InputSystem;

public class test : MonoBehaviour
{
    InputAction moveAction;
    InputAction jumpAction;
    float speed = 250000f;
    public Rigidbody rigidBody;
    public bool IsGrounded = false;

    bool IsGroundedCheck()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1f);
    }

    Vector3 Vector2ToVector3(Vector2 vector)
    {
        return new Vector3(vector.x * speed * Time.deltaTime, 0, vector.y * speed * Time.deltaTime);
    }

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        IsGrounded = IsGroundedCheck();
    }

    void FixedUpdate()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        Vector3 moveValueVector3 = Vector2ToVector3(moveValue);
        rigidBody.AddForce(moveValueVector3);
    }

    void Update() { }
}
