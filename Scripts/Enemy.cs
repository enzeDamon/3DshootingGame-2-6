using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Enemy : MonoBehaviour
{
    public GameObject prefabBoomEffect;
    public float fireTime = 0.1f;
    public float speed = 2;
    public float maxHp = 1;
    private Vector3 input;
    private Transform player;
    private float hp;
    private bool dead = false;
    private Gun gun;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gun = GetComponent<Gun>();
        gun.pistolFireCD = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }
    private void Move()
    {

        input = player.position - transform.position;
        input = input.normalized;
        transform.position += input * speed * Time.deltaTime;
        if(input.magnitude > 0.1f)
        {
            transform.forward = -input;
        }
    }
    private void Fire()
    {
        gun.Fire(true, true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            if (hp <= 0)
            {
                return;
            }
            hp--;
            if (hp <= 0)
            {
                dead = true;
                Destroy(gameObject);
            }
        }
    }
}
