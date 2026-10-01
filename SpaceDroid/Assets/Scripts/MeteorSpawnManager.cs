using System.Collections;
using UnityEngine;

public class MeteorSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private float rangeX = 10.0f;
    [SerializeField] private float minTime = 1.0f;
    [SerializeField] private float maxTime = 3.0f;

    private void Start()
    {
        StartCoroutine(SpawnMeteors());
    }

    private IEnumerator SpawnMeteors()
    {
        while (true)
        {
            float delay = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(delay);

            if (meteorPrefab == null)
            {
                continue;
            }

            float halfRange = Mathf.Abs(rangeX) * 0.5f;
            float randomX = Random.Range(transform.position.x - halfRange, transform.position.x + halfRange);
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

            Instantiate(meteorPrefab, spawnPosition, meteorPrefab.transform.rotation);
        }
    }
}
