// Author:          Milan Gajic
// Date:            2016-08-14
// Version:         1.0

using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour 
{
    
    public int nrOfTap;

	// Use this for initialization
	void Start () 
    {
        nrOfTap = 1;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(nrOfTap == 1)
        {
            HitTarget();
        }
	}

    private void HitTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray R = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Physics.Raycast(R, out Hit))
            {
                if (Hit.collider.gameObject == gameObject)
                {
                    //Score.score++;
                    Spawn.playName = gameObject.tag;
                    Spawn.playSound = true;
                    Spawn.isTapped = true;
                    nrOfTap = 2;
                    if (gameObject.tag == "Glenn" || gameObject.tag == "Cleveland" || gameObject.tag == "Consuela")
                    {
                        TimeOut.wrongCharacter = false;
                        Spawn.spawnNum = 1;
                    }
                    else
                    {
                        Spawn.spawnNum = 0;
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }
}
