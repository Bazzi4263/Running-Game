using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanjaManager : MonoBehaviour
{
    // 순서
    // 1. 리터널 초기화 PanjaSprite = null;
    // 2. 엔진초기화 PanjaSprite = Pixel.png
    // 3. 함수 대입 PanjaSprite = 내가 대입해준것이 된다.

    [SerializeField]
    Color PanjaColor = new Color();

    [SerializeField]
    Sprite PanjaSprite = null;

    [SerializeField]
    float RandomYStart = -2.0f;
    [SerializeField]
    float RandomYEnd = 2.0f;

    [SerializeField]
    float RandomInterXStart = 2.0f;
    [SerializeField]
    float RandomInterXEnd = 4.0f;

    [SerializeField]
    int RandomScaleXStart = 5;
    [SerializeField]
    int RandomScaleXEnd = 10;

    [SerializeField]
    float CreateRange = 20.0f;
    [SerializeField]
    float CreateRandeValue = 20.0f;

    // 마지막으로 만들어진 판자의 X값
    [SerializeField]
    float LastCreatePosX = 12.0f;
    // 마지막을 만들어진 판자의 X크기
    [SerializeField]
    float LastCreateScaleX = 0.0f;

    float ResetLastCreatePosX = 0.0f;
    float ResetLastCreateScaleX = 0.0f;

    public static PanjaManager MainPanjaMgr;
           
    public static void PanjaReset()
    {
        MainPanjaMgr.ResetData();
    }

    private void Awake()
    {
        MainPanjaMgr = this;
        ResetLastCreatePosX = LastCreatePosX;
        ResetLastCreateScaleX = LastCreateScaleX;
    }

    public void ResetData()
    {
        LastCreatePosX = ResetLastCreatePosX;
        LastCreateScaleX = ResetLastCreateScaleX;
    }

    void NewPanjaLogic()
    {
        GameObject NewPanja = new GameObject("Panja");
        // NewPanja.transform.localScale = new Vector3(UnityEngine.Random.Range(RandomScaleXStart, RandomScaleXEnd), 1.0f, 1.0f);
        NewPanja.AddComponent<BoxCollider2D>();
        PanjaScript PS = NewPanja.AddComponent<PanjaScript>();
        int NewFloorCount = UnityEngine.Random.Range(RandomScaleXStart, RandomScaleXEnd + 1);

        PS.FloorCount = NewFloorCount;

        Vector3 CreatePos = new Vector3();
   
        CreatePos.x = LastCreateScaleX + LastCreatePosX + (NewFloorCount * 0.5f);
        CreatePos.x += UnityEngine.Random.Range(RandomInterXStart, RandomInterXEnd);
        CreatePos.y = UnityEngine.Random.Range(RandomYStart, RandomYEnd);
        CreatePos.z = 0.0f;

        NewPanja.transform.localPosition = CreatePos;

        // 이미지 컬러 세팅.
        SpriteRenderer NewSP = NewPanja.AddComponent<SpriteRenderer>();
        NewSP.color = PanjaColor;
        NewSP.sprite = PanjaSprite;



        // 갱신       
        LastCreateScaleX = PS.FloorCount * 0.5f;
        LastCreatePosX = CreatePos.x;
    }

    void CreatePanja()
    {
        if (CreateRange <= this.transform.localPosition.x + 10)
        {
            CreateRange += CreateRandeValue;
        }

        while (LastCreatePosX <= CreateRange)
        {
            NewPanjaLogic();
        }
    }

    // 일정시간마다 판자가 만들어진다.
    void Update()
    {
        CreatePanja();
    }   
}
