using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float totalHealth = 100f;//макс. значение здоровья игрока
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameObject gameOverCanvas;
   /* [SerializeField]*/ private float _health;

    public Action levelFailed;

    private void Start()
    {
        _health = totalHealth;
        InitHealth();
    }

    public void ReduceHealth(float damage)
    {
        _health -= damage;
        InitHealth();
        if (_health <= 0f)
        {
            Die();
        }
    }

    private void InitHealth()
    {
         healthSlider.value = _health / totalHealth; //0-1
    }

    private void Die()
    {
        gameObject.SetActive(false); //выключаем игрока из сцены
        gameOverCanvas.SetActive(true);
        levelFailed?.Invoke();
    }
}



