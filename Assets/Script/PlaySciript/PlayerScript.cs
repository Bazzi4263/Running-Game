using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 충돌 팁
// 1. 충돌 해야하는 A와 B가 있다면 A혹은 B 둘중하나는 리지드 바디가 존재해야한다.
// 2. A와 B둘다 컬라이더가 존재해야 한다.
// 3. 3D리지드 바디라면 3D컬라이더와만 충돌한다.

public class PlayerScript : MonoBehaviour
{
    private static PlayerScript Inst = null;

    int m_JumpCount;
    float m_PlayerPosX;
    float m_PlayerPosY;
    Animator m_Ani = null;
    AudioSource m_Sound;

    private static bool m_IsDeath = false;
    public static bool IsDeath { get { return m_IsDeath; } }

    public static float PlayerPosX
    {
        get
        {
            return Inst.m_PlayerPosX;
        }
    }

    public static float PlayerPosY
    {
        get
        {
            return Inst.m_PlayerPosY;
        }
    }

    void SpeedUp()
    {
        if (transform.position.x >= LogicValue.SpeedUpRange)
        {
            LogicValue.MoveSpeed = LogicValue.SecondMoveSpeed;
        }
    }

    // 최초로 충돌하는 순간
    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_JumpCount = LogicValue.JumpCount;
        m_Ani.SetTrigger("Run");
    }

    // 지속적으로 충돌하는 순간
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    // 충돌 중이다가 떨어진 순간
    private void OnCollisionExit2D(Collision2D collision)
    {
       
    }

    Rigidbody2D m_Rigi = null;

    private void Awake()
    {
        LogicValue.ScoreReset();

        Inst = this;
        m_JumpCount = LogicValue.JumpCount;
        m_Rigi = GetComponent<Rigidbody2D>();
        m_Ani = GetComponent<Animator>();
        m_Sound = GetComponent<AudioSource>();

        if (m_Rigi == null)
        {
            Debug.LogError("if (m_Rigi == null)");
        }
    }

    private void FixedUpdate()
    {
        if (m_IsDeath == true)
        {
            PanjaManager.PanjaReset();
            LogicValue.SpeedReset();
            m_IsDeath = false;
        }
    }

    public void Jump()
    {
        
    }

    void Update()
    {
        if (transform.localPosition.y <= -MoveCamera.CamComponent.orthographicSize)
        {
            SceneManager.LoadScene("ScoreScene");

            // // 플레이어를 맨 처음으로 돌리고
            // transform.position = Vector3.zero;
            // 
        }

        transform.position += Vector3.right * Time.deltaTime * LogicValue.MoveSpeed;
        m_PlayerPosX = transform.position.x;
        m_PlayerPosY = transform.position.y;

        SpeedUp();

        if (Input.GetKeyDown(KeyCode.Space) && m_JumpCount != 0)
        {
            // 리지드 바디를 받아온다.
            m_Ani.SetTrigger("Jump");

            m_Rigi.velocity = Vector3.zero;
            m_Rigi.AddForce(Vector2.up * LogicValue.JumpPower);
            m_Sound.Play();

            --m_JumpCount;
        }

        if (Input.GetMouseButtonDown(0) && m_JumpCount != 0)
        {
            // 리지드 바디를 받아온다.
            m_Ani.SetTrigger("Jump");

            m_Rigi.velocity = Vector3.zero;
            m_Rigi.AddForce(Vector2.up * LogicValue.JumpPower);
            m_Sound.Play();

            --m_JumpCount;
        }
    }
}
