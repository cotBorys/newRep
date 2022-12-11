using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform enemy1;
    public Transform enemy2;
    public Transform enemy3;

    public float timeBeforeSpawning = 1.5f;
    public float timeBetweenEnemies = 0.25f;
    public float timeBeforeWaves = 2.0f;
    public int enemiesPerWave = 10;
    private int currentNumberOfEnemies = 0;

    public int CurrentNumberOfEnemies { get => currentNumberOfEnemies; }
    private int kill = 0;
    private bool flag = true;




    IEnumerator SpawnEnemies()
    {
        // Начальная задержка перед первым появлением врагов
        yield return new WaitForSeconds(timeBeforeSpawning);
        // Когда таймер истекёт, начинаем производить эти действия
        while (flag)
        {
            // Не создавать новых врагов, пока не уничтожены старые
            if (currentNumberOfEnemies <= 0)
            {
                float randDirection;
                float randDistance;
                // Создать 10 врагов в случайных местах за экраном
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    // Задаём случайные переменные для расстояния и направления
                    randDistance = Random.Range(-30, 30);
                    randDirection = Random.Range(0, 0);
                    // Используем переменные для задания координат появления врага
                    float posX = this.transform.position.x + (Mathf.Cos((randDirection) * Mathf.Deg2Rad) * randDistance);
                    float posY = this.transform.position.y + (Mathf.Sin((randDirection) * Mathf.Deg2Rad) * randDistance);
                    // Создаём врага на заданных координатах
                    if (kill < 2)
                    {
                        Instantiate(enemy1, new Vector3(posX, posY, 0), this.transform.rotation);
                    }
                    else if (kill >= 2 && kill < 4)
                    {
                        Instantiate(enemy2, new Vector3(posX, posY, 0), this.transform.rotation);
                    }
                    else if (kill == 4) { Instantiate(enemy3, new Vector3(posX, posY, 0), this.transform.rotation); }

                    currentNumberOfEnemies++;
                    yield return new WaitForSeconds(timeBetweenEnemies);
                }
                kill++;
            }
            if (kill >= 5)
            {
                flag = false;
            }
            // Ожидание до следующей проверки
            yield return new WaitForSeconds(timeBeforeWaves);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }


    private void Update()
    {

    }
    public void KilledEnemy()
    {
        currentNumberOfEnemies--;
    }
}