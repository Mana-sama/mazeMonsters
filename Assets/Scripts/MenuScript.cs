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

    public void continueGame(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void pauseeGame(int index)
    {
        SceneManager.LoadScene(index);
    }


}
