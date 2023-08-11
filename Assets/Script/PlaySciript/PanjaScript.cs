using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanjaScript : MonoBehaviour
{
    [SerializeField]
    private int Count;

    public int FloorCount
    {
        set
        {
            Count = value;

            float MoveSize = Count * -0.5f;

            for (int i = 0; i < Count; i++)
            {
                GameObject NewObj = new GameObject("Floor");

                NewObj.transform.SetParent(transform);
                // NewObj.transform.position : 월드 포지션
                NewObj.transform.localPosition = new Vector3(i + MoveSize, 0, 0);
                SpriteRenderer SR = NewObj.AddComponent<SpriteRenderer>();
                SR.sprite = LogicValue.MainFloor;
                NewObj.AddComponent<PolygonCollider2D>();

                GameObject Newcoin = GameObject.Instantiate(LogicValue.Coinprefab);
                Newcoin.transform.SetParent(transform);
                Newcoin.transform.position = NewObj.transform.position + Vector3.up;
            }

            GameObject Left = new GameObject("LeftFloor");
            Left.transform.SetParent(transform);
            Left.transform.localPosition = new Vector3(-0.191f + -0.5f + MoveSize, 0, 0);
            SpriteRenderer LEFTSR = Left.AddComponent<SpriteRenderer>();
            LEFTSR.sprite = LogicValue.LeftFloor;
            Left.AddComponent<PolygonCollider2D>();

            GameObject Right = new GameObject("RightFloor");
            Right.transform.SetParent(transform);
            Right.transform.localPosition = new Vector3(Count + 0.2f - 0.5f + MoveSize, 0, 0);
            SpriteRenderer RIGHTSR = Right.AddComponent<SpriteRenderer>();
            RIGHTSR.sprite = LogicValue.RightFloor;
            Right.AddComponent<PolygonCollider2D>();
        }

        get
        {
            return Count;
        }
    }

    private void Awake()
    {
        if (LogicValue.Coinprefab == null)
        {
            Debug.LogError("if (LogicValue.Coinprefab == null)");

            return;
        }

        // float을 int로 형변환 시켜준다.
        
    }

    private void Start()
    {      
    }

    void Update()
    {
        if (PlayerScript.PlayerPosX - transform.position.x >= 10.0f)
        {
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        if (PlayerScript.IsDeath == true)
        {
            Destroy(gameObject);
        }
    }
}
