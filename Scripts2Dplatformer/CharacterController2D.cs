using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f; //  Сила с которой прыгает игрок.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f; //  Количество maxSpeed приложенного к приседая движению. 1 = 100%
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f; //  Сколько стоит сгладить движение
    [SerializeField] private bool m_AirControl = false; //  Может ли игрок управлять во время прыжка;
    [SerializeField] private LayerMask m_WhatIsGround; //  Маска, определяющая, что является основанием для персонажа
    [SerializeField] private Transform m_GroundCheck; //  Положение маркировка, где проверить, если игрок заземлен.
    [SerializeField] private Transform m_CeilingCheck; //  Маркировка положения где проверить для потолков
    [SerializeField] private Collider2D m_CrouchDisableCollider; //  Коллайдер, который будет отключен при пригибании
    [SerializeField] private GameObject gameOver;

    private System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

    public Health health;

    const float k_GroundedRadius = .2f; //  Радиус круга перекрытия для определения заземления
    private bool m_Grounded; //  Независимо от того, заземлен ли игрок.

    const float k_CeilingRadius = .2f; //  Радиус круга перекрытия, чтобы определить, может ли игрок встать

    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true; //  Для определения того, в какую сторону игрок в данный момент сталкивается.
    private Vector3 m_Velocity = Vector3.zero;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    private void FixedUpdate()
    {
        //bool wasGrounded = m_Grounded;
        //m_Grounded = false;



        if (!m_Grounded)
        {
            sw.Start();
        }
        m_Grounded = false;


        //  Игрок заземляется, если круговая передача на позицию groundcheck попадает во что-либо, обозначенное как земля
        //  Это можно сделать с помощью слоев вместо этого, но примеры ресурсов не будут перезаписывать настройки проекта.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                //m_Grounded = true;
                //if (!wasGrounded)
                //    OnLandEvent.Invoke();



                m_Grounded = true;
                if (sw.ElapsedMilliseconds > (long)60)
                    OnLandEvent.Invoke();
                sw.Reset();
            }
        }
    }


    public void Move(float move, bool crouch, bool jump)
    {
        //  Если crouching, проверьте, может ли персонаж встать
        //if (!crouch)
        //{
        //    //  Если у персонажа есть потолок, препятствующий им вставать, держите crouching
        //    if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
        //    {
        //        crouch = true;
        //    }
        //}

        //  управляйте player только в том случае, если он заземлен или включен airControl
        if (m_Grounded || m_AirControl)
        {
            //  If crouching
            if (crouch)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }

                //  Уменьшите скорость с помощью множителя скорости crouchSpeed
                //move *= m_CrouchSpeed;

                //  Отключить один из коллайдеров при crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
            }
            else
            {
                //   Включить коллайдер, Когда он не crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }


            //  Перемещение персонажа путем нахождения целевой скорости
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            //  А затем сглаживаем его и прикладываем к персонажу
            if (!crouch)
                m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            //  Если входной сигнал перемещает игрока вправо, а игрок стоит лицом влево...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            //  В противном случае, если вход перемещает игрока влево, а игрок стоит лицом вправо...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
        //  Если игрок должен прыгать...
        if (m_Grounded && jump)
        {
            //  Add a vertical force to the player.
            
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }


    private void Flip()
    {
        //  Переключите способ, которым игрок обозначается как facing.
        m_FacingRight = !m_FacingRight;

        //  Умножьте локальную шкалу игрока x на -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("platformMove"))
        {
            this.transform.parent = collision.transform;
        }

        if (collision.gameObject.name.Equals("Next_Level1"))
        {
            SceneManager.LoadScene(2);
        }

        if (collision.gameObject.name.Equals("Next_Level2"))
        {
            SceneManager.LoadScene(3);
        }

        if (collision.gameObject.name.Equals("GameOver"))
        {
            gameOver.SetActive(true);
        }

        //if (collision.gameObject.name.Equals("shipi"))
        //{
        //    health.TakeDamage(1);
        //}
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("platformMove"))
        {
            this.transform.parent = null;
        }
    }



}