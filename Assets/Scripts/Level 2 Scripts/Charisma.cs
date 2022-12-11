using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charisma : MonoBehaviour
{
    [SerializeField] private int enemyHelthDeceleration = 10;
    // public Boss boss; // Враг, к-ому привязан бонус (имя объект мб другое) 


    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Player player))
        {
            // типо
            // boss.MaxHP -= enemyHelthDeceleration;
            Debug.Log($"HP босса увеньшилось на {enemyHelthDeceleration}");
            Destroy(gameObject);
        }

        //// тэг и компонент другие!!! не протестировано
        //EnemyHealth enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();

        //if(other.TryGetComponent(out PlayerController playerController))
        //{
        //    enemyHealth.ReduceHealth(enemyHelthDeceleration);
        //    Debug.Log($"HP босса увеньшилось на {enemyHelthDeceleration}");
        //    Destroy(gameObject);

        //}
    }
}
