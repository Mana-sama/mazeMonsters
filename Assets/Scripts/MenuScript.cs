using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void appQuit()
    {
        Application.Quit();
    }

    public void restartGame(int index)
    {
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene(index);
    }

    public void continueGame()
    {
        int index = PlayerPrefs.GetInt("pauseIndex", 9);
        SceneManager.LoadScene(index);
    }

    public void pauseeGame(int index)
    {
        PlayerPrefs.SetInt("pauseIndex", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(index);
    }


}
