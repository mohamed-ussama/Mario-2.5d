using System;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{

    public float Health = 10f;
    int lives = 3;


    public event Action OnPlayerDeath;

    private void Start()
    {

    }
   
    public void TakeDamage(float damage)
    {
        Health -= damage;

        if (Health <0)
        {
            if (lives > 0)
            {
                OnPlayerDeath();
                lives--;
                Health = 10f;
            }
            else
            {
                //lose Scene
            }

        }
    }



}
