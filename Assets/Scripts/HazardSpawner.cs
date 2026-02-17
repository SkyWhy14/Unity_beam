using System.Collections;
using UnityEngine;

public class HazardBakerScript : MonoBehaviour
{
    public GameObject[] hazardPrefabs; // masīvs ar bīstamajiem objektiem
    public float spawnInterval = 2.0f;

    float minpoz, maxpoz;
    Transform spawnerTransform;

    void Start()
    {
        spawnerTransform = GetComponent<Transform>();
        StartCoroutine(SpawnHazard());
    }

    IEnumerator SpawnHazard()
    {
        while (GameManager.I != null && GameManager.I.IsRunning)
        {
            minpoz = spawnerTransform.position.x - 1.0f;
            maxpoz = spawnerTransform.position.x + 1.0f;

            float randPoz = Random.Range(minpoz, maxpoz);
            Vector2 spawnPoz = new Vector2(randPoz, spawnerTransform.position.y);

            int hazardIndex = Random.Range(0, hazardPrefabs.Length);
            Instantiate(hazardPrefabs[hazardIndex], spawnPoz, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
