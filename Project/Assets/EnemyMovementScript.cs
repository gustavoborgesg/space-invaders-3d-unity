using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public float maxDisplacementX = 50f;
    public float forwardSpeed = 20f;
    public float displacementSpeed = 1f;

    private float _curDisplacementX = 0f;
    private int _curDirectionXSign = 1;

    void FixedUpdate()
    {
        Transform newTransform = transform;
        
        float deltaX = _curDirectionXSign * displacementSpeed * Time.deltaTime;
        
        if (Mathf.Abs(_curDisplacementX + deltaX) >= maxDisplacementX)
        {
            _curDirectionXSign *= -1;
            newTransform.position += forwardSpeed * newTransform.forward;
        }
        
        deltaX = Mathf.Clamp(deltaX, -maxDisplacementX - _curDisplacementX, maxDisplacementX - _curDisplacementX);
        _curDisplacementX += deltaX;

        newTransform.position += deltaX * newTransform.right;
    }
}
