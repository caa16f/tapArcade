using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setVolume : MonoBehaviour
{

    // Reference to Audio Source component
    private AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        // Assign Audio Source component to control it
        PlayerPrefs.SetFloat("Volume" , 1f);

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = PlayerPrefs.GetFloat("Volume");
    }
}
