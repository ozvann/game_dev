using UnityEngine;

public class WeaponWithoutPhysics : MonoBehaviour
{
    [SerializeField] private float speed = 25.0f;
    [SerializeField] private float weaponMultiplicator = 1.0f;
    [SerializeField] private float lifeTime = 5.0f;

    private StatsDroid owner;
    private float horizontalDirection = 1.0f;

    void Start()
    {
        StartCoroutine(DestroyAfterLifetime());
    }

    void Update()
    {
        transform.Translate(Vector3.right * horizontalDirection * speed * Time.deltaTime, Space.World);
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyDetection") || other.CompareTag("Collectible") || (owner != null && other.GetComponentInParent<StatsDroid>() == owner))
        {
            return;
        }

        Enemy enemy = other.GetComponentInParent<Enemy>();
        if (enemy != null && owner != null)
        {
            enemy.TakeDamage(owner.attack * weaponMultiplicator);
        }

        Destroy(gameObject);
    }
}