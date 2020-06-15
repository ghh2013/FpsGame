using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    //public Transform target;
    public float speed = 5.0f;
    
    public Transform target1st;
    public Transform target3st;
    bool isFPS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = target.position;

        //FollowTarget();

        ChangeView();

    }

    private void ChangeView()
    {
        if (Input.GetKeyDown("1"))
        {
            isFPS = true;
        }
        if (Input.GetKeyDown("3"))
        {
            isFPS = false;
        }

    }

    //    private void FollowTarget()
    //{
    //    Vector3 dir = target.position - transform.position;
    //    dir.Normalize();
    //    transform.Translate(dir * speed * Time.deltaTime);

    //    if(Vector3 .Distance (transform .position ,target .position )<1.0f)
    //    {
    //        transform.position = target.position;
    //    }
    //}
}
