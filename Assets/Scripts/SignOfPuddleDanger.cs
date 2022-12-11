using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignOfPuddleDanger : MonoBehaviour
{
    [SerializeField] private int forceDeceleration; // ���������� �������� ������

    // ��� ����� � ����������� ���������� ���������� �������� ������
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            playerController.speedMultiplier /= forceDeceleration;
        }
    }

    // ��� ������ �� ����������� �������� ������ �����������������
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            playerController.speedMultiplier *= forceDeceleration;
        }
    }
}
