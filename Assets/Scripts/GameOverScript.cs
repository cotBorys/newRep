using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void RestartHandler()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    // возврат в главное меню (сцена 0)
    public void ExitHandler()
    {
        SceneManager.LoadScene(0);
    }
}
