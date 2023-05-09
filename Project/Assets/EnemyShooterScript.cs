using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShooterScript : MonoBehaviour
{
    public GameObject ammoPrefab;

    public float minRechargeTime = 0f;
    public float maxRechargeTime = 0f;
    
    private float _curRechargeTime = 0f;
    private float _lastShotTime = 0f;

    private void Start()
    {
        UpdateRecharge();
    }

    void Update()
    {
        Vector3 size = GetComponent<MeshCollider>().bounds.size;
        
        bool shouldShoot = Recharged();

        Vector3 rayOrigin = transform.position + (1.95f * size.y / 2) * transform.forward;
        rayOrigin.z = 0f;
        
        Ray ray = new Ray(rayOrigin, transform.forward);
        
        RaycastHit[] hits = Physics.RaycastAll(ray);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.gameObject.GetComponent<Enemy>() != null)
            {
                shouldShoot = false;
            }
        }

        if (shouldShoot)
        {
            InstantiateAmmo(rayOrigin, transform.forward);
            UpdateRecharge();
        }
    }

    bool Recharged()
    {
        return Time.time - _lastShotTime > _curRechargeTime;
    }

    void UpdateRecharge()
    {
        _curRechargeTime = Random.Range(minRechargeTime, maxRechargeTime);
        _lastShotTime = Time.time;
    }
    
    void InstantiateAmmo(Vector3 firePoint, Vector3 direction)
    {
        GameObject ammo = Instantiate(ammoPrefab, firePoint, Quaternion.identity);
        ammo.GetComponent<Rigidbody>().velocity = direction * ammo.GetComponent<Ammo>().speed;
        ammo.GetComponent<Ammo>().shooter = gameObject;
    }
}
