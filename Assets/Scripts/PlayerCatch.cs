using UnityEngine;

public class PlayerCatch : MonoBehaviour
{

    public AudioClip hitSfx;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.I == null || !GameManager.I.IsRunning)
            return;

        if (other.CompareTag("Donut"))
        {
            Catchable c = other.GetComponent<Catchable>();
            if (c != null)
                c.Catch();
            else
                Destroy(other.gameObject);

            return;
        }

        if (other.CompareTag("Hazard"))
        {
            if (hitSfx != null)
                GameManager.I.PlaySfx(hitSfx);

            GameManager.I.LoseLife(1);
            Destroy(other.gameObject);
        }
    }
}
