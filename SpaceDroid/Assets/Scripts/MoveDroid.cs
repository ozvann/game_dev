using UnityEngine;
using UnityEngine.InputSystem;

public class MoveDroid : MonoBehaviour
{
    private InputAction jumpAction;
    private Rigidbody rb;
    private bool jumpKeyWasPressed = false;
    private InputAction moveAction;
    private bool isGrounded = false;
    private LinearMovement currentPlatform;
    private Vector3 previousPlatformPosition;
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
        if (isGrounded && currentPlatform != null)
        {
            Vector3 platformMovement = currentPlatform.transform.position - previousPlatformPosition;
            rb.position += platformMovement;
            previousPlatformPosition = currentPlatform.transform.position;
        }

        if (jumpKeyWasPressed && isGrounded) {
	        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
        jumpKeyWasPressed = false;
    }

    void OnCollisionEnter(Collision collision) {
        isGrounded = true;
        LinearMovement platform = collision.gameObject.GetComponentInParent<LinearMovement>();

        if (platform != null)
        {
            currentPlatform = platform;
            previousPlatformPosition = currentPlatform.transform.position;
        }
    }
    
    void OnCollisionExit(Collision collision) {
        isGrounded = false;

        if (currentPlatform != null && collision.transform.IsChildOf(currentPlatform.transform))
        {
            currentPlatform = null;
        }
    }
}
