using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playersc : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] float upForce = 100;//ジャンプの力
    [SerializeField] float Top = 10;//画面のトップ
    [SerializeField] float Bottom = -5;//自動ジャンプの発動場所

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame

    private void Update()
    {
        Vector3 position = transform.position;
        float y = transform.position.y;
        

        if (Input.GetMouseButtonDown(0) && y < Top - 1)
        {
            Jump();
        }
        if(y > Top)
        {
            rb.velocity = Vector3.zero;
        }

        if(y < Bottom)
        {
            BottomJump();
        }
    }

    private void Jump()///左クリックでジャンプ
    {
        rb.velocity = Vector3.zero;
        //rb.AddForce(new Vector3(0, upForce, 0));
        rb.AddForce(transform.up * upForce, ForceMode.Impulse);
    }

    private void BottomJump()/// 自動ジャンプ
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.up * 10 , ForceMode.Impulse);
    }
}
