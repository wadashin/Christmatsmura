using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEScript : MonoBehaviour
{
    [SerializeField] int m_point = 10; //１加点量

    bool m_isPulusPoint = false; //加点するか否か


    [SerializeField] int _RandomMax = 13;
    [SerializeField] Text _Text;
    [SerializeField] Image _Image;
    [SerializeField] Button _Button;
    [SerializeField] GameObject RedHouse;
    [SerializeField] GameObject BlueHouse;
    [SerializeField] GameObject YellowHouse;

    //Random関数で出したランダムな数
    int randamNumber = 0;

    //家を動かすか否か
    public bool moveHouse = false;

    //家を入れる配列
    //GameObject[] house = new GameObject[3];

    //QTEをする状態かどうか。trueがQTE中、falseが移動中
    //bool qTESwitch = true;
    void Start()
    {
        SetUI();
        MakeRandom();
        QTE();

        //house[0] = RedHouse;
        //house[1] = BlueHouse;
        //house[2] = YellowHouse;
        //Instantiate(house[0]);
        //Instantiate(house[1]);
        //Instantiate(house[2]);
        //house[0].transform.position = new Vector3(0, 0, house[1].transform.position.z + 2);
        //house[1].transform.position = new Vector3(0, 0, 0);
        //house[2].transform.position = new Vector3(0, 0, house[1].transform.position.z - 2);
    }

    void Update()
    {
        QTE();
        Move();
        //Debug.Log(house[1].transform.position);
    }

    /// <summary>
    /// QTE時のText表示
    /// </summary>
    void QTE()
    {
        switch (randamNumber)
        {
            case 1:
                _Text.text = "1";
                if(Input.GetKeyDown(KeyCode.Alpha1))
                {
                    MakeRandom();
                }
                break;
            case 2:
                _Text.text = "2";
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    MakeRandom();
                }
                break;
            case 3:
                _Text.text = "3";
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    MakeRandom();
                }
                break;
            case 4:
                _Text.text = "Q";
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    MakeRandom();
                }
                break;
            case 5:
                _Text.text = "W";
                if (Input.GetKeyDown(KeyCode.W))
                {
                    MakeRandom();
                }
                break;
            case 6:
                _Text.text = "E";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    MakeRandom();
                }
                break;
            case 7:
                _Text.text = "A";
                if (Input.GetKeyDown(KeyCode.A))
                {
                    MakeRandom();
                }
                break;
            case 8:
                _Text.text = "S";
                if (Input.GetKeyDown(KeyCode.S))
                {
                    MakeRandom();
                }
                break;
            case 9:
                _Text.text = "D";
                if (Input.GetKeyDown(KeyCode.D))
                {
                    MakeRandom();
                }
                break;
            case 10:
                _Text.text = "Z";
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    MakeRandom();
                }
                break;
            case 11:
                _Text.text = "X";
                if (Input.GetKeyDown(KeyCode.X))
                {
                    MakeRandom();
                }
                break;
            case 12:
                _Text.text = "C";
                if (Input.GetKeyDown(KeyCode.C))
                {
                    MakeRandom();
                }
                break;
            case 13:
                _Text.gameObject.SetActive(false);
                _Button.gameObject.SetActive(true);
                break;
        }
    }
    /// <summary>
    /// QTE時のクリック判定
    /// </summary>
    void QTE2()
    {
        switch (randamNumber)
        {
            case 1:
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    MakeRandom();
                    Debug.Log("yes");
                }
                else
                {
                    //MakeRandom();
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    MakeRandom();
                    Debug.Log("yes");
                }
                else
                {
                    //MakeRandom();
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    MakeRandom();
                    Debug.Log("yes");
                }
                else
                {
                    //MakeRandom();
                }
                break;
            case 4:
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    MakeRandom();
                    Debug.Log("yes");
                }
                else
                {
                    //MakeRandom();
                }
                break;
            case 5:
                if (Input.GetKeyDown(KeyCode.W))
                {
                    MakeRandom();
                    Debug.Log("yes");
                }
                else
                {
                    //MakeRandom();
                }
                break;
            case 6:
                if (Input.GetKeyDown(KeyCode.E))
                {
                    MakeRandom();
                    Debug.Log("yes");
                }
                else
                {
                    //MakeRandom();
                }
                break;
            case 7:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    MakeRandom();
                    Debug.Log("yes");
                }
                else
                {
                    //MakeRandom();
                }
                break;
            case 8:
                if (Input.GetKeyDown(KeyCode.S))
                {
                    MakeRandom();
                    Debug.Log("yes");
                }
                else
                {
                    //MakeRandom();
                }
                break;
            case 9:
                if (Input.GetKeyDown(KeyCode.D))
                {
                    MakeRandom();
                    Debug.Log("yes");
                }
                else
                {
                    //MakeRandom();
                }
                break;
            case 10:
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    MakeRandom();
                    Debug.Log("yes");
                }
                else
                {
                    //MakeRandom();
                }
                break;
            case 11:
                if (Input.GetKeyDown(KeyCode.X))
                {
                    MakeRandom();
                    Debug.Log("yes");
                }
                else
                {
                    //MakeRandom();
                }
                break;
            case 12:
                if (Input.GetKeyDown(KeyCode.C))
                {
                    MakeRandom();
                    Debug.Log("yes");
                }
                else
                {
                    //MakeRandom();
                }
                break;
            case 13:
                break;
        }
    }

    void MakeRandom()
    {
        if(m_isPulusPoint == true)
        {
            GameManager.m_score += m_point;
        }
        else
        {
            m_isPulusPoint = true;
        }
        randamNumber = Random.Range(1, _RandomMax + 1);
    }

    void Move()
    {
        //if(house[0].transform.position.z >= 2)
        //{
        //    house[1].transform.position = new Vector3(0, 0, 2);
        //}
    }
    void SetUI()
    {
        _Button.gameObject.SetActive(false);
        _Image.gameObject.SetActive(true);
        _Text.gameObject.SetActive(true);
    }
    void SetUI2()
    {
        _Button.gameObject.SetActive(false);
        _Image.gameObject.SetActive(false);
        _Text.gameObject.SetActive(false);
    }
    //QTEでボタンをクリックした時の処理
    public void Click()
    {
        _Button.gameObject.SetActive(false);
        _Text.gameObject.SetActive(true);
        MakeRandom();
    }

    //void RandomHouse()
    //{
    //    int houseRandom = Random.Range(0, 3);
    //    switch(houseRandom)
    //    {
    //        case 0:
    //            house[2] = RedHouse;
    //            break;
    //        case 1:
    //            house[2] = BlueHouse;
    //            break;
    //        case 2:
    //            house[2] = YellowHouse;
    //            break;
    //    }
    //}
}
