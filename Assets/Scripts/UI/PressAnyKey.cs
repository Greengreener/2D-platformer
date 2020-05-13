using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
    public GameObject pressAnyKeyPanel;
    public GameObject menuPanel;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == 0)
        {
            if (Input.anyKey)
            {
                counter += 1;
                menuPanel.SetActive(true);
                pressAnyKeyPanel.SetActive(false);
            }
        }
    }
}
