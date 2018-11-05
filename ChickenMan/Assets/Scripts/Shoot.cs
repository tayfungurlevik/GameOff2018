﻿using System;
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
    private void Awake()
    {
        lastShootingPoint = shootingPoint2.position;
    }


    private void ShootBullet()
    {
        Vector3 shootFrom = ToggleShootingPoint();
        
        Vector3 direction =  GetDirection(shootFrom) ;
        var projectile = Instantiate(bulletToShoot, shootFrom, Quaternion.Euler(direction));
        projectile.GetComponent<Rigidbody>().velocity = direction * moveSpeed;
        lastShootingPoint = shootFrom;
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
        if (Physics.Raycast(ray, out hitInfo))
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
        if (Input.GetButtonDown("Fire1"))
        {
            
                ShootBullet();
            
            
           
        }
    }
}