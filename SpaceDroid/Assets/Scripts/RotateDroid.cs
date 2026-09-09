using UnityEngine;

public class RotateDroid : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 200.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate() {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
