using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 15.0f;
    public float lifeTime = 2;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= speed * transform.forward * Time.deltaTime;
        if (startTime + lifeTime < Time.time) { 
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag(other.tag))
        {
            return;
        }
        Destroy(gameObject);
      
    }
}
