using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBackScript : MonoBehaviour
{
    [SerializeField] float Speed = 2.0f;
    [SerializeField] float DeathLen;
    [SerializeField] float CreateLen;
    [SerializeField] int Order;
    [SerializeField] float CreateInter;

    bool m_IsCreate = false;

    private void Awake()
    {
        SpriteRenderer SR = GetComponent<SpriteRenderer>();

        if (null == SR)
        {
            Debug.LogError("if (null == SR)");
        }

        SR.sortingOrder = Order;
    }

    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * Speed;

        if (m_IsCreate == false && transform.position.x < CreateLen)
        {
            GameObject NewBackGround  = Instantiate(gameObject);
            NewBackGround.transform.position += Vector3.right * CreateInter;
            
            m_IsCreate = true;
            // NewBackGround.transform.position
        }

        if (DeathLen > transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
