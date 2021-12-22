using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playersc : MonoBehaviour
{

    public Rigidbody rb;
    [SerializeField] float upFore = 80;//上昇力   
    [SerializeField] float Top = 10;//画面上部
    [SerializeField] float Bottom = -5;//画面下部

    [SerializeField] GameManager m_gm = default;

    [SerializeField] UnityEngine.Events.UnityEvent m_OnObst = null; //障害物にぶつかったときに音を鳴らす

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        float y = transform.position.y;
        if(Input.GetMouseButtonDown(0) && y < Top -1)
        {
            Jump();
        }
        if(y > Top)
        {
            rb.velocity = Vector3.zero;
        }
        if(y < Bottom)
        {
            AutoJump();
        }
    }

    private void Jump()//左クリックでプレイヤージャンプ
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.up * upFore, ForceMode.Impulse);
        
    }
    private void AutoJump()//最下部で自動ジャンプ
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.up * 10, ForceMode.Impulse);
    }

    public void OnTriggerEnter(Collider other)
    {
        m_gm.m_totalTime -= 5;
        m_OnObst.Invoke();
    }

}
