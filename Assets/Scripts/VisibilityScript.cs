using UnityEngine;

public class VisibilityScript : MonoBehaviour
{

    public GameObject Object;

    public void Deactivate()
    {
        Object.SetActive(false);
        Time.timeScale = 1;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

}
