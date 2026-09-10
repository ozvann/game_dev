using UnityEngine;

public class WeaponWithPhysics : MonoBehaviour
{
    [SerializeField] private Vector3 initialImpulse = new Vector3(10.0f, 7.0f, 0.0f);
    [SerializeField] private float weaponMultiplicator = 1.0f;
    [SerializeField] private float lifeTime = 8.0f;

    private Rigidbody rb;
    private StatsDroid owner;
    private Collider weaponCollider;
    private float horizontalDirection = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        weaponCollider = GetComponent<Collider>();
        rb.useGravity = true;
        initialImpulse.x = Mathf.Abs(initialImpulse.x) * horizontalDirection;
        rb.AddForce(initialImpulse, ForceMode.Impulse);
        StartCoroutine(DestroyAfterLifetime());
    }

    public void SetOwner(StatsDroid droid)
    {
        owner = droid;
    }

    public void SetDirection(float direction)
    {
        horizontalDirection = direction < 0.0f ? -1.0f : 1.0f;
    }

    private System.Collections.IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<StatsDroid>() == owner && weaponCollider != null)
        {
            weaponCollider.isTrigger = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        HitEnemy(other);
    }

    void OnCollisionEnter(Collision collision)
    {
        HitEnemy(collision.collider);
    }

    private void HitEnemy(Collider other)
    {
        if (other.CompareTag("EnemyDetection"))
        {
            return;
        }

        Enemy enemy = other.GetComponentInParent<Enemy>();
        if (enemy == null)
        {
            return;
        }

        if (owner != null)
        {
            enemy.TakeDamage(owner.attack * weaponMultiplicator);
        }

        Destroy(gameObject);
    }
}