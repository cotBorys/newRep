using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charisma : MonoBehaviour
{
    [SerializeField] private int enemyHelthDeceleration = 10;
    // public Boss boss; // ����, �-��� �������� ����� (��� ������ �� ������) 


    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Player player))
        {
            // ����
            // boss.MaxHP -= enemyHelthDeceleration;
            Debug.Log($"HP ����� ����������� �� {enemyHelthDeceleration}");
            Destroy(gameObject);
        }

        //// ��� � ��������� ������!!! �� ��������������
        //EnemyHealth enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();

        //if(other.TryGetComponent(out PlayerController playerController))
        //{
        //    enemyHealth.ReduceHealth(enemyHelthDeceleration);
        //    Debug.Log($"HP ����� ����������� �� {enemyHelthDeceleration}");
        //    Destroy(gameObject);

        //}
    }
}
