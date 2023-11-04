using System;
using UnityEngine;

class Gun : MonoBehaviour
{
    [SerializeField] int ammo = 10;

    [SerializeField] int magazineSize = 10;
    [SerializeField] int magazineCount = 5;

    [SerializeField] AudioSource bangSound;
    [SerializeField] AudioSource clickSound;

    [SerializeField] GameObject bulletPrototype;
    [SerializeField] float bulletSpeed;

    void Update()
    {
        bool shoot = Input.GetKeyDown(KeyCode.Space);

        if (shoot)
        {
            if (ammo > 0)
            {
                Bang();
                ammo--;
            }
            else
            {
                Click();

                if (magazineCount > 0)
                {
                    magazineCount--;
                    ammo = magazineSize;
                }
            }
        }
    }

    void Click()
    {
        if (clickSound != null)
            clickSound.Play();
    }
    void Bang()
    {
        if(bangSound != null)
            bangSound.Play();       

        Vector3 p = transform.position;
        Quaternion r = Quaternion.LookRotation(transform.up);
        GameObject newBullet = Instantiate(bulletPrototype, p, r);
        newBullet.SetActive(true);

        Rigidbody newRb = newBullet.GetComponent<Rigidbody>();
        newRb.velocity = newBullet.transform.forward * bulletSpeed;
    }
}