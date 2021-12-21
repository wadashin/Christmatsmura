using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class HitObstacles : MonoBehaviour
{
    [SerializeField] Image _frostImage;
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
    private bool moving;
    private bool _isFrost;

    void Start()
    {
        SubtractionText.enabled = false;
        text.text = "残りの時間は : " + time.ToString();
        //audioSource = sound.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            kekka = time - reduce;
            kekka2 = time - kekka;
            kekka = Mathf.Clamp(kekka, 0, 100000000);
            //audioSource.Play();
            SubtractionText.text = "-" + kekka2;
            Fadeo();
            DOTween.To(() => time, (n) => time = n, kekka, 0.1f)
                .OnUpdate(() => text.text = "残りの時間は : " + time.ToString());            
        }
    }

    public void Reset()
    {
        Sequence sequence = DOTween.Sequence().Append(_frostImage.DOFade(0f, 1f)).AppendCallback(() => { _frostImage.enabled = false; })
            .OnComplete(() => { _isFrost = false; });
        
    }
    public void Fadeo()
    {
        if (!moving)
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
                        SubtractionText.rectTransform.DOLocalMoveY(0, fadeOutTime);
                        moving = false;
                    });
                });
        }
        if (!_isFrost)
        {
            _isFrost = true;
            _frostImage.enabled = true;
            Sequence sequence = DOTween.Sequence().Append(_frostImage.DOFade(1f, 0.3f)).AppendCallback(() => { Invoke("Reset", 2f); });
        }
    }
}
