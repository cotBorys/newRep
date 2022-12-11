using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knowledge : MonoBehaviour
{
    [SerializeField] private int atkMagnificaton = 10; // на сколько увеличивает силу атаки игрока

    private void OnTriggerEnter2D(Collider2D other)
    {
        // компонент - то, в котором будет поле сила атаки
        if (other.TryGetComponent(out Player player))
        {
            // player.ATK+=atkMagnificaton;
            Debug.Log($"Сила атаки игрока увеличилась на {atkMagnificaton}");
            Destroy(gameObject);
        }
    }
}
