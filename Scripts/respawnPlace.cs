using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class respawnPlace : MonoBehaviour
{
    // this is used stored the EnemyPrefabs
    public GameObject EnemyPrefab;
    // fixed time interval, can be adjusted
    public float respawnInterval = 3.0f;
    private float currentInterval;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        currentInterval = respawnInterval;
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentInterval -= Time.deltaTime;
        if (currentInterval < 0)
        {   
            currentInterval = respawnInterval;
            GameObject temp = Instantiate(EnemyPrefab, null);
            temp.transform.position = transform.position;
            Vector3 direction = player.position - transform.position;
            direction = direction.normalized;
            temp.transform.forward = -direction;

        }
        
    }
}
