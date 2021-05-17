using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnOrigin;
    public float spawnTime;
    public bool isReadyToSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isReadyToSpawn == true) {
            StartCoroutine("SpawnPrefab");
        }
    }

    IEnumerator SpawnPrefab() {
        isReadyToSpawn = false;
        Instantiate(prefab, spawnOrigin.position, Quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
        isReadyToSpawn = true;
    }

}
