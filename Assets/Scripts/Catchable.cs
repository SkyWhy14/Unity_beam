using UnityEngine;

public class Catchable : MonoBehaviour
{
    public int scoreValue = 10;

    public void Catch()
    {
        if (GameManager.I != null)
            GameManager.I.AddScore(scoreValue);

        Destroy(gameObject);
    }
}
