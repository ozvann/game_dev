using UnityEngine;

public class BlackHole : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("EnemyDetection"))
        {
            StatsDroid droid = other.GetComponentInParent<StatsDroid>();

            if (droid != null)
            {
                droid.Die();
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}