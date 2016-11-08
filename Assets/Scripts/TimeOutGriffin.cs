// Author:          Milan Gajic
// Date:            2016-08-15
// Version:         1.0

using UnityEngine;
using System.Collections;

public class TimeOutGriffin : MonoBehaviour {

    public static bool tap;
    private float timer;
    private float timeOut;

    void Start()
    {
        tap = false;
        timer = 0.000f;      
        CheckForDifficulty();
        timeOut = Spawn.removeTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeOut)
        {
            if (!tap)
            {
                Spawn.isTapped = false;
                Destroy(this.gameObject);
            }

            Spawn.spawnNum = 0;
            Destroy(this.gameObject);
        }
    }

    private void CheckForDifficulty()
    {
        if (Score.score % 10 == 0)
        {
            Spawn.removeTimer -= 0.1f;
        }
    }
}
