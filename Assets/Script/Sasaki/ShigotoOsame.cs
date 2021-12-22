using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShigotoOsame : MonoBehaviour
{
    [SerializeField] GameObject[] m_gameStateObj = new GameObject[2]; //各フェイズを管理する親オブジェクトたち

    float m_waitTime = 1; //処理待ち時間

    [SerializeField] GameObject me = default;

    public void PhaseChange()
    {
        StartCoroutine(SlowlyChange());
    }

    IEnumerator SlowlyChange()
    {
        yield return new WaitForSeconds(m_waitTime);
        GameManager.m_state = GameManager.GameState.Kitaku;
        m_gameStateObj[0].SetActive(false);
        m_gameStateObj[1].SetActive(true);
        me.SetActive(false);
    }
}
