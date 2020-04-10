using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UILogic : MonoBehaviour
{

    public GameObject player;
    public GameObject panel;
    public GameObject text;
    
    private static bool isPaused = false;
    private float time;

    // Start is called before the first frame update

    void Start()
    {
        time = Time.timeScale;
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("enem");
        
        if (gameObjects.Length == 1 && (player.transform.localScale.x < 
            gameObjects[0].transform.localScale.x))
        {
            Text textComponent = text.GetComponent<Text>();
            textComponent.text = "You lose";
            isPaused = true;
            PauseImplementation();
        }
        else if (gameObjects.Length == 1 && (player.transform.localScale.x >
                gameObjects[0].transform.localScale.x))
        {
            Text textComponent = text.GetComponent<Text>();
            textComponent.text = "You Win";
            isPaused = true;
            PauseImplementation();
        }

        //needs to continue idea
        //if (player.transform.localScale.x < minScaleX)
        //{
        //    Text textComponent = text.GetComponent<Text>();
        //    textComponent.text = "You lose";
        //    PauseImplementation();
        //}

        //win
        //foreach (GameObject obj in gameObjects)
        //   if (obj.transform.localScale.x > player.transform.localScale.x)


        //if (scaleSum > player.transform.localScale.x)
        //{
        //    Text textComponent = text.GetComponent<Text>();
        //    textComponent.text = "You Win";
        //    PauseImplementation();
        //}
        //==========================

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseImplementation();
        }
    }

    public void Exit()
    {
        //Debug.Log("EXIT");
        Application.Quit(0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = time;
    }

    public void Resume()
    {
        Debug.Log("noo paused");
        isPaused = false;
        panel.SetActive(false);
        Time.timeScale = time;
    }

    void PauseImplementation()
    {
        Debug.Log("ESC");
        if (!isPaused)
        {
            Time.timeScale = time;
            isPaused = true;
            panel.SetActive(false);
        }
        else
        {
            isPaused = false;
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
