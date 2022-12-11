using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knowledge : MonoBehaviour
{
    [SerializeField] private int atkMagnificaton = 10; // �� ������� ����������� ���� ����� ������

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��������� - ��, � ������� ����� ���� ���� �����
        if (other.TryGetComponent(out Player player))
        {
            // player.ATK+=atkMagnificaton;
            Debug.Log($"���� ����� ������ ����������� �� {atkMagnificaton}");
            Destroy(gameObject);
        }
    }
}
