using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTest : MonoBehaviour
{
    void Start()
    {
        Vector3 v3 = new Vector3(1, 2,1);
        //Debug.Log("Vector2 is: " + v2);

        // convert v2 to v3
        Vector2 v2 = v3;
        Debug.Log("Vector3 is: " + v3);
        Debug.Log("Vector2 is: " + v2);
        // convert v3 to new Vector3
        //Debug.Log("Set v3 to (3, 4, 5)");
        //  v3 = new Vector3(3, 4, 5);

        // convert v3 to v2
        //   v2 = v3;
        //   Debug.Log("Vector2 is: " + v2);
    }
}
