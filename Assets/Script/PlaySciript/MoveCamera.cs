using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public static Camera CamComponent;
    Vector3 CreatePos = new Vector3();

    private void Awake()
    {
        CamComponent = GetComponent<Camera>();
    }

    void Update()
    {
        CreatePos.x = PlayerScript.PlayerPosX + 6.5f;
        CreatePos.y = 0;
        CreatePos.z = -10;

        transform.localPosition = CreatePos;
    }
}
