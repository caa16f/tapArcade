using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMeter : MonoBehaviour
{


    float rockMeter;
    GameObject needle;
    // Start is called before the first frame update
    void Start()
    {
        needle = transform.Find("Needle").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        rockMeter = PlayerPrefs.GetInt("RockMeter");

        needle.transform.localPosition = new Vector3((rockMeter-25)/52, 0, 0);
    }
}
