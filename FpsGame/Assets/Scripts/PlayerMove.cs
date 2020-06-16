using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;

    CharacterController cc;

    public float gravity = -20;
    float velocityY;
    float jumpPower = 10;

    int jumpCount = 0;
       
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
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        //dir.Normalize();
        //transform.Translate(dir * speed * Time.deltaTime);

        dir = Camera.main.transform.TransformDirection(dir);
        //transform.Translate(dir * speed * Time.deltaTime);

        //cc.Move(dir * speed * Time.deltaTime);
        //velocityY += gravity * Time.deltaTime;
        //dir.y = velocityY;
        //cc.Move(dir * speed * Time.deltaTime);

        //if(cc.isGrounded)
        //{

        //}
        //if(cc.collisionFlags == CollisionFlags.Below)
        //{
        //    velocityY = 0;
        //}
        //if(Input .GetButtonDown ("Jump"))
        //{
        //    velocityY = jumpPower;
        //}

        //if (cc.isGrounded)
        //{
        //    velocityY = 0;
        //    jumpCount = 0;
        //}
        if(cc.collisionFlags == CollisionFlags.Below)
        {
            velocityY = 0;
            jumpCount = 0;
        }
        else
        {
            velocityY += gravity * Time.deltaTime;
            dir.y = velocityY;
        }
        if (Input.GetButtonDown ("Jump") && jumpCount < 2)
        {
            jumpCount++;
            velocityY = jumpPower;
           
        }
        cc.Move(dir * speed * Time.deltaTime);
        
    }
}
