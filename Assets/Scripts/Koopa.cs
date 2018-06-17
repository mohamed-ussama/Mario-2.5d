using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koopa : MonoBehaviour {

    float damage = 10f;
    public bool canMove=true;
    float t=0;
    private void Start()
    {
        //StartCoroutine(Paralized());
    }
    private void Update()
    {
        if (!canMove)
        {
            
            if (t < 6f)
            {

                t += Time.deltaTime ;
               
            }
            else
            {
                GetComponent<WayPointsMovement>().enabled = true;
                canMove = true;
                Debug.Log("now i can move again");
                t = 0;
            }
        }
        else
        {

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            other.GetComponent<Player>().TakeDamage(damage);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            
            if (canMove)
            {
                canMove = false;
                GetComponent<WayPointsMovement>().enabled=false;

               

            }
            else
            {
                collision.gameObject.GetComponent<Controller2D>().Jump();
                Destroy(this.gameObject);
            }
           
        }
        
    }

   
}
