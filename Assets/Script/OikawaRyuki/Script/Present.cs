using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Present : MonoBehaviour
{
    [Header("落ちる速度")]public float _fallSpeed;
    [Header("消える位置")]public float _destroyPos;
    [Header("プレゼント")]public GameObject _present;

    private GameObject _player;
    private Vector3 _presentScale;
    private Vector3 _playerPos;
    private Rigidbody rb;
    private void Start()
    {
        _player = GameObject.Find("ChMD_kurisumatummura_prefab");
        rb = this.GetComponent<Rigidbody>();
        _playerPos = _player.transform.position+Vector3.right;
        _presentScale = this.transform.localScale;
        ScaleChange();
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.up * -_fallSpeed, ForceMode.Force);
        if (this.transform.position.y <= _destroyPos)
        {
            this.gameObject.transform.localScale = _presentScale;
            this.gameObject.transform.position = _playerPos;
            rb.velocity = Vector3.zero;
            ScaleChange();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("House"))
        {
            other.transform.DOScale(0.4f, 0.2f);
            this.gameObject.transform.localScale = _presentScale;
            this.gameObject.transform.position = _playerPos;
            rb.velocity = Vector3.zero;
            ScaleChange();
        }
    }
    private void ScaleChange()
    {
        transform.DOScale(0.05f, 2f).SetEase(Ease.InQuart);
    }
}
