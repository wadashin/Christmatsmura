using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public static int _TitleScore = 0;
    static List<int> scoreRank = new List<int>() {0,0,0};
    [SerializeField] Text _RankText1st;
    [SerializeField] Text _RankText2nd;
    [SerializeField] Text _RankText3rd;
    void Start()
    {
        //scoreRank.Sort
        scoreRank.Add(_TitleScore);
        scoreRank.Sort((a, b) => b - a);
        _RankText1st.text = "最もますむらなスコア  " + scoreRank[0].ToString();
        _RankText2nd.text = "次にますむらなスコア  " + scoreRank[1].ToString();
        _RankText3rd.text = "ややますむらなスコア  " + scoreRank[2].ToString();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("GamePlayScene");
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Click();
        }
    }
    void Click()
    {
        int i = Random.Range(1, 100);
        scoreRank.Add(i);
        scoreRank.Sort((a, b) => b - a);
        _RankText1st.text = "最もますむらなスコア  " + scoreRank[0].ToString();
        _RankText2nd.text = "次にますむらなスコア  " + scoreRank[1].ToString();
        _RankText3rd.text = "ややますむらなスコア  " + scoreRank[2].ToString();
    }
}
