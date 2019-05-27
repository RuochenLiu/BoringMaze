using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Maze mazePrefab;

    private Maze mazeInstance;

    public Player player;

    private bool isMaze = true;

    public int stage = 0;

    public GameObject completeUI;

    public GameObject StartUI;

    public GameObject TutorialUI;

    private void Start()
    {
        BeginGame();
    }

    private void Update()
    {
        // Start game after tutorial
        if ((Input.GetKey(KeyCode.Return) || Input.GetKey("enter")) && stage == 0)
        {
            StartUI.SetActive(false);
            TutorialUI.SetActive(true);
            Invoke("CloseTutorial", 5f);
        }

        // Finish
        if (player.Finished && isMaze)
        {
            isMaze = false;
            StopAllCoroutines();
            Destroy(mazeInstance.gameObject);

            completeUI.SetActive(true);
        }
        
        if ((Input.GetKey(KeyCode.Return) || Input.GetKey("enter")) && player.Finished)
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void BeginGame()
    {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        StartCoroutine(mazeInstance.Generate());
    }

    private void RestartGame()
    {
        //Get current scene name
        string scene = SceneManager.GetActiveScene().name;
        //Load it
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    private void CloseTutorial()
    {
        TutorialUI.SetActive(false);
        stage = 1;
    }
}