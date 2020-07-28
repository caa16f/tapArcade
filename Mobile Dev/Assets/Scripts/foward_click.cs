using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class foward_click : MonoBehaviour
{
    void Update()
    {
        // when part of the screen is tapped load the next scene
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
