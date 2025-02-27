﻿using UnityEngine;

public class TurretAttack : MonoBehaviour, ITurretState
{
    public TurretAI turret { get; set; }
    
    private Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        turret = this.GetComponent<TurretAI>();
    }
    
    public void Enter()
    {
        
    }

    public void Stay()
    {
        Shoot();
    }

    public void Exit()
    {
        
    }
    
    private void Shoot()
    {
        turret.ps.Play();
        anim.SetTrigger("Shoot");
        CreateBullet();

        turret.ChangeToTracking();
    }

    private void CreateBullet()
    {
        GameObject bullet = Instantiate(turret.bulletPrefab, turret.shootTf.position, turret.shootTf.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(turret.shootTf.forward * 50f, ForceMode.Impulse);
    }
}