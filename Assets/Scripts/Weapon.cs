using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float offset;
    public GameObject shoot;
    public Transform shotPoint;
    public float timeBtwnShots;
    public float startTimeBtwnShots;

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ); //+ offset);
        if (timeBtwnShots <= 0 && Input.GetMouseButton(0))
        {
            Instantiate(shoot, shotPoint.position, transform.rotation);
            timeBtwnShots = startTimeBtwnShots;
        }
        else
        {
            timeBtwnShots -= Time.deltaTime;
        }

    }
}
