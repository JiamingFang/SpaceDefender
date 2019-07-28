using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void startGame()
    {
        print("Start");
        SceneManager.LoadScene("Game");
    }

    public void gameOver()
    {
        StartCoroutine(wait());
        
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("END");
    }

    public void quit()
    {
        print("QUIT");
        Application.Quit();
    }
}
