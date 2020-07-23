using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //public Transform firePoint;
    public GameObject firePoint;
    public GameObject aimingLine;
    public GameObject bulletPrefab;
    public float firePointOffset = 0.2f;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void OnEnable()
    {
        firePoint.SetActive(true);
        aimingLine.SetActive(true);
    }

    private void OnDisable()
    {
        firePoint.SetActive(false);
        aimingLine.SetActive(false);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.transform.position + firePoint.transform.right * firePointOffset, firePoint.transform.rotation);
    }

}
