using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{

    public ZoneDetected zoneDetected;
    public float moveSpeed = 500f;

    public event Action<GameObject> OnEnemyDestroyed;

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
        if (zoneDetected.detectedObj != null)
        {
            Vector2 direction = (zoneDetected.detectedObj.transform.position - transform.position).normalized;
            rb.AddForce(direction * moveSpeed * Time.deltaTime);


            if (direction.x < 0)
            {
                render.flipX = true;
                gameObject.BroadcastMessage("IsFacingRight", false);

            }
            else if (direction.x > 0)
            {
                render.flipX = false;
                gameObject.BroadcastMessage("IsFacingRight", true);

            }
        }
    }

    void Die()
    {
        GetComponent<LootBag>().InstantiateLoot(transform.localPosition);
        Destroy(gameObject);

    }

    void OnDestroy()
    {
        if (OnEnemyDestroyed != null)
        {
            OnEnemyDestroyed(gameObject);
        }
    }

    void CheckPlayer()
    {
        gameObject.BroadcastMessage("CheckPlayerInHitbox");
    }

    void IsFacingRight(bool isRight)
    {

    }

}
