using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform currentPos;
    public Transform playerPos;
    public new Vector3 currentVec;
    public float cameraSpeed = 10f;

    private void Start()
    {
        currentVec = currentPos.position;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(currentPos.position, playerPos.position, 5f * Time.fixedDeltaTime);
    }
}