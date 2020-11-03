using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform Gun;

    Vector2 direction;

    public GameObject Bullet;
    public float bulletspeed;
    public Transform ShootPoint;

    public float fireRate;
    float nextShoot;
    private object other;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeleteBullete", 2);

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Gun.position;
        FaceMouse();
        ButtonPressCheck();
    }

    void FaceMouse()
    {
        Gun.transform.right = direction;
    }

    void ButtonPressCheck()
    {
        if(Input.GetMouseButton(0))
        {
            if(Time.time > nextShoot)
            {
                nextShoot = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * bulletspeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet")
        {
            Destroy(collision.gameObject);

        }
    }

    void DeleteBullet()
    {
        Destroy(Bullet);
    }
}
