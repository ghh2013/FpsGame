using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject fxFaxtory;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject fx = Instantiate(fxFaxtory);
        fx.transform.position = transform.position;
        //Destory(fx, 2.0f);
        Destroy(gameObject);
    }
}
