using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClickDetector : MonoBehaviour
{
    [SerializeField]
    GameObject main;
    [SerializeField]
    GameObject songSelect;
    [SerializeField]
    GameObject options;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button button7;
    public Button button8;

    public Button button12;

    void OnEnable()
    {
        //Register Button Events
        button1.onClick.AddListener(() => buttonCallBack(button1));
        button2.onClick.AddListener(() => buttonCallBack(button2));
        button3.onClick.AddListener(() => buttonCallBack(button3));
        button4.onClick.AddListener(() => buttonCallBack(button4));
        button5.onClick.AddListener(() => buttonCallBack(button5));
        button6.onClick.AddListener(() => buttonCallBack(button6));
        button7.onClick.AddListener(() => buttonCallBack(button7));
        button8.onClick.AddListener(() => buttonCallBack(button8));
       
        button12.onClick.AddListener(() => buttonCallBack(button12));

    }

    private void buttonCallBack(Button buttonPressed)
    {
        if (buttonPressed == button1)
        {
            main.SetActive(false);
            songSelect.SetActive(true);
            Debug.Log("Clicked: " + button1.name);
        }

        if (buttonPressed == button2)
        {
            main.SetActive(false);
            options.SetActive(true);
            Debug.Log("Clicked: " + button2.name);
        }

        if (buttonPressed == button3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
            Debug.Log("Clicked: " + button3.name);
        }
        if (buttonPressed == button4)
        {
            SceneManager.LoadScene("game_song3");
          Debug.Log("Clicked: " + button4.name);
        }
        if (buttonPressed == button5)
        {
            SceneManager.LoadScene("game_song1");
            Debug.Log("Clicked: " + button5.name);
        }
        if (buttonPressed == button6)
        {
            SceneManager.LoadScene("game_song4");
            Debug.Log("Clicked: " + button6.name);
        }
        if (buttonPressed == button7)
        {
            SceneManager.LoadScene("game_song2");
            Debug.Log("Clicked: " + button7.name);
        }
        if (buttonPressed == button8)
        {
            songSelect.SetActive(false);
            main.SetActive(true);
            

            Debug.Log("Clicked: " + button8.name);
        }
      
        if (buttonPressed == button12)
        {
            options.SetActive(false);
            main.SetActive(true);
            Debug.Log("Clicked: " + button12.name);
        }
    }

    void OnDisable()
    {
        //Un-Register Button Events
        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();
        button3.onClick.RemoveAllListeners();
        button4.onClick.RemoveAllListeners();
        button5.onClick.RemoveAllListeners();
        button6.onClick.RemoveAllListeners();
        button7.onClick.RemoveAllListeners();
        button8.onClick.RemoveAllListeners();
       
        button12.onClick.RemoveAllListeners();

    }
}
