using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NameInput : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject NameInputWin = null;
    [SerializeField] Text NewUserName = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        LogicValue.ScoreInput(NewUserName.text);
        NameInputWin.SetActive(false);
    }
}
