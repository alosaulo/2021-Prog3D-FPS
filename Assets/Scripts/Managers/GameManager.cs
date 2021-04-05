using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public HUDManager HUDManager;

    void Awake() {
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
