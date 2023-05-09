using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovementShip : MonoBehaviour
{
    public Rigidbody playerBody;
    public MeshCollider playerCollider;
    
    public Camera mainCamera;
    public float speed = 1f;

    public float rollSpeed = 1f;
    public float maxRollAngle = 30f;

    private float _rotationY = 0f;
    
    void Update()
    {
        Move();
        Roll();
    }

    void Move()
    {
        Vector3 blBound = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 trBound = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));
        
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * (horizontal * speed);

        float playerX = transform.position.x;
        float halfPlayerSizeX = playerCollider.bounds.size.x / 2;

        transform.position = new Vector3(Mathf.Clamp(playerX, blBound.x + halfPlayerSizeX, trBound.x - halfPlayerSizeX), transform.position.y, transform.position.z);
        playerBody.velocity = new Vector3(move.x, playerBody.velocity.y, playerBody.velocity.z);
    }

    void Roll()
    {
        float horizontal = Input.GetAxis("Horizontal");
        _rotationY -= horizontal * Time.deltaTime * rollSpeed;
        _rotationY -= _rotationY / maxRollAngle * Time.deltaTime * rollSpeed;

        _rotationY = Mathf.Clamp(_rotationY, -maxRollAngle, maxRollAngle);

        transform.localRotation = Quaternion.Euler(-90f, _rotationY, 0f);
    }
}
