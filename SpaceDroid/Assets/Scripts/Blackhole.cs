using UnityEngine;

public class BlackHole : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("EnemyDetection"))
        {
            Destroy(other.gameObject);
        }
    }
}