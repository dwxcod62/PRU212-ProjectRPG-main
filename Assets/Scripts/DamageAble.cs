using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageAble : MonoBehaviour, IDamageAble
{

    [SerializeField] private float health = 3f;
    [SerializeField] private float maxHealth = 3f;

    [SerializeField] private Image HeathBarFill;

    Animator animator;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", true);

        if (HeathBarFill != null)
        {
            HeathBarFill.fillAmount = health / maxHealth;
        }

    }
    public float Health
    {
        set
        {
            if (value < health)
            {
                animator.SetTrigger("hit");

            }



            health = value;

            if (HeathBarFill != null)
                HeathBarFill.fillAmount = health / maxHealth;

            if (health <= 0)
            {
                animator.SetBool("isAlive", false);
            }
        }
        get
        {
            return health;
        }
    }

    public void OnHit(float damage)
    {
        Health -= damage;
    }

    public void OnHit(float damage, Vector2 knockBackValue)
    {
        Health -= damage;
        rb.AddForce(knockBackValue);
    }
}