
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchTimer : MonoBehaviour
{
    public int sceneIndex = 0;
    public float waitSeconds = 10;
    void Start()
    {
        StartCoroutine(SwitchScene());
    }
    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(sceneIndex);
    }
}
