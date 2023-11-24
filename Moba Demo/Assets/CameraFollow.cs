using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CameraFollow : MonoBehaviour
{
    public Vector3 cameraOffset;
    public Transform player;

    [Range(0.01f, 1.0f)]
    public float smoothness;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = player.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothness);
    }
}
