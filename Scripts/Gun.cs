using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPre;
    public float pistolFireCD = 0.2f;
    public float shotgunFireCD = 0.5f;
    public float rifleCD = 0.1f;
    // Start is called before the first frame update
    private float lastFireTime;
    public int curGun { get; private set; }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fire(bool keyDown, bool keyPressed)
    {
        switch (curGun)
        {
            case 0:
                if (keyDown) pistolFire();
                break;
            case 1:
                if (keyDown)
                    shotgunFire(); 
                break;
            case 2:
                if(keyPressed) rifleFire();
                break;
       
        }
        // I think  transform + new Vector(0, 0, 1£©is OK

       
    }
    private void pistolFire()
    {
        if (lastFireTime + pistolFireCD > Time.time)
        {
            return;
        }
        lastFireTime = Time.time;
        GameObject bullet = Instantiate(bulletPre, null);
        bullet.transform.position = transform.position - transform.forward * 1.0f;
        //adjust direction
        bullet.transform.forward = transform.forward;

    }
    private void rifleFire()
    {
        if (lastFireTime + rifleCD > Time.time)
        {
            return;
        }
        lastFireTime = Time.time;
        GameObject bullet = Instantiate(bulletPre, null);
        bullet.transform.position = transform.position - transform.forward * 1.0f;
        //adjust direction
        bullet.transform.forward = transform.forward;

    }
    private void shotgunFire()
    {
        if(lastFireTime + shotgunFireCD > Time.time)
        {
            return;
        }
        lastFireTime = Time.time;
        for (int i = -2; i <=2; i++)
        {
            GameObject bullet = Instantiate(bulletPre, null);
            Vector3 dir = Quaternion.Euler(0, i * 10, 0) * transform.forward;
            // why should I times 1.0f?
            bullet.transform.position = dir * -1.0f + transform.position;
            bullet.transform.forward = dir;

            EnemyBullet b = bullet.GetComponent<EnemyBullet>();
            b.lifeTime = 0.3f;
        }
    }
    public int Change()
    {
        curGun += 1;
        if (curGun == 3)
        {
            curGun = 0;
        }
        return curGun;
    }
}
