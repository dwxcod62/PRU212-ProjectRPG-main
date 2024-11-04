using UnityEngine;

public class SkeletonBossController : MonoBehaviour
{
    [SerializeField] private BulletController skillPrefab;

    Animator an;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        an = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        an.SetBool("isMoving", false);
        Attack(1);
    }

    public void Attack(int skill)
    {
        an.SetTrigger("Attack");
        an.SetInteger("idSkill", skill);
    }

    public void firstSkill()
    {
        Collider2D temp = GetComponentInChildren<ZoneDetected>().detectedObj;
        Vector2 targetPosition = Vector2.zero;

        if (temp != null)
        {
            targetPosition = temp.gameObject.transform.localPosition;
        }

        bool facingRight = GetComponent<MovingHandle>().facingRight;

        Vector2 currentPosition = transform.position;

        Vector2 screenPosition = gameObject.transform.position;
        float offsetWidth = spriteRenderer.bounds.size.x / 4 * (facingRight ? 1 : -1);
        Vector2 skillPosition = new Vector2(screenPosition.x + offsetWidth, screenPosition.y);
        var skill = Instantiate(skillPrefab, skillPosition, Quaternion.identity);

        Vector2 direction = (targetPosition - skillPosition).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        skill.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        Rigidbody2D skillRb = skill.GetComponent<Rigidbody2D>();
        skillRb.velocity = direction * 0.5f;
    }

}
