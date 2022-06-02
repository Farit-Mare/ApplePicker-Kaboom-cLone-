using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 1000;

    private void Awake()
    {
        //if Highscore  value exist in playerPref get it
        if (PlayerPrefs.HasKey("High Score"))
            score = PlayerPrefs.GetInt("High Score");
        //Save highest score in storage
        PlayerPrefs.SetInt("High Score", score);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;
        // Refresh HighScore in PlayerPrefs if need it
        if (score > PlayerPrefs.GetInt("High Score"))
            PlayerPrefs.SetInt("High Score", score);
    }

    
}
