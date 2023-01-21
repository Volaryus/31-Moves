using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Vector3 offset;
    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    float smoothTime = 0.2f;
    [SerializeField]
    float maxSpeed = 5f;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, playerTransform.position + offset, ref velocity, smoothTime, maxSpeed);
    }
}
