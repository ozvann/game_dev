using UnityEngine;

public class ReverseCamera : MonoBehaviour
{
    private GameObject mainCamera;
    private bool isReversed = false;

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isReversed)
            {
                mainCamera.transform.Rotate(0f, 0f, 180f);
            }
            else
            {
                mainCamera.transform.Rotate(0f, 0f, -180f);
            }
        }
    }
}