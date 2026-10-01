using System.Collections;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [SerializeField] private float lifeTime = 8.0f;
    [SerializeField] private float platformInactiveTime = 2.0f;

    private Rigidbody rb;
    private float rotationSpeed = 100.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("blackhole") || other.CompareTag("EnemyDetection"))
        {
            Destroy(gameObject);
            return;
        }

        StatsDroid droid = other.GetComponentInParent<StatsDroid>();
        if (droid != null)
        {
            droid.Die();
            Destroy(gameObject);
            return;
        }

        Transform platform = other.transform;
        while (platform != null && !platform.CompareTag("Platform"))
        {
            platform = platform.parent;
        }

        if (platform != null)
        {
            platform.gameObject.SetActive(false);
            StartCoroutine(ReactivatePlatform(platform.gameObject));
            return;
        }

        if (other.gameObject != null)
        {
            Destroy(other.gameObject);
        }
    }

    private IEnumerator ReactivatePlatform(GameObject platform)
    {
        yield return new WaitForSeconds(platformInactiveTime);

        if (platform != null)
        {
            platform.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.AddForce(new Vector3(-5f, -0.7f, 0f), ForceMode.Acceleration);
        }

        transform.Rotate(rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime);
    }

}