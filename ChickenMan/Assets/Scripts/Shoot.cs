using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]private Transform shootingPoint1;
    [SerializeField] private Transform shootingPoint2;
    [SerializeField]private EggBullet bulletToShoot;
    
    [SerializeField]
    private float moveSpeed = 40;
    private RaycastHit hitInfo;
    [SerializeField]
    private float maxDistance = 100;
    [SerializeField]
    private LayerMask layerMask;
    private Vector3 lastShootingPoint;
    [SerializeField]
    private float timeToNextShot = 0.25f;
    private float bulletTimer = 0f;
    private Animator animator;
    private AudioSource audioSource;
    [SerializeField]
    private Stats statistics;
    private void Awake()
    {
        lastShootingPoint = shootingPoint2.position;
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    private void ShootBullet()
    {
        Vector3 shootFrom = ToggleShootingPoint();
        
        Vector3 direction =  GetDirection(shootFrom) ;
        //var projectile = Instantiate(bulletToShoot, shootFrom, Quaternion.Euler(direction));
        var projectile = bulletToShoot.Get<EggBullet>(shootFrom, Quaternion.identity);
        
        projectile.GetComponent<Rigidbody>().velocity = direction * moveSpeed;
        
        lastShootingPoint = shootFrom;
        bulletTimer = 0f;
        statistics.TotalNumberOfShotsMade++;
    }

    private Vector3 ToggleShootingPoint()
    {
        if (lastShootingPoint == shootingPoint1.position)
        {
            return shootingPoint2.position;
        }
        else
            return shootingPoint1.position;
    }

    private Vector3 GetDirection(Vector3 shootPos)
    {
        var ray = Camera.main.ViewportPointToRay(Vector3.one / 2f);

        Vector3 target = ray.GetPoint(300);
        if (Physics.Raycast(ray, out hitInfo,maxDistance,layerMask))
        {
            target = hitInfo.point;
        }
        Vector3 direction = target - shootPos;
        direction.Normalize();
        return direction;
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.Paused)
        { 
            bulletTimer += Time.deltaTime;
            if (CanShoot())
            {
                if (Input.GetButton("Fire1") || (Input.GetAxis("XboxRT") == 0 ? false : true))
                {
                    animator.SetTrigger("Shoot");
                    audioSource.Play();
                    ShootBullet();
                }
            }
        }
        
        
    }

    private bool CanShoot()
    {
        return bulletTimer >= timeToNextShot;
    }
}
