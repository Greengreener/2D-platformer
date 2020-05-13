using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KeyBinds : MonoBehaviour
{
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Text left, right, jump, sprint, fall;
    public GameObject currentKey;
    public Color32 changed = new Color32(39, 171, 249, 255);
    public Color32 selected = new Color32(239, 116, 36, 255);

    void Start()
    {
        keys.Clear();
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));
        keys.Add("Sprint", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Sprint", "LeftShift")));
        keys.Add("Fall", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Fall", "S")));

        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        jump.text = keys["Jump"].ToString();
        sprint.text = keys["Sprint"].ToString();
        fall.text = keys["Fall"].ToString();
    }
    private void OnGUI()
    {
        if (currentKey != null)
        {
            string newKey = "";
            Event e = Event.current;
            if (e.isKey)
            {
                newKey = e.keyCode.ToString();
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                newKey = "LeftShift";
            }
            if (Input.GetKey(KeyCode.RightShift))
            {
                newKey = "RightShift";
            }

            if (newKey != "")
            {
                keys[currentKey.name] = (KeyCode)System.Enum.Parse(typeof(KeyCode), newKey);
                currentKey.GetComponentInChildren<Text>().text = newKey;
                currentKey.GetComponent<Image>().color = changed;
                currentKey = null;
            }
        }

    }
    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;

        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = selected;
        }
    }
    public void SaveKeys()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }
}
