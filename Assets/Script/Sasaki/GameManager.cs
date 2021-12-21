using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int m_score = 0;

    public float m_kyori { get; set; } //距離実数値
    public int m_kmINT { get; set; } //距離表記値

    [SerializeField] float m_totalTime = 120;

    public int m_seconds { get; set; } //制限時間の実数値

    public static bool m_isStop = false; //制限時間の変動可否

    [SerializeField] Text m_scoreText = default; //スコア表記

    [SerializeField] Text m_kyoriText = default; //距離表記

    [SerializeField] Text m_timeText = default; //時間表記

    [SerializeField] GameObject m_resultsPanel = default; //リザルト表示

    [SerializeField] Text m_resultsText = default; //勝敗

    float m_accel = 0; //加速力

    bool m_isLose = false;

    /// <summary>
    /// ゲームの状況
    /// </summary>
    public enum GameState
    {
        Present,
        Kitaku,
        Results,
    }
    public static GameState m_state = GameState.Present;

    // Start is called before the first frame update
    void Start()
    {
        m_resultsPanel.SetActive(false);
        m_state = GameState.Present;
        m_score = 0;
        m_kyori = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isStop == false)
        {
            m_totalTime -= Time.deltaTime;
            m_seconds = (int)m_totalTime;
            if(m_totalTime <= 0)
            {
                m_isLose = true; //時間切れで敗北
                m_isStop = true;
            }
        }

        m_timeText.text = "残り時間: " + m_seconds.ToString() + "秒";
        m_scoreText.text = "お前のクリス: " + m_score.ToString() + "クリス";
        m_kyoriText.text = "自宅まで: " + m_kmINT.ToString() + "km";

        switch (m_state)
        {
            case GameState.Present:
                m_kyori = m_score;
                m_kmINT = (int)m_kyori;
                break;
            case GameState.Kitaku:
                if(m_kyori >= 0)
                {
                    m_kyori -= Time.deltaTime * m_accel;
                    m_kmINT = (int)m_kyori;
                }
                break;
            case GameState.Results:
                m_resultsPanel.SetActive(true);
                //勝敗を判定
                if(m_isLose == false)
                {
                    m_resultsText.text = "クリア！";
                }
                else
                {
                    m_resultsText.text = "失敗...";
                }
                break;
        }
    }
}
