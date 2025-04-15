using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject obstacle; // our obstacle prefab
    float rate = 2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        if (rate <= 0.0001)
            yield return null;

        yield return new WaitForSecondsRealtime(rate);
        Instantiate(obstacle, new Vector3(Random.Range(-7.5f,7.5f), 6, 0), Quaternion.identity);
        rate /= 2;
        StartCoroutine(Spawner());
    }
}
