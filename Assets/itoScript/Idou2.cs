using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idou2 : MonoBehaviour
{
    public Animator _anime2;
    // Start is called before the first frame update
    void Start()
    {
        _anime2 = GetComponent<Animator>();
        _anime2.SetBool("Hanntei2", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
