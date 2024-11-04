using UnityEngine;

public class ZoneDetected : MonoBehaviour
{

    private string targetTag = "Player";
    public Collider2D detectedObj = null;

    public bool PlayerIn = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(targetTag))
        {
            IDamageAble damageAble = col.GetComponent<IDamageAble>();

            if (damageAble.Health > 0)
            {
                detectedObj = col;
                PlayerIn = true;
            }
            else
            {
                detectedObj = null;
                PlayerIn = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag(targetTag))
        {
            detectedObj = null;
            PlayerIn = false;
        }
    }

}
