using TMPro;
using UnityEngine;

public class DonutDestroyerScript : MonoBehaviour
{
    private SFX_Script sfx;

    public TMP_Text counterText;
    private int destroyedDonuts = 0;

    [Header("Sounds (optional)")]
    public bool playSoundOnMissedDonut = true;  // ja gribi skaņu, kad donut nokrīt
    public int donutMissSfxIndex = 0;

    void Start()
    {
        sfx = FindFirstObjectByType<SFX_Script>();

        if (counterText == null)
            Debug.LogWarning("counterText nav piešķirts Inspectorā (TMP_Text)!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 💣 Hazard: vienkārši pazūd, HP nemaina
        if (collision.CompareTag("Hazard"))
        {
            Destroy(collision.gameObject);
            return;
        }

        // 🍩 Donut: pazūd, skaitītājs + (pēc izvēles) skaņa, BET HP nemaina
        if (collision.CompareTag("Donut"))
        {
            Destroy(collision.gameObject);
            destroyedDonuts++;

            if (playSoundOnMissedDonut && sfx != null)
                sfx.PlaySFX(donutMissSfxIndex);

            if (counterText != null)
                counterText.text = "Destroyed Donuts:\n" + destroyedDonuts;

            return;
        }
    }
}
