using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 背景の横移動
/// </summary>
public class BackGround : MonoBehaviour
{
    private AutoGenerate _scrollScript;
    [Header("背景を消して新たな背景を生成する位置")]public float _destroyPos = -20f;
    [Header("横移動のスピード")]public float _scrollSpeed = -0.2f;
    private void Start()
    {
        _scrollScript = GameObject.Find("Gene").GetComponent<AutoGenerate>();
    }
    private void FixedUpdate()
    {
        this.gameObject.transform.position += new Vector3(_scrollSpeed, 0, 0);//横移動
        if (gameObject.transform.position.x <= _destroyPos)
        {
            _scrollScript.Create(false);//新たな背景を生成する
            Destroy(this.gameObject);//消す
        }
    }
}
