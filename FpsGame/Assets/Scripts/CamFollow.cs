using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    //public Transform target;
    public float speed = 10.0f;
    
    public Transform target1st;
    public Transform target3rd;
    bool isFPS = true;

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

        if(isFPS)
        {
            transform.position = target1st.position;

        }
        else
        {
            transform.position = target3rd.position;
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
