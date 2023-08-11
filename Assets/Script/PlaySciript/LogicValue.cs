using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CameraAndPlayerData
{
    [SerializeField]
    public float m_MoveSpeed = 10.0f;
    [SerializeField]
    public float JumpPower = 10.0f;
    [SerializeField]
    public int m_JumpCount = 3;
    [SerializeField]
    public float SpeedUpRange = 500.0f;
    [SerializeField]
    public float SecondMoveSpeed = 20.0f;
    public float ResetMoveSpeed;
}

public class LogicValue : MonoBehaviour
{
    // 변형 싱글톤
    private static LogicValue Inst = null;

    [SerializeField]
    private GameObject m_CoinPrefab;

    [SerializeField]
    CameraAndPlayerData m_CameraAndPlayerData = new CameraAndPlayerData();

    [SerializeField]
    Sprite m_MainFloor;
    [SerializeField]
    Sprite m_LeftFloor;
    [SerializeField]
    Sprite m_RightFloor;
    [SerializeField]
    static int m_Score;
    public static int Score { get { return m_Score; } }

    static AudioSource CoinSoundSource;

    public static void CoinSound()
    {
        CoinSoundSource.Play();
    }

    public static void PlusScore(int _Score)
    {
        m_Score += _Score;
    }

    public static void ScoreReset()
    {
        m_Score = 0;
    }

    public class ScoreData
    {
        public string Name;
        public int Score;

        public ScoreData(string _Name, int _Score)
        {
            Name = _Name;
            Score = _Score;
        }
    }

    [SerializeField] static List<ScoreData> m_ScoreArr;
    public static List<ScoreData> ScoreArr { get { return m_ScoreArr; } }

    public static void ScoreLoad()
    {
        if (PlayerPrefs.HasKey("Name0") == true)
        {
            m_ScoreArr = new List<ScoreData>();

            for (int i = 0; i < 5; i++)
            {
                // 기존 데이터 로드               
                ScoreData NewScore = new ScoreData(PlayerPrefs.GetString("Name" + i, ""), 
                    PlayerPrefs.GetInt("Score" + i, 0));
                m_ScoreArr.Add(NewScore);
            }

            return;
        }

        m_ScoreArr = new List<ScoreData>();

        for (int i = 0; i < 5; i++)
        {
            // 항목만들기
            PlayerPrefs.SetString("Name" + i, "");
            PlayerPrefs.SetInt("Score" + i, 0);
            ScoreData NewScore = new ScoreData("", 0);
            m_ScoreArr.Add(NewScore);
        }
    }

    public static bool ScoreCheck()
    {
        for (int i = 0; i < ScoreArr.Count; i++)
        {
            if (m_Score > ScoreArr[i].Score)
            {
                return true;
            }
        }

        return false;
    }

    public static void ScoreInput(string _Name)
    {
        ScoreData CheckData = new ScoreData(_Name, m_Score);
        m_Score = 0;

        for (int i = 0; i < ScoreArr.Count; i++)
        {
            if (CheckData.Score > ScoreArr[i].Score)
            {
                ScoreData TempScore = ScoreArr[i];
                ScoreArr[i] = CheckData;
                CheckData = TempScore;
            }
        }

        // 파일저장
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetString("Name" + i, m_ScoreArr[i].Name);
            PlayerPrefs.SetInt("Score" + i, m_ScoreArr[i].Score);
            ScoreData NewScore = new ScoreData("", 0);
            m_ScoreArr.Add(NewScore);
        }
    }

    public static float MoveSpeed
    {
        get { return Inst.m_CameraAndPlayerData.m_MoveSpeed; }
        set { Inst.m_CameraAndPlayerData.m_MoveSpeed = value; }
    }

    public static float SecondMoveSpeed { get { return Inst.m_CameraAndPlayerData.SecondMoveSpeed; } }
    public static float SpeedUpRange { get { return Inst.m_CameraAndPlayerData.SpeedUpRange; } }
    public static float JumpPower { get { return Inst.m_CameraAndPlayerData.JumpPower; } }
    public static int JumpCount { get { return Inst.m_CameraAndPlayerData.m_JumpCount; } }
    public static GameObject Coinprefab { get { return Inst.m_CoinPrefab; } }
    public static Sprite MainFloor { get { return Inst.m_MainFloor; } }
    public static Sprite LeftFloor { get { return Inst.m_LeftFloor; } }
    public static Sprite RightFloor { get { return Inst.m_RightFloor; } }


    public static void SpeedReset()
    {
        Inst.ResetData();
    }

    public void ResetData()
    {
        Inst.m_CameraAndPlayerData.m_MoveSpeed = Inst.m_CameraAndPlayerData.ResetMoveSpeed;
    }

    private void Awake()
    {
        Inst = this;
        Inst.m_CameraAndPlayerData.ResetMoveSpeed = Inst.m_CameraAndPlayerData.m_MoveSpeed;
        CoinSoundSource = GetComponent<AudioSource>();
        // 여기에서 파일 입출력을
    }

    // Update is called once per frame
    void Update()
    {

    }
}
