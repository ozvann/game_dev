using UnityEngine;

public class Meteorite : MonoBehaviour
{
    private Rigidbody rb;
    private float rotationSpeed = 100.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("blackhole") || other.CompareTag("EnemyDetection"))
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(-5f, -0.7f, 0f), ForceMode.Acceleration);
        transform.Rotate(rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime);
    }

}