using UnityEngine;

public class FollowDroid : MonoBehaviour
{
    [SerializeField]
    private GameObject droid;
    [SerializeField]
    private Vector3 offset;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void LateUpdate(){
        transform.position = droid.transform.position + offset;
    }
}
