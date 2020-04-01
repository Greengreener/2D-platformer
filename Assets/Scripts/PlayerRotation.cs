using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public GameObject playerGFX;

    public float rotZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (rotZ <= -90 || rotZ > 90)
        {

            playerGFX.transform.eulerAngles = new Vector3(0, 180, 0);
        }


        else
        {
            playerGFX.transform.eulerAngles = new Vector3(0, 0, 0);

        }
    }
}
