// Author:          Milan Gajic
// Date:            2016-08-16
// Version:         1.0

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TapMenu();
    }

    private void TapMenu()
    {
        string tag;

        if (Input.GetMouseButtonDown(0))
        {
            Ray R = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Physics.Raycast(R, out Hit))
            {
                if (Hit.collider.gameObject == gameObject)
                {
                    tag = gameObject.tag;
                    if(tag == "PlayAgain")
                    {
                        SceneManager.LoadScene("MainGame");
                    }
                    if (tag == "MainMenu")
                    {
                        SceneManager.LoadScene("MainMenu");
                    }
                    if (tag == "Play")
                    {
                        SceneManager.LoadScene("MainGame");
                    }
                }
            }
        }
    }
}
