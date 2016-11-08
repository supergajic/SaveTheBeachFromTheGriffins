// Author:          Milan Gajic
// Date:            2016-08-15
// Version:         1.0

using UnityEngine;
using System.Collections;

public class TimeOut : MonoBehaviour 
{
    public static bool wrongCharacter;
    private float timer;
    private float timeOut;

	// Use this for initialization
	void Start () 
    {
        wrongCharacter = true;
        timer = 0.000f;     
        CheckForDifficulty();
        timeOut = Spawn.removeTimer;
    }
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;

        if (timer > timeOut)
        {
            if (wrongCharacter)
            {
                Score.score++;
                Spawn.spawnNum = 0;
                Destroy(this.gameObject);
            }
            
        }
	}

    protected IEnumerator PauseBeforeRemove()
    {
        yield return new WaitForSeconds(Spawn.timer);

        Spawn.spawnNum = 0;
        if (wrongCharacter)
        {
            Score.score++;
        }
        Destroy(this.gameObject);
    }

    private void CheckForDifficulty()
    {
        if (Score.score % 10 == 0)
        {
            Spawn.removeTimer -= 0.1f;
        }
    }
}
