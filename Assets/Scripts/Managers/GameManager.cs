using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public static GameManager _instance;

    public HUDManager HUDManager;

    public DropPickup dropPickup;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        HUDManager = GetComponent<HUDManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
