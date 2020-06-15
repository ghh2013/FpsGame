using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float h;
    float v;
    
    public float speed = 5.0f;

    CharacterController cc;
       
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
        
    }

    private void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        //dir.Normalize();
        //transform.Translate(dir * speed * Time.deltaTime);

        dir = Camera.main.transform.TransformDirection(dir);
        //transform.Translate(dir * speed * Time.deltaTime);

        cc.Move(dir * speed * Time.deltaTime);
    }
}
