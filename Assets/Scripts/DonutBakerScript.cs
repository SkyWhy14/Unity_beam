using System.Collections;
using UnityEngine;

public class DonutBakerScript : MonoBehaviour
{
    public GameObject[] donutPrefabs; // Changed from GameObject donutPrefab to GameObject[] donutPrefabs
    public float bakeInterval = 1.0f;
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
            StartCoroutine(SpawnDonut());
        }
        else
        {
            StopAllCoroutines();
        }
    }

    IEnumerator SpawnDonut()
    {
        while (true)
        {
            minpoz = ovenTransform.position.x - 1.0f;
            maxpoz = ovenTransform.position.x + 1.0f;
            float randPoz = Random.Range(minpoz, maxpoz);
            Vector2 spawnPoz = new Vector2(randPoz, ovenTransform.position.y);

            int donutIndex = Random.Range(0, donutPrefabs.Length); // Use donutPrefabs.Length
            Instantiate(donutPrefabs[donutIndex], spawnPoz, Quaternion.identity,ovenTransform);

            yield return new WaitForSeconds(bakeInterval);
        }
    }
}
