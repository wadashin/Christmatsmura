using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitaku : MonoBehaviour
{
    [SerializeField] GameObject _scene1;
    [SerializeField] GameObject _scene2;
    private Animation _anime;

    [SerializeField] float _changTime = 2f;

    public void Kitakufeiz()
    {
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
