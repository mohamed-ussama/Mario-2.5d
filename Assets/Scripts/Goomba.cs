using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    float damage = 10;

    Rigidbody rb;
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
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Invincable")
        {
            if (collision.transform.position.y > transform.position.y)
                Destroy(this.gameObject);

        }


    }

}
