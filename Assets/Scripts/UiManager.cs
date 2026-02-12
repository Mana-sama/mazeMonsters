using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public void changeScene(int sceneNumber)
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(sceneNumber);

    }

}