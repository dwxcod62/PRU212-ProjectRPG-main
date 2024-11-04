using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemyController : MonoBehaviour
{

    private string tagTarget = "Player";
    public Vector3 faceRight = new Vector3(0.13f, 0, 0);
    public Vector3 faceLeft = new Vector3(-0.13f, 0, 0);

    public Collider2D localPlayerCollider = null;
    public float damage = 1;


    Animator an;

    void Start()
    {
        an = GetComponentInParent<Animator>();
    }

    public void IsFacingRight(bool isRight)
    {
        if (isRight)
        {
            gameObject.transform.localPosition = faceRight;
        }
        else
        {
            gameObject.transform.localPosition = faceLeft;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        IDamageAble damageAble = col.GetComponent<IDamageAble>();

        if (damageAble != null && col.tag == tagTarget)
        {
            an.SetBool("Attacking", true);
            localPlayerCollider = col;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == tagTarget)
        {
            an.SetBool("Attacking", false);
            localPlayerCollider = null;
        }
    }

    public void CheckPlayerInHitbox()
    {
        if (localPlayerCollider != null)
        {
            IDamageAble damageAble = localPlayerCollider.GetComponent<IDamageAble>();

            if (damageAble != null)
            {
                damageAble.OnHit(damage);
            }
        }
    }
}
