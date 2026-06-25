using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    void Start()
    {
        // 1. Повертаємо гравця на збережені координати
        if (PlayerPrefs.HasKey("PlayerX"))
        {
            float x = PlayerPrefs.GetFloat("PlayerX");
            float y = PlayerPrefs.GetFloat("PlayerY");
            transform.position = new Vector3(x, y, transform.position.z);
        }

        // 2. Видаляємо мертвих ворогів
        // Знаходимо всіх ворогів за тегом "Enemy" (переконайся, що вороги мають цей тег!)
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            if (PlayerPrefs.GetInt(enemy.name + "_Dead", 0) == 1)
            {
                Destroy(enemy);
            }
        }
    }
}