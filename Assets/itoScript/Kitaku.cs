using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitaku : MonoBehaviour
{
    [SerializeField] GameObject _scene1;
    [SerializeField] GameObject _scene2;
    private Animator _anime1;
    private Animator _anime2;

    [SerializeField] Idou  _idou;
    [SerializeField] Idou2 _idou2;

    GameObject _obj1;
    GameObject _obj2;


    [SerializeField] float _changTime = 2f;

    private void Start()
    {
    }
    //_idou._anime.SetTrigger("AttackTrigger");

    public void Kitakufeiz()
    {
        //_idou._anime.SetBool("Hanntei",true);
        _idou._anime.SetTrigger("Hanntei");
        //_idou2._anime2.SetBool("Hanntei2",true);
        _idou._anime.SetTrigger("Hanntei2");
        _scene1.SetActive(false);
        StartCoroutine(change());
    }

    IEnumerator change()
    {
        Debug.Log("");
        yield return new WaitForSeconds(_changTime);
        _scene2.SetActive(true);
    }
}
