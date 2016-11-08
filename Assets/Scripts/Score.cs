// Author:          Milan Gajic
// Date:            2016-08-14
// Version:         1.0

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour 
{
    public static int score;
    public static int highScore;
    public Text txtScore;

    private string testName = "Indie!";

	// Use this for initialization
	void Start () 
    {
        
        txtScore = gameObject.GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("High Score");
    }
	
	// Update is called once per frame
	void Update () 
    {  
        txtScore.text = "Score: " + score.ToString() + "                                               High Score: " + highScore.ToString();

        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("High Score", highScore);
        }
	}
}
