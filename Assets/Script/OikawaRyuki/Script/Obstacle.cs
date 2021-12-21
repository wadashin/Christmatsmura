using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 障害物の挙動
/// </summary>
public class Obstacle : MonoBehaviour
{
    private AutoGenerate _scrollScript;
    [Header("背景を消して新たな背景を生成する位置")] public float _destroyPos=-15f;
    [Header("横移動のスピード")] public float _scrollSpeed = -0.2f;


    private void Start()
    {
        _scrollScript = GameObject.Find("scrollManager").GetComponent<AutoGenerate>();
    }
    private void FixedUpdate()
    {
        this.gameObject.transform.position += new Vector3(_scrollSpeed, 0, 0);
        if (gameObject.transform.position.x <= _destroyPos)
        {
            _scrollScript.Create(true);
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            var fadeImage = GetComponent<Image>();
            fadeImage.enabled = true;
            var c = fadeImage.color;
            c.a = 1.0f; 
            fadeImage.color = c;

            DOTween.ToAlpha(() => fadeImage.color,color => fadeImage.color = color,0f, 1f);
        }
    }
}
