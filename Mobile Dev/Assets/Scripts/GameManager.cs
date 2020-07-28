using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    int multi = 1;
    int streak = 0;


    public GameObject explosion;

    public GameObject startAnimation;

    [SerializeField]
    string winScreen;

    [SerializeField]
    string loseScreen;



    void Start()
    {
        
        

        GameObject clone = (GameObject)Instantiate(startAnimation, new Vector3(0, 0, 0), Quaternion.identity);
        clone.transform.localScale = new Vector3(6, 6, 0);
        Destroy(clone, 3.0f);

      
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("RockMeter", 25);
        PlayerPrefs.SetInt("HighStreak", 0);
        PlayerPrefs.SetInt("Streak", 0);
        PlayerPrefs.SetInt("Mult", 1);
        PlayerPrefs.SetInt("NotesHit", 0);
        PlayerPrefs.SetInt("TotalNotes", 0);
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
        PlayerPrefs.SetInt("TotalNotes", PlayerPrefs.GetInt("TotalNotes") + 1);

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

        if(streak > PlayerPrefs.GetInt("HighStreak")){
            PlayerPrefs.SetInt("HighStreak", streak);
        }

        PlayerPrefs.SetInt("NotesHit", PlayerPrefs.GetInt("NotesHit") + 1);

        UpdateGIU();
    }

    public void resetStreak()
    {

         
        if(PlayerPrefs.GetInt("RockMeter") > 0) 
                  PlayerPrefs.SetInt("RockMeter", PlayerPrefs.GetInt("RockMeter") -2);
        if(PlayerPrefs.GetInt("RockMeter") <= 0)
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
        SceneManager.LoadScene(loseScreen);
        PlayerPrefs.SetInt("RockMeter", 25);
    }

    public void Win()
    {
        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;
        PlayerPrefs.SetInt("RockMeter", 25);
        if (sceneName == "game_song1")
        {
            if (PlayerPrefs.GetInt("HighScore1") < PlayerPrefs.GetInt("Score"))
            {
                PlayerPrefs.SetInt("HighScore1", PlayerPrefs.GetInt("Score"));
            }
        }
        else if (sceneName == "game_song2")
        {
            if (PlayerPrefs.GetInt("HighScore2") < PlayerPrefs.GetInt("Score"))
            {
                PlayerPrefs.SetInt("HighScore2", PlayerPrefs.GetInt("Score"));
            }
        }
        else if (sceneName == "game_song3")
        {
            if (PlayerPrefs.GetInt("HighScore3") < PlayerPrefs.GetInt("Score"))
            {
                PlayerPrefs.SetInt("HighScore3", PlayerPrefs.GetInt("Score"));
            }
        }
        else if (sceneName == "game_song4")
        {
            if (PlayerPrefs.GetInt("HighScore4") < PlayerPrefs.GetInt("Score"))
            {
                PlayerPrefs.SetInt("HighScore4", PlayerPrefs.GetInt("Score"));
            }
        }


        SceneManager.LoadScene(winScreen);
    }

    void UpdateGIU()
    {
        PlayerPrefs.SetInt("Streak", streak);
        PlayerPrefs.SetInt("Mult", multi);
    }

  
}
