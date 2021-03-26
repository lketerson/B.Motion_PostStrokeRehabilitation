using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SelectGame()
    {

    }

    public void MainMenu()
    {

    }

    public void LoadGraph()
    {
        SceneManager.LoadScene(1);
    }
}
