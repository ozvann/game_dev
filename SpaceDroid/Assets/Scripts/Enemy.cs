using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float attack = 1.0f;
    [SerializeField] private float impactForce = 8.0f;
    [SerializeField] private float life = 5.0f;
    [SerializeField] private Transform lifeBar;

    private Rigidbody enemyRb;
    private float maximumLife;
    private Vector3 lifeBarInitialScale;

    void Awake()
    {
        maximumLife = life;

        if (lifeBar != null)
        {
            lifeBarInitialScale = lifeBar.localScale;
        }
    }

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
        UpdateLifeBar();

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateLifeBar()
    {
        if (lifeBar == null || maximumLife <= 0.0f)
        {
            return;
        }

        float lifeRatio = Mathf.Clamp01(life / maximumLife);
        lifeBar.localScale = new Vector3(
            lifeBarInitialScale.x,
            lifeBarInitialScale.y * lifeRatio,
            lifeBarInitialScale.z);
    }

    private void DestroyDroidIfDead(StatsDroid droid)
    {
        if (droid.life <= 0)
        {
            droid.Die();
        }
    }
}
