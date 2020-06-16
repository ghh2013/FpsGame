using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    
 

    public GameObject bulletImpactFactory;
    public GameObject firePoint;
    public GameObject bombFactory;
    public float throwPower = 20.0f;

    
   
    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo;

            if(Physics.Raycast(ray, out hitInfo))
            {
                print("충돌오브젝트:" + hitInfo.collider.name);
                GameObject bulletImpact = Instantiate(bulletImpactFactory);
                bulletImpact.transform.position = hitInfo.point;
                bulletImpact.transform.forward = hitInfo.normal;
            }
            //int layer = gameObject.layer;
            //layer = 1 << 8;
            //layer = 1 << 8 | 1 << 9 | 1 << 12;
            //if(Physics.Raycast(ray,out hitInfo,100,layer))
            //if (Physics.Raycast(ray, out hitInfo, 100, ~layer))
            //{

            //}
            
        }
        if (Input.GetMouseButtonDown(1))
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePoint.transform.position;
            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            //rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);

            Vector3 dir = Camera.main.transform.forward + Camera.main.transform.up;
            dir.Normalize();
            rb.AddForce(dir * throwPower, ForceMode.Impulse);
            //Vector3 dir = Camera.main.transform.forward + ((Camera.main.transform.up * 0.5f);
            //rb.AddForce(dir * throwPower, ForceMode.Impulse);
        }
    }
}
