using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LogicValue.CoinSound();
        LogicValue.PlusScore(100);
        Destroy(gameObject);
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
