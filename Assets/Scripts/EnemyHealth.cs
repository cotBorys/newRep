using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float totalHealth = 100f;
    //[SerializeField] private Slider healthSlider;
    private float _health;
    private void Start()
    {
        _health = totalHealth;
        InitHealth();
    }

    public void ReduceHealth(float damage)
    {
        _health -= damage;
        //InitHealth();
        if (_health <= 0f)
        {
            Die();
        }
    }

    private void InitHealth()
    {
        // healthSlider.value = _health / totalHealth;
    }
    public void Die()
    {
        gameObject.SetActive(false);//выключаем врага из сцены
    }
}
   


