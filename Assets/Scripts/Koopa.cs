using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koopa : MonoBehaviour {

    float damage = 10f;
    public bool canMove=true;
    float t=0;
    Rigidbody rb;
    
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
        if (other.tag == "Player")
        {
            rb = other.GetComponent<Rigidbody>();
            Vector3 direction = other.transform.position - transform.position;

            rb.AddForce(direction * 2, ForceMode.VelocityChange);
            if ((other.transform.position - transform.position).magnitude > 4f)
            {
                rb.velocity = Vector3.zero;
            }
            other.GetComponent<Player>().TakeDamage(damage);


        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            rb = other.GetComponent<Rigidbody>();
            Vector3 direction = other.transform.position - transform.position;

            rb.AddForce(direction * 6, ForceMode.VelocityChange);
            if ((other.transform.position - transform.position).magnitude > 4f)
            {
                rb.velocity = Vector3.zero;
            }


        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player"|| collision.gameObject.tag == "Invincable" )
        {
            if (collision.transform.position.y> transform.position.y)
            {
                if (canMove)
                {
                    canMove = false;
                    GetComponent<WayPointsMovement>().enabled = false;



                }
                else
                {
                    collision.gameObject.GetComponent<Controller2D>().Jump();
                    Destroy(this.gameObject);
                }
            }
            
           
        }
        
    }

   
}
