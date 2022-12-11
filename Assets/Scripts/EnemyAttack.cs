using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float timeToDamage = 1f;//таймер (урон наносится каждую секунду)
    private float _damageTime;
    private bool _isDamage = true;//может ли враг наносить урон или нет

    private void Start()
    {
        _damageTime = timeToDamage;//инициализация таймера
    }

    private void Update()
    {//так как уменьшаем значение времени каждый фрейм
        if (!_isDamage)
        {//если враг не может сейчас нанести урон, то...
            _damageTime -= Time.deltaTime;//запускаем таймер
            if (_damageTime <= 0f)
            {//по истечении таймера мы можем нанести урон
                _isDamage = true;
                _damageTime = timeToDamage;//ставим значение таймера по умолчанию
            }
        }
    }
    private void OnCollisionStay2D(Collision2D other)//когда остаемся в коллайдере врага 
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null && _isDamage)//если можем наносить какой-то урон
        {
            playerHealth.ReduceHealth(damage);//нанесение урона
            _isDamage = false;//теперь враг не может нанести урон игроку
        }
    }
}
