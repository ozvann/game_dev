using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float attack = 1.0f;
    [SerializeField] private float impactForce = 8.0f;
    [SerializeField] private float life = 5.0f;

    private Rigidbody enemyRb;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        StatsDroid droid = collision.gameObject.GetComponentInParent<StatsDroid>();

        if (droid == null)
        {
            return;
        }

        Vector3 direction = (transform.position - droid.transform.position).normalized;
        enemyRb.AddForce(direction * impactForce, ForceMode.Impulse);

        Rigidbody droidRb = droid.GetComponent<Rigidbody>();
        if (droidRb != null)
        {
            droidRb.AddForce(-direction * impactForce, ForceMode.Impulse);
        }

        droid.life -= attack;
        DestroyDroidIfDead(droid);
    }

    public void TakeDamage(float damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void DestroyDroidIfDead(StatsDroid droid)
    {
        if (droid.life <= 0)
        {
            Destroy(droid.gameObject);
        }
    }
}
