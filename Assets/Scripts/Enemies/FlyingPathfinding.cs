using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingPathfinding : MonoBehaviour
{
    public GameObject[] waypoints;
    public int currentWP = 0;
    public float speed = 5;
    public GameObject player;

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        Patrol();
    }
    private void Patrol()
    {
        if (currentWP >= waypoints.Length)
        {
            currentWP = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWP].transform.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[currentWP].transform.position) < 0.01f)
        {
            currentWP = currentWP + 1;
        }
    }
}