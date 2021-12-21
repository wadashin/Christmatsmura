using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 背景と障害物の自動生成
/// </summary>
public class AutoGenerate : MonoBehaviour
{
    [Header("背景")] public GameObject _background;
    [Header("障害物")] public GameObject[] _obstacles;

    [Header("背景の親オブジェクト")] public GameObject _backGroundParent;
    [Header("障害物の親オブジェクト")]public GameObject _obstaclesParent;

    [Header("背景の生成位置")] public Vector2 _backGroundCreatePos;
    [Header("障害物の生成位置")] public Vector2 _obstacleCreatePos;
    
    /// <summary>
    /// 新たなオブジェクトを指定した位置に生成する。
    /// <br></br>引数には障害物かどうかを渡す
    /// </summary>
    /// <param name="isObstacle"></param>
    public void Create(bool isObstacle)
    {
        int obstcleIndex = Random.Range(0, _obstacles.Length);//障害物をパターンからランダム生成するための処理

        //生成処理
        if (isObstacle)//障害物
        {
            GameObject obstacleLast = _obstaclesParent.transform.GetChild(_obstaclesParent.transform.childCount - 1).gameObject;
            Instantiate(_obstacles[obstcleIndex], new Vector3(obstacleLast.transform.position.x + _obstacleCreatePos.x, _obstacleCreatePos.y), Quaternion.identity, _obstaclesParent.transform);
        }
        else//背景
        {
            GameObject last = _backGroundParent.transform.GetChild(_backGroundParent.transform.childCount - 1).gameObject;
            Instantiate(_background, new Vector3(last.transform.position.x + _backGroundCreatePos.x, _backGroundCreatePos.y), Quaternion.identity, _backGroundParent.transform);
        }
    }
}
