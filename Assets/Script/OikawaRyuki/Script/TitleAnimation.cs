using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TitleAnimation : MonoBehaviour
{
    public float fadoTIme;
    public float _scaleChangeTime;
    public Image title2;
    private Image Image;
    private void Start()
    {
        Image = this.gameObject.GetComponent<Image>();
        Image.transform.localScale = Vector3.zero;
        Invoke("Ani", 1f);
    }
    private void Ani()
    {
        Image.transform.DOScale(1f, _scaleChangeTime).SetEase(Ease.OutSine)
            .OnComplete(() => {
                title2.enabled = true;
                title2.transform.DOScale(1.3f, 0.2f);
                title2.DOFade(0, fadoTIme);
            });
    }
}
