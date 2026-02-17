using UnityEngine;

public class Catchable : MonoBehaviour
{
    public int scoreValue = 10;
    public AudioClip eatSound; // 🔊 skaņa, kad apēd donut

    public void Catch()
    {
        // Pieskaita punktus
        if (GameManager.I != null)
        {
            GameManager.I.AddScore(scoreValue);

            // 🔊 Atskaņo skaņu caur GameManager AudioSource
            if (eatSound != null)
            {
                GameManager.I.PlaySfx(eatSound);
            }
        }

        // Izdzēš donut
        Destroy(gameObject);
    }
}
