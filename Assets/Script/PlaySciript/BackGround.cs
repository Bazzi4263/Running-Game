using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    float Inter;

    [SerializeField]
    int Sort = 0;

    bool m_IsNext = false;

    GameObject NextBG;
    Vector3 Pos;

    private void Awake()
    {
        SpriteRenderer SR = GetComponent<SpriteRenderer>();
        SR.sortingOrder = Sort;
    }

    void Update()
    {
        // 생성 로직
        if (PlayerScript.PlayerPosX > transform.position.x && m_IsNext == false)
        {
            NextBG = Instantiate<GameObject>(gameObject);
            Pos = transform.position;
            Pos.x += Inter;
            NextBG.transform.position = Pos;
            m_IsNext = true;
        }

        // 지우는 로직
        if (Inter<= PlayerScript.PlayerPosX - transform.position.x)
        {
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        if (PlayerScript.IsDeath == true)
        {
            Pos = transform.position;
            Pos.x = 0;
            transform.position = Pos;
        }
    }
}
