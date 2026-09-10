using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveDroid : MonoBehaviour
{
    private InputAction jumpAction;
    private InputAction attackGAction;
    private InputAction attackHAction;
    private Rigidbody rb;
    private bool jumpKeyWasPressed = false;
    private InputAction moveAction;
    private bool isGrounded = false;
    private LinearMovement currentPlatform;
    private Vector3 previousPlatformPosition;
    private float lastHorizontalDirection = 1.0f;
    private bool isCoolingDownG;
    private bool isCoolingDownH;
    public float speed = 15.0f;
    public float jumpForce = 9.5f;
    [SerializeField] private GameObject grenadePrefab;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float coolDownG = 1.0f;
    [SerializeField] private float coolDownH = 0.25f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpAction = InputSystem.actions.FindAction("Jump");
        attackGAction = InputSystem.actions.FindAction("AttackG");
        attackHAction = InputSystem.actions.FindAction("AttackH");
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        if(jumpAction.triggered) {
            jumpKeyWasPressed = true;
        }
        Vector2 move = moveAction.ReadValue<Vector2>();
        transform.Translate(Vector3.right * move[0] * speed * Time.deltaTime);

        if (Mathf.Abs(move[0]) > 0.01f)
        {
            lastHorizontalDirection = Mathf.Sign(move[0]);
        }

        if (attackGAction != null && attackGAction.triggered)
        {
            StartCoroutine(FireG());
        }

        if (attackHAction != null && attackHAction.triggered)
        {
            StartCoroutine(FireH());
        }
    }

    private IEnumerator FireG()
    {
        if (!isCoolingDownG && grenadePrefab != null)
        {
            GameObject grenade = Instantiate(grenadePrefab, transform.position, grenadePrefab.transform.rotation);
            ConfigureWeapon(grenade);
            isCoolingDownG = true;
            yield return new WaitForSeconds(coolDownG);
            isCoolingDownG = false;
        }
    }

    private IEnumerator FireH()
    {
        if (!isCoolingDownH && laserPrefab != null)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, laserPrefab.transform.rotation);
            ConfigureWeapon(laser);
            isCoolingDownH = true;
            yield return new WaitForSeconds(coolDownH);
            isCoolingDownH = false;
        }
    }

    private void ConfigureWeapon(GameObject weapon)
    {
        WeaponWithPhysics physicsWeapon = weapon.GetComponent<WeaponWithPhysics>();
        if (physicsWeapon != null)
        {
            physicsWeapon.SetOwner(GetComponent<StatsDroid>());
            physicsWeapon.SetDirection(lastHorizontalDirection);
        }

        WeaponWithoutPhysics laserWeapon = weapon.GetComponent<WeaponWithoutPhysics>();
        if (laserWeapon != null)
        {
            laserWeapon.SetOwner(GetComponent<StatsDroid>());
            laserWeapon.SetDirection(lastHorizontalDirection);
        }
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
