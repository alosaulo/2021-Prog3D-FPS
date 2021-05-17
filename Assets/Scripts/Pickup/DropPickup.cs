using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropPickup 
{
    public List<GameObject> pickupPrefabs;

    public GameObject DropPrefab() {
        PlayerController player = GameManager._instance.player.GetComponent<PlayerController>();
        int random = Random.Range(0, pickupPrefabs.Count);
        return pickupPrefabs[random];
    }
}
