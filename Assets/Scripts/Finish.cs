using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject levelCompleteCanvas;
    [SerializeField] private GameObject messageUI; // ���������, ��� �� ����� ��� �����
    //[SerializeField] PlayerController player;

    public Action levelFinish;

    private bool _isFinishActivated = false;
    private PlayerController player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    /* ��������� ������
     * ����������, ����� ������� ������ ����� 0
     */
    public void ActivateFinish()
    {
        if (player.DolgiCount == 0)
        {
            _isFinishActivated = true;
            messageUI.SetActive(false);
        }
    }

    public void FinishLevel()
    {
        if (_isFinishActivated)
        {
            gameObject.SetActive(false); // ����������� ������
            levelCompleteCanvas.SetActive(true); // ��������� �������: ���������� �������
            Time.timeScale = 0; // ���� �������� �� �����
            levelFinish?.Invoke();
        }
        else
        {
            messageUI.SetActive(true); // ��������� ���������
        }
    }
}
