using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;
    Vector3 deathPosition;
    Vector3 nearestPoint;
    [SerializeField]
    Transform[] spawnPoints;
    [SerializeField]
    GameObject player;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        player.GetComponent<Player>().OnPlayerDeath += DeathPosition;
        player.GetComponent<Player>().OnPlayerDeath += Spawner;

    }
    void Spawner()
    {
        nearestPoint = spawnPoints[0].position;
        for (int i =0; i<spawnPoints.Length-1;i++ )
        {
            if (Vector3.Distance(deathPosition, nearestPoint) 
                > Vector3.Distance(deathPosition, spawnPoints[i+1].position))
            {
                nearestPoint = spawnPoints[i+1].position;
            }
        }
        player.transform.position = nearestPoint;
        Debug.Log("Spawner Spawner");

    }
    void DeathPosition()
    {
        deathPosition = player.transform.position;
        Debug.Log("death position");
    }
    
    
}
