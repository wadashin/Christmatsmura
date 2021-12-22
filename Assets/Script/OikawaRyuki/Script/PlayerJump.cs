using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float Bottom;
    private Rigidbody rb;
    private void Awake()
    {
       rb = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (transform.position.y < Bottom)
        {
            AutoJump();
        }
    }
    private void AutoJump()//最下部で自動ジャンプ
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.up * 10, ForceMode.Impulse);
    }
}
