using UnityEngine;

public class CollectDroid : MonoBehaviour
{
    private MoveDroid moveDroid;

    private int collectCount = 0;
    private const int collectThreshold = 5;

    private bool isBoosted = false;
    private float boostTimer = 0f;
    private const float boostDuration = 10f;

    void Start()
    {
        moveDroid = GetComponent<MoveDroid>();
    }

    void Update()
    {
        if (isBoosted)
        {
            boostTimer -= Time.deltaTime;

            if (boostTimer <= 0f)
            {
                EndBoost();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            collectCount++;

            if (collectCount >= collectThreshold && !isBoosted)
            {
                StartBoost();
                collectCount = 0;
            }
        }
    }

    void StartBoost()
    {
        isBoosted = true;
        boostTimer = boostDuration;

        moveDroid.speed *= 2f;
        moveDroid.jumpForce *= 2f;
    }

    void EndBoost()
    {
        isBoosted = false;

        moveDroid.speed /= 2f;
        moveDroid.jumpForce /= 2f;
    }
}