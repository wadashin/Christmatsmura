using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Reducedistance : MonoBehaviour
{
    [SerializeField] int distance;
    [SerializeField] int reduce;
    private int kekka;
    private int kekka2;
    [SerializeField] Text text;
    public GameObject sound;
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
    [SerializeField] GameObject GetImage;


    void Start()
    {
        SubtractionText.enabled = false;
        text.text = "残りの距離は : " + distance.ToString() + "km";
        audioSource = sound.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            //合計距離を計算
            kekka = distance - reduce;
            //減った距離を計算
            kekka2 = distance - kekka;
            kekka = Mathf.Clamp(kekka, 0, 100000000);
            audioSource.Play();
            //減った距離を表示
            SubtractionText.text = "-" + kekka2;
            Destroy(other.gameObject);
            Fadeo();
            //計算結果を代入
            DOTween.To(() => distance, (n) => distance = n, kekka, 0.1f)
                .OnUpdate(() => text.text = "残りの距離は : " + distance.ToString() + "km");
        }
        
    }

    public void Fadeo()
    {
        if(moving == false)
        {
            //フェードイン
            moving = true;

            GetImage.SetActive(true);
            SubtractionText.enabled = true;
            SubtractionText.DOFade(1f, fadeInTime);
            SubtractionText.rectTransform.DOLocalMoveY(fadeInMoveDistance, fadeInTime)
                .SetRelative(true)
                .OnComplete(() =>
                {
                    //フェードアウト
                    SubtractionText.DOFade(0f, fadeOutTime)
                    .SetDelay(delayTime);
                    SubtractionText.rectTransform.DOLocalMoveY(fadeOutMoveDistance, fadeOutTime)
                    .SetRelative(true)
                    .SetDelay(0.4f)
                    .OnComplete(() =>
                    {
                        //指定された位置に戻る
                        GetImage.SetActive(false);
                        SubtractionText.rectTransform.DOLocalMoveY(-40, fadeOutTime);
                        moving = false;
                    });
                });
        }

    }
}
