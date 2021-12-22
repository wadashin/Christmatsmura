using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float _Posi;
    [SerializeField] Text _MuraName;
    string a = "クリス増す村";
    string b = "クリス増す村";
    string[] strArray = new string[5] { "クリス増す村", "リスク増す村", "クスリ増す村", "田中増す村", "佐藤増す村" };
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HouseInstasiate()
    {
        int i = Random.Range(0,5);
        _MuraName.text = strArray[i];
        var x = this.gameObject;
        var y = Instantiate(x);
        y.transform.position = new Vector3(x.transform.position.x, x.transform.position.y, x.transform.position.z - 180);
        y.transform.parent = GameObject.Find("Phase1").transform;
    }
    public void HomeDes()
    {
        Destroy(this.gameObject);
    }
}
