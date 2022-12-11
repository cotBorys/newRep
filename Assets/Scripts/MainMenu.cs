using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // startBtn
    public void StartHandler()
    {
        // �������� ����� � �������� 1 - Level 1 Scene
        SceneManager.LoadScene(1);
    }

    // exitBtn
    public void ExitHandler()
    {
        // ����� �� ����
        Application.Quit();
    }
}

