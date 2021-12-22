using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float _Posi;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HouseInstasiate()
    {
        var x = this.gameObject;
        var y = Instantiate(x);
        y.transform.position = new Vector3(x.transform.position.x, x.transform.position.y, x.transform.position.z - 180);
    }
    public void HomeDes()
    {
        Destroy(this.gameObject);
    }
}
