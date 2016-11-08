// Author:          Milan Gajic
// Date:            2016-08-16
// Version:         1.0

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreResult : MonoBehaviour 
{
    public Text txt;

	// Use this for initialization
	void Start () 
    {
        txt = gameObject.GetComponent<Text>();	
	}
	
	// Update is called once per frame
	void Update () 
    {
        txt.text = "Score: " + Score.score.ToString() + "\n" + "High Score: " + Score.highScore.ToString();	
	}
}
