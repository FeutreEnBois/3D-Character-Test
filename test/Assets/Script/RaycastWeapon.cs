using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    class Bullet
    {
        public float time;
        public Vector3 initialPosition;
        public Vector3 initialVelocity;
    }

    public bool isFiring = false;
    public float fireRate = 25; // in bullet per seconds
    public float bulletSpeed = 1000.0f;
    public float bulletDrop = 0.0f;
    public ParticleSystem muzzleFlash;
    public ParticleSystem hitEffect;
    public Transform raycastOrigin;
    public Transform raycastDestination;
    public TrailRenderer trailRenderer;

    Ray ray;
    RaycastHit hitInfo;
    float accumulatedTime; // when are we suppose to fire a bullet
    List<Bullet> bullets = new List<Bullet>();

    Vector3 GetPosition(Bullet bullet)
    {
        // p + v*t + 0.5*g*t*t
        Vector3 gravity = Vector3.down * bulletDrop;
        return (bullet.initialPosition) + (bullet.initialVelocity * bullet.time) + (0.5f * gravity * bullet.time * bullet.time);
    }

    Bullet CreateBullet(Vector2 position, Vector2 velocity)
    {
        Bullet bullet = new Bullet();
        bullet.initialPosition = position;
        bullet.initialVelocity = velocity;
        bullet.time = 0.0f;
        return bullet;
    }

    public void StartFiring()
    {
        isFiring = true;

        FireBullet();
    }


    public void UpadateFiring(float deltaTime)
    {
        accumulatedTime += deltaTime;
        float fireInterval = 1.0f / fireRate;
        while(accumulatedTime >= 0.0)
        {
            FireBullet();
            accumulatedTime -= fireInterval;
        }
    }

    private void FireBullet()
    {
        muzzleFlash.Emit(1);

        //Vector3 velocity;
        //bullet = CreateBullet(raycastOrigin.position);


        //ray.origin = raycastOrigin.position;
        //ray.direction = raycastDestination.position - raycastOrigin.position;

        //var tracer = Instantiate(trailRenderer, ray.origin, Quaternion.identity);
        //tracer.AddPosition(ray.origin);

        //if (Physics.Raycast(ray, out hitInfo))
        //{
        //    hitEffect.transform.position = hitInfo.point;
        //    hitEffect.transform.forward = hitInfo.normal;
        //    hitEffect.Emit(1);
        //    tracer.transform.position = hitInfo.point;
        //}
    }

    public void StopFiring()
    {
        isFiring=false;
    }
}
