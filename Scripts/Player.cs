using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // max hp
    public float maxHp = 20;
    //get speed
    public float speed = 5f;
    //current hp
    private float hp;
    //dead or not
    bool dead = false;
    private Gun gun;
    private void Awake()
    {
        gun = GetComponent<Gun>();
        hp = maxHp;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (!dead)
        {
            Move();
            Fire();
        }
    }
    private void Fire()
    {
        if (dead) return;
       
        bool fireKeyDown = Input.GetKeyDown(KeyCode.J);
        bool fireKeyPressed = Input.GetKey(KeyCode.J);
        bool changeWeapon = Input.GetKeyDown(KeyCode.Q);
        gun.Fire(fireKeyDown, fireKeyPressed);
        if (changeWeapon) gun.Change();
    }
        
    // Player moves
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 direction = new Vector3(h, 0, v);
        direction = direction.normalized;
        // adjust direction
        if (direction.magnitude > 0.1f)
        {
            transform.forward = direction;   
        }
        transform.position -= direction * speed * Time.deltaTime;
        const float BORDER = 20;
        Vector3 myPosition = transform.position;
        if (myPosition.z > BORDER) myPosition.z = BORDER;
        if (myPosition.z < -BORDER) myPosition.z = -BORDER;
        if (myPosition.x < -BORDER) myPosition.x = -BORDER;
        if (myPosition.x > BORDER) myPosition.x = BORDER;
        transform.position = myPosition;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(hp);
        if (other.CompareTag("EnemyBullet"))
        {
            if(hp <= 0)
            {
                return;
            }
            hp--;

            if (hp <= 0)
            {
                dead = true;

            }
        }
    }
}
