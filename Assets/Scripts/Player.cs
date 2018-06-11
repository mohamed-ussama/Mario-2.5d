using System;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{

    float Health = 10f;
    int lives = 3;


    public event Action OnPlayerDeath;

    private void Start()
    {

    }
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            OnPlayerDeath();
        }
    }
    public void TakeDamage(float damage)
    {
        if (Health > 0)
        {
            Health -= damage;
        }
        else
        {
            if (lives > 0)
            {
                OnPlayerDeath();
                lives--;
            }
            else
            {
                //lose Scene
            }

        }
    }



}
