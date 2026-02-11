using TMPro;
using UnityEngine;

public class DonutDestroyerScript : MonoBehaviour
{
    SFX_Script sfx;
    public TMP_Text counterText;
    private int destroyedDonuts = 0;

    void Start()
    {
        sfx = FindFirstObjectByType<SFX_Script>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Donut"))
        {

            Destroy(collision.gameObject);
            destroyedDonuts++;
            sfx.PlaySFX(0);
            counterText.text = "Destroyed Donuts: \n" + destroyedDonuts;
        }
    }


}
