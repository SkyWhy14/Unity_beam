using UnityEngine;

public class ObjectCatch : MonoBehaviour
{
    


    public float sizeIncrese = 0.5f;
    public float massIncrese = 1f;
    private Rigidbody2D rb;
    SFX_Script sfx;
    void Start()
    {
        sfx = FindFirstObjectByType<SFX_Script>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.IsChildOf(transform))
            return;

        if (collision.CompareTag("Donut"))
        {
            sfx.PlaySFX(2);
            Destroy(collision.gameObject);
            transform.localScale += new Vector3(sizeIncrese, sizeIncrese, 0f);
            rb.mass += massIncrese;
        }
        else
            Debug.Log("Collided with non-donut object: " + collision.gameObject.name);
    }
}

