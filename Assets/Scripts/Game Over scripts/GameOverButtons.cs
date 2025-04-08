using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void LoadMenu(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void LoadNextLevel()
    {
        if(LevelInfo.currentLevel < 2)
        {
            LevelInfo.currentLevel++;
        }
        else if(LevelInfo.currentLevel >= 2)
        {
            LevelInfo.currentLevel = 0;
        }

        SceneManager.LoadScene(LevelInfo.currentLevel);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(LevelInfo.currentLevel);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
