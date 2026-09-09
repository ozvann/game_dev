using UnityEngine;
using UnityEngine.InputSystem;

public class MoveDroid : MonoBehaviour
{
    private InputAction jumpAction;
    private Rigidbody rb;
    private bool jumpKeyWasPressed = false;
    private InputAction moveAction;
    private bool isGrounded = false;
    public float speed = 15.0f;
    public float jumpForce = 9.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpAction = InputSystem.actions.FindAction("Jump");
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        if(jumpAction.triggered) {
            jumpKeyWasPressed = true;
        }
        Vector2 move = moveAction.ReadValue<Vector2>();
        transform.Translate(Vector3.right * move[0] * speed * Time.deltaTime);
    }

    void FixedUpdate() {
        if (jumpKeyWasPressed && isGrounded) {
	        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
        jumpKeyWasPressed = false;
    }

    void OnCollisionEnter() {
        isGrounded = true;
    }
    
    void OnCollisionExit() {
        isGrounded = false;
    }
}
