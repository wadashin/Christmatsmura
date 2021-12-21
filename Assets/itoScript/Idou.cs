using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idou : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator _anime;
    void Start()
    {
        _anime = GetComponent<Animator>();
        _anime.SetBool("Step1", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
