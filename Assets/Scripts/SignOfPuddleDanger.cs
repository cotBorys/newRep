using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignOfPuddleDanger : MonoBehaviour
{
    [SerializeField] private int forceDeceleration; // замедление скорости игрока

    // при входе в препятствие происходит замедление скорости игрока
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            playerController.speedMultiplier /= forceDeceleration;
        }
    }

    // при выходе из препятствия скорость игрока восстанавливается
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            playerController.speedMultiplier *= forceDeceleration;
        }
    }
}
