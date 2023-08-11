using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void SceneChange()
    {
        Debug.Log("씬 넘기기");
    }
}
