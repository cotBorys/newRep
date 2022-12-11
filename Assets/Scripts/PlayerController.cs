using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedX = 1f; // ск-ть по оси Х
    [SerializeField] private float jumpForce = 300f; // сила прыжка
    [SerializeField] private int dolgiCount = 8;//счетчик "убитых долгов", уменьшается при каждом закрытом долге
    [SerializeField] private Text currentDolgiNum; // текст для вывода оставшегося количества долгов

    private Rigidbody2D _rb;
    private Finish _finish; // финиш
    private float _horizontal = 0f; // нажатая клавиша (в какую сторону должен двигаться игрок)

    private bool _isGround = false;
    private bool _isJump = false;
    private bool _isFacingRight = true;
    private bool _isFinish = false; // это финиш?
    
    public float speedMultiplier = 50f; // множитель скорости    

    public int DolgiCount { get => dolgiCount; } // геттер счетчика долгов

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
        currentDolgiNum.text = "<size=35>Dolgi: </size>" + DolgiCount;
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && _isGround)
        {
            _isJump = true;
        }

        // нажатие на F - завершение уровня
        if(Input.GetKeyDown(KeyCode.F))
        {
            // если игрок находиться на финише (в его коллайдере),
            if (_isFinish /*&& dolgiCount == 0*/)
            {
                // то деактивируем объект finish, вызвав метод из скрипта Finish
                _finish.FinishLevel();
            }
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * speedX * Time.fixedDeltaTime * speedMultiplier, _rb.velocity.y);

        if (_isJump)
        {
            _rb.AddForce(new Vector2(0f, jumpForce)); // придание силы для прыжка
            _isGround = false;
            _isJump = false; // игрок в воздухе НЕ прыгает
        }

        // если игрок идет вправо, но смотрит влево, то поворачиваем его спрайт (изменяем scale)
        if (_horizontal > 0f && !_isFacingRight)
        {
            Flip();
        } // если идет влево, но смотрит вправо, то тоже поворачиваем
        else if (_horizontal < 0f && _isFacingRight)
        {
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }
    }

    /*поворот игрока в зависимости от направления движения*/
    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    /*при соприкосновении с коллайдером долга сверху долг "умирает"
     проверяется, в чей коллайдер попал игрок*/
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.ToString() == "DolgiHat") //DolgiHat - тег "шапки" врага
        {
            other.GetComponent<EnemyHealth>().Die();
            if(DolgiCount > 0) 
                dolgiCount -= 1; //счетчик долгов уменьшается
            currentDolgiNum.text = "<size=35>Dolgi: </size>" + DolgiCount;
        }

        if (other.CompareTag("Finish"))
        {
            Debug.Log("It's FINISH!");
            _isFinish = true;
            _finish.ActivateFinish();
        }
    }

    /* проверяется, из чьего коллайдер вышел игрок */
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("It's NOT FINISH!");
            _isFinish = false;
        }
    }
}