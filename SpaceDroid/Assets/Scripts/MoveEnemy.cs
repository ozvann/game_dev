using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private GameObject enemy;

    private Rigidbody enemyRb;

    void Start()
    {
        enemyRb = enemy.GetComponent<Rigidbody>();
    }

    void OnTriggerStay(Collider other)
    {
        StatsDroid droid = other.GetComponentInParent<StatsDroid>();

        if (droid == null || !droid.gameObject.CompareTag("Player") || enemyRb == null)
        {
            return;
        }

        Vector3 direction = (droid.transform.position - enemy.transform.position).normalized;
        enemyRb.AddForce(direction * speed);
    }
}
