using UnityEngine;

public class StatsDroid : MonoBehaviour
{
    public float life = 10.0f;
    public float attack = 2.0f;
    [SerializeField] private float fallDeathHeight = -10.0f;

    private bool isDead;

    private void Update()
    {
        if (transform.position.y < fallDeathHeight)
        {
            Die();
        }
    }

    public void Die()
    {
        if (isDead)
        {
            return;
        }

        isDead = true;
        GameManager.GameOver();
        Destroy(gameObject);
    }
}