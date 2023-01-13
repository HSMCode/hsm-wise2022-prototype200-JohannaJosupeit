using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class onClickEvents : MonoBehaviour
{
    public void restartGame()
    {
        SceneManager.LoadScene("RandomizedCity");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
