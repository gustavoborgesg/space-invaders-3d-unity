using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ammo : MonoBehaviour
{
    /* Visuals */
    public GameObject projectilePrefab;
    
    public GameObject projectileImpactPrefab;
    public float projectileImpactDuration = 1f;
    public float projectileImpactRecharge = 0.001f;
    private float _lastImpactTime = 0f;

    public float projectileArcRangeMin = 0f;
    public float projectileArcRangeMax = 0f;
    public float projectileArcTimeMin  = 0f;
    public float projectileArcTimeMax  = 0f;
    
    private float _projectileArcCurTime = 0f;
    private float _projectileArcCurSign = 0f;
    
    /* Gameplay */
    public GameObject shooter;
    public float      speed          = 20f;
    public int        damage         = 0;
    public bool       hitDestroyable = true;
    
    public float disappearDistance = 1000f;
    private Vector3 _shootOrigin;

    void Start()
    {
        _shootOrigin = transform.position;
        
        Instantiate(projectilePrefab, transform);
        
        while (_projectileArcCurSign == 0)
        {
            _projectileArcCurSign = Mathf.Sign(Random.Range(-1, 1));
        }
    }

    void Update()
    {
        _projectileArcCurTime -= Time.deltaTime;
        
        if (_projectileArcCurTime <= 0f)
        {
            _projectileArcCurSign = -_projectileArcCurSign;
            
            float arcX = _projectileArcCurSign * Random.Range(projectileArcRangeMin, projectileArcRangeMax);

            _projectileArcCurTime = Random.Range(projectileArcTimeMin, projectileArcTimeMax);
            iTween.PunchPosition(gameObject, new Vector3(arcX, 0, 0), _projectileArcCurTime);
        }
        
        if ((transform.position - _shootOrigin).magnitude > disappearDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        float curTime = Time.time;

        if (curTime >= _lastImpactTime + projectileImpactRecharge)
        {
            GameObject impact = Instantiate(projectileImpactPrefab, transform.position, Quaternion.identity);
            Destroy(impact, projectileImpactDuration);

            _lastImpactTime = Time.time;
        }

        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            Destroy(otherCollider.gameObject);
        }

        if (hitDestroyable)
        {
            Destroy(gameObject);
        }
    }
}