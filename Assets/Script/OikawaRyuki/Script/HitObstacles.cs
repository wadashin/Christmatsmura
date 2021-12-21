﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class HitObstacles : MonoBehaviour
{
    [SerializeField] int time;
    [SerializeField] int reduce;
    private int kekka;
    private int kekka2;
    [SerializeField] Text text;
    //public GameObject sound;
    private AudioSource audioSource;
    [SerializeField]
    private Text SubtractionText;
    [SerializeField]
    float fadeInTime = 0.7f;
    [SerializeField]
    float fadeOutTime = 0.3f;
    [SerializeField]
    float delayTime = 0.4f;
    [SerializeField]
    float fadeInMoveDistance = 80f;
    [SerializeField]
    float fadeOutMoveDistance = 80f;
    [SerializeField] bool moving;

    void Start()
    {

        SubtractionText.enabled = false;
        text.text = "残りの距離は : " + time.ToString() + "km";
        //audioSource = sound.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("aaa");
        if(other.CompareTag("Obstacle"))
        kekka = time - reduce;
        kekka2 = time - kekka;
        kekka = Mathf.Clamp(kekka, 0, 100000000);
        //audioSource.Play();
        SubtractionText.text = "-" + kekka2;
        Fadeo();
        DOTween.To(() => time, (n) => time = n, kekka, 0.1f)
            .OnUpdate(() => text.text = "残りの距離は : " + time.ToString() + "km");
    }

    public void Fadeo()
    {
        if (moving == false)
        {
            moving = true;
            SubtractionText.enabled = true;
            SubtractionText.DOFade(1f, fadeInTime);
            SubtractionText.rectTransform.DOLocalMoveY(fadeInMoveDistance, fadeInTime)
                .SetRelative(true)
                .OnComplete(() =>
                {
                    //[leady]上へ移動＋フェードアウト
                    SubtractionText.DOFade(0f, fadeOutTime)
                    .SetDelay(delayTime);
                    SubtractionText.rectTransform.DOLocalMoveY(fadeOutMoveDistance, fadeOutTime)
                    .SetRelative(true)
                    .SetDelay(0.4f)
                    .OnComplete(() =>
                    {
                        SubtractionText.rectTransform.DOLocalMoveY(-fadeInMoveDistance, fadeOutTime);
                        moving = false;
                    });
                });
        }
        else
        {

        }
    }
}