using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseMove : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject qteObj;
    QTEScript qteScript;
    void Start()
    {
        qteObj = GameObject.Find("QTEObject");
        qteScript = qteObj.GetComponent<QTEScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (qteScript.moveHouse == true)
        {
            transform.Translate(0, 0, 0.1f);
        }
        else
        {
            transform.Translate(0, 0, 0f);
        }
    }
}
