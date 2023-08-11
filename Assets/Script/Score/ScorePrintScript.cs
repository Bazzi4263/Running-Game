using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePrintScript : MonoBehaviour
{
    Text[] ArrText = null;

    [SerializeField] GameObject NameInputObj = null;

    // Start is called before the first frame update
    void Awake()
    {
        LogicValue.ScoreLoad();

        if (NameInputObj == null)
        {
            Debug.LogError("if (NameInputObj == null)");
        }

        if (LogicValue.ScoreCheck() == true)
        {
            NameInputObj.SetActive(true);
        }

        ArrText = GetComponentsInChildren<Text>();

        if (LogicValue.ScoreArr.Count != ArrText.Length)
        {
            Debug.LogError("if (LogicValue.ScoreArr.Count != ArrText.Length)");

            return;
        }
    }

    // Update is called once per frame
    void Update()
    {      
        for (int i = 0; i < ArrText.Length; i++)
        {
            if (LogicValue.ScoreArr[i].Score == 0)
            {
                ArrText[i].text = "미등록";
                continue;
            }

            string Name = LogicValue.ScoreArr[i].Name;

            if (Name == "")
            {
                Name = "NONAME";
            }

            ArrText[i].text = (i + 1).ToString() + "위 " + Name + " " +
            LogicValue.ScoreArr[i].Score.ToString() + "점";
        }
    }
}
