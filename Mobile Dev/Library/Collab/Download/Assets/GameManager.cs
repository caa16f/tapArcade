using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int multi = 1;
    int streak = 0;


    public GameObject explosion;

    public GameObject startAnimation;

    void Start()
    {
        GameObject clone = (GameObject)Instantiate(startAnimation, new Vector3(0, 0, 0), Quaternion.identity);
        clone.transform.localScale = new Vector3(6, 6, 0);
        Destroy(clone, 3.0f);


        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("RockMeter", 25);
    }

  


    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        resetStreak();
        GameObject clone = (GameObject)Instantiate(explosion, new Vector3(coll.transform.position.x, -5, 0), Quaternion.identity);
        clone.transform.localScale = new Vector3(3, 3, 0);
        Destroy(clone, 1.0f);


        if (coll.gameObject.tag == "Note")
        {
            GameObject note = coll.gameObject;
            Destroy(note, 0.0f);
      
        }
    }


    public int GetScore()
    {
        return 100 * multi;
    }

    public void addStreak()
    {
        if (PlayerPrefs.GetInt("RockMeter") +1 < 50)
        {
            PlayerPrefs.SetInt("RockMeter", PlayerPrefs.GetInt("RockMeter") + 1);
        }
  
        streak++;
        if (streak >= 24)
            multi = 4;
        else if (streak >= 16)
            multi = 3;
        else if (streak >= 8)
            multi = 2;
        else
            multi = 1;
        UpdateGIU();
    }

    public void resetStreak()
    {
        if(PlayerPrefs.GetInt("RockMeter") > 0) 
                  PlayerPrefs.SetInt("RockMeter", PlayerPrefs.GetInt("RockMeter") -2);
        if(PlayerPrefs.GetInt("RockMeter") < 0)
        {
            Lose();
        }
        streak = 0;
        multi = 1;
        UpdateGIU();
    }


    public void Lose()
    {
        print("You lose");
    }

    public void Win()
    {
        print("You Won");
    }

    void UpdateGIU()
    {
        PlayerPrefs.SetInt("Streak", streak);
        PlayerPrefs.SetInt("Mult", multi);
    }
}
