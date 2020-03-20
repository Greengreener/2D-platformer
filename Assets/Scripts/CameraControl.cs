using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform currentPos;
    public Transform playerPos;
    public Vector3 currentVec;
    public float cameraSpeed = 10f;

    private void Start()
    {
        currentVec = currentPos.position;
    }
    private void Update()
    {

    }
    void FixedUpdate()
    {
        currentPos.position = new Vector3(Mathf.Clamp(currentPos.position.x, playerPos.position.x - 10, playerPos.position.x + 10), Mathf.Clamp(currentPos.position.y, playerPos.position.y - 2, playerPos.position.y + 2), 0);
        transform.position = Vector3.Lerp(currentPos.position, playerPos.position, 5f * Time.fixedDeltaTime);

    }
}