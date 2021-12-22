using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelBall : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
