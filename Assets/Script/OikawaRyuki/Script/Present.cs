using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    [Header("落ちる速度")]public float _fallSpeed;
    [Header("消える位置")]public float _destroyPos;
    [Header("プレゼント")] public GameObject _present;

    private GameObject _player;
    private Vector3 _playerPos;
    private void Start()
    {
        _player = GameObject.Find("Player");
        _playerPos = _player.transform.position;
    }

    private void FixedUpdate()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddForce(transform.up * -_fallSpeed, ForceMode.Force);

        if (this.transform.position.y <= _destroyPos)
        {
            Crate();
            Destroy(this.gameObject);
        }
    }
    private void Crate()
    {
        Instantiate(_present, _playerPos, Quaternion.identity);
    }
}
