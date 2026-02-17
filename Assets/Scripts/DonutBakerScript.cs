using System.Collections;
using UnityEngine;

public class DonutBakerScript : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject[] donutPrefabs;          // parastie
    public GameObject[] hazardPrefabs;         // sliktais
    public GameObject[] specialDonutPrefabs;   // special (piem. zelta)

    [Header("Spawn Settings")]
    public float bakeInterval = 1.0f;
    public float spawnXRange = 1.0f; // tāpat kā tev bija -1 līdz +1

    [Header("Chances (0..1)")]
    [Range(0f, 1f)] public float hazardChance = 0.2f;   // 20%
    [Range(0f, 1f)] public float specialChance = 0.05f; // 5%
    // Pārējais automātiski būs normal donut

    float minpoz, maxpoz;
    Transform ovenTransform;

    void Start()
    {
        ovenTransform = GetComponent<Transform>();
    }

    public void BakeDonut(bool state)
    {
        if (state)
        {
            StartCoroutine(SpawnObjects());
        }
        else
        {
            StopAllCoroutines();
        }
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            minpoz = ovenTransform.position.x - spawnXRange;
            maxpoz = ovenTransform.position.x + spawnXRange;

            float randPoz = Random.Range(minpoz, maxpoz);
            Vector2 spawnPoz = new Vector2(randPoz, ovenTransform.position.y);

            // Random izvēle pēc iespējamībām
            float r = Random.value;

            // 1) Hazard
            if (r < hazardChance && hazardPrefabs != null && hazardPrefabs.Length > 0)
            {
                int ix = Random.Range(0, hazardPrefabs.Length);
                Instantiate(hazardPrefabs[ix], spawnPoz, Quaternion.identity, ovenTransform);
            }
            // 2) Special donut
            else if (r < hazardChance + specialChance && specialDonutPrefabs != null && specialDonutPrefabs.Length > 0)
            {
                int ix = Random.Range(0, specialDonutPrefabs.Length);
                Instantiate(specialDonutPrefabs[ix], spawnPoz, Quaternion.identity, ovenTransform);
            }
            // 3) Normal donut
            else
            {
                if (donutPrefabs != null && donutPrefabs.Length > 0)
                {
                    int ix = Random.Range(0, donutPrefabs.Length);
                    Instantiate(donutPrefabs[ix], spawnPoz, Quaternion.identity, ovenTransform);
                }
            }

            yield return new WaitForSeconds(bakeInterval);
        }
    }
}
