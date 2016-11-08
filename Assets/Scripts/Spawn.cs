// Author:          Milan Gajic
// Date:            2016-08-13
// Version:         1.0

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour 
{
    public GameObject peter;
    public GameObject lois;
    public GameObject glenn;
    public GameObject stewie;
    public GameObject meg;
    public GameObject chris;
    public GameObject cleveland;
    public GameObject consuela;

    public Vector3[] spawnPos;
    public bool[] taken;

    private bool startTimer;
    private float timeLeft;

    public static int spawnNum;
    public static float timer;
    private int takenCounter;
    public static string playName;
    public static float removeTimer;

    public static bool isTapped = true;
    public static bool playSound = false;

    private AudioSource audioSource;
    public AudioClip audioPeter;
    public AudioClip audioLois;
    public AudioClip audioStewie;
    public AudioClip audioChris;
    public AudioClip audioCleveland;
    public AudioClip audioGlenn;
    public AudioClip audioMeg;
    public AudioClip audioConsuela;

    // Use this for initialization
    void Start () 
    {
        ResetValues();
        InitializeSpawnPositions();
        timer = 1f;
        spawnNum = 0;
        takenCounter = 0;
        audioSource = this.GetComponent<AudioSource>();
	}

    private void ResetValues()
    {
        timeLeft = 2.0f;
        startTimer = true;
        isTapped = true;
        playSound = false;
        timer = 1f;
        spawnNum = 0;
        Score.score = 0;
        takenCounter = 0;
        removeTimer = 1.5f;
        audioSource = this.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if(startTimer)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0)
            {
                startTimer = false;
            }
        }

        if (!startTimer)
        {
            if (!isTapped)
            {
                SceneManager.LoadScene("GameOver");
            }

            if (playSound)
            {
                if (playName == "Peter")
                {
                    audioSource.PlayOneShot(audioPeter);
                    Score.score++;
                }
                if (playName == "Chris")
                {
                    audioSource.PlayOneShot(audioChris);
                    Score.score++;
                }
                if(playName == "Lois")
                {
                    audioSource.PlayOneShot(audioLois);
                    Score.score++;
                }
                if (playName == "Meg")
                {
                    audioSource.PlayOneShot(audioMeg);
                    Score.score++;
                }
                if (playName == "Stewie")
                {
                    audioSource.PlayOneShot(audioStewie);
                    Score.score++;
                }

                if (playName == "Cleveland")
                {
                    audioSource.PlayOneShot(audioCleveland);
                    StartCoroutine(PauseBeforeGameOver());
                    //SceneManager.LoadScene("GameOver");
                }              
                if (playName == "Glenn")
                {
                    audioSource.PlayOneShot(audioGlenn);
                    StartCoroutine(PauseBeforeGameOver());
                    //SceneManager.LoadScene("GameOver");
                }
                if (playName == "Consuela")
                {
                    audioSource.PlayOneShot(audioConsuela);
                    StartCoroutine(PauseBeforeGameOver());
                    //SceneManager.LoadScene("GameOver");
                }
                
                playSound = false;
            }

            if (spawnNum == 0)
            {
                if (takenCounter > 3)
                {
                    taken = new bool[9];
                    takenCounter = 0;
                }

                StartCoroutine(PauseBeforeNewCharacter());
            }
        }
	}

    protected IEnumerator PauseBeforeNewCharacter()
    {
        yield return new WaitForSeconds(0.2f);

        SpawnCharacter();
    }

    protected IEnumerator PauseBeforeGameOver()
    {
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("GameOver");
    }

    private void InitializeSpawnPositions()
    {
        spawnPos = new Vector3[9];
        taken = new bool[9];

        float z = -1.3f;

        // Top row
        spawnPos[0] = new Vector3(-1.97f, 2.7f, z);
        spawnPos[1] = new Vector3(0.1f, 2.7f, z);
        spawnPos[2] = new Vector3(2.1f, 2.7f, z);

        //Middle row
        spawnPos[3] = new Vector3(-1.97f, -0.42f, z);
        spawnPos[4] = new Vector3(0.1f, -0.42f, z);
        spawnPos[5] = new Vector3(2.1f, -0.42f, z);

        //Bottom row
        spawnPos[6] = new Vector3(-1.97f, -3.49f, z);
        spawnPos[7] = new Vector3(0.1f, -3.49f, z);
        spawnPos[8] = new Vector3(2.1f, -3.49f, z);
    }

    private void SpawnCharacter()
    {
        int spawnPoint;
        int spawnType;
        int s = 0;

        while(s == spawnNum)
        {
            spawnPoint = Random.Range(0, 10);
            spawnType = Random.Range(0, 8);

            if(!taken[spawnPoint])
            {
                if (spawnType == 0)
                {
                    Instantiate(peter, spawnPos[spawnPoint], Quaternion.Euler(90, 180, 0));
                    taken[spawnPoint] = true;
                }
                if (spawnType == 1)
                {
                    Instantiate(lois, spawnPos[spawnPoint], Quaternion.Euler(90, 180, 0));
                    taken[spawnPoint] = true;
                }
                if (spawnType == 2)
                {
                    Instantiate(chris, spawnPos[spawnPoint], Quaternion.Euler(90, 180, 0));
                    taken[spawnPoint] = true;
                }
                if (spawnType == 3)
                {
                    Instantiate(glenn, spawnPos[spawnPoint], Quaternion.Euler(90, 180, 0));
                    taken[spawnPoint] = true;
                }
                if (spawnType == 4)
                {
                    Instantiate(consuela, spawnPos[spawnPoint], Quaternion.Euler(90, 180, 0));
                    taken[spawnPoint] = true;
                }
                if (spawnType == 5)
                {
                    Instantiate(cleveland, spawnPos[spawnPoint], Quaternion.Euler(90, 180, 0));
                    taken[spawnPoint] = true;
                }
                if (spawnType == 6)
                {
                    Instantiate(meg, spawnPos[spawnPoint], Quaternion.Euler(90, 180, 0));
                    taken[spawnPoint] = true;
                }
                if (spawnType == 7)
                {
                    Instantiate(stewie, spawnPos[spawnPoint], Quaternion.Euler(90, 180, 0));
                    taken[spawnPoint] = true;
                }

                takenCounter++;
                spawnNum++;
            }

            else
            {
                continue;
            }
        }
    }
}
