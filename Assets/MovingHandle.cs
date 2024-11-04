using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHandle : MonoBehaviour
{
    [SerializeField] private float obstacleDetectionRange = 1f;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private float moveSpeed = 500f;
    [SerializeField] private ZoneDetected zoneDetected;
    public bool facingRight = true;
    public bool targetInZoneAttack = false;

    Animator an;
    Rigidbody2D rb;
    SpriteRenderer render;


    void Start()
    {
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        GameObject target = zoneDetected.detectedObj != null ? zoneDetected.detectedObj.gameObject : null;
        if (target != null && targetInZoneAttack == false)
        {
            HandleMoving(target.transform.position);
        }
        else
        {
            an.SetBool("isMoving", false);
        }
    }

    void HandleMoving(Vector2 targetPosition)
    {
        Vector2 direction = (zoneDetected.detectedObj.transform.position - transform.position).normalized;

        if (IsObstacleInDirection(direction))
        {
            Vector2 newDirection = FindAlternativeDirection(direction);
            direction = newDirection;
        }

        MoveInDirection(direction);
        FlipSprite(direction);

        an.SetBool("isMoving", true);

    }

    bool IsObstacleInDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, obstacleDetectionRange, obstacleLayer);

        return hit.collider != null;
    }

    private Vector2 FindAlternativeDirection(Vector2 currentDirection)
    {
        float randomAngle = -90;

        Vector2 newDirection = Quaternion.Euler(0, 0, randomAngle) * currentDirection;

        return newDirection.normalized;
    }

    void MoveInDirection(Vector2 direction)
    {
        rb.AddForce(direction * moveSpeed * Time.deltaTime);
    }

    void FlipSprite(Vector2 direction)
    {
        render.flipX = direction.x < 0;
        // gameObject.BroadcastMessage("IsFacingRight", direction.x > 0);
    }


}
