using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour
{
    public static int _TitleScore = 0;
    static List<int> scoreRank = new List<int>();
    [SerializeField] Text _RankText1st;
    [SerializeField] Text _RankText2nd;
    [SerializeField] Text _RankText3rd;
    void Start()
    {
        //scoreRank.Sort
    }

    void Update()
    {
        
    }
}
