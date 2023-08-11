using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    Text TextCom = null;

    // Start is called before the first frame update
    void Start()
    {
        TextCom = GetComponent<Text>();

        if (TextCom == null)
        {
            Debug.LogError(" if (TextCom == null)");

            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TextCom == null)
        {
            Debug.LogError(" if (TextCom == null)");

            return;
        }

        TextCom.text = LogicValue.Score.ToString();
    }
}
