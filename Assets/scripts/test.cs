using UnityEngine;
using UnityEngine.InputSystem; 

public class test : MonoBehaviour
{
    
    InputAction moveAction;
    InputAction jumpAction;

    private void Start()
    {
        
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        

        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        transform.position = moveValue;


        if (jumpAction.IsPressed())
        {
            Debug.Log("Jump");
        }
    }
}