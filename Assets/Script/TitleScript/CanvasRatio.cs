using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasRatio : MonoBehaviour
{
    [SerializeField] Vector2 BasicSize;
    [SerializeField] Camera Cam;
    private void Awake()
    {
        CanvasScaler CS = GetComponent<CanvasScaler>();

        if (BasicSize.x / BasicSize.y > Cam.pixelWidth / Cam.pixelHeight)
            CS.matchWidthOrHeight = 0.0f;
        else
            CS.matchWidthOrHeight = 1.0f;
    }
}
