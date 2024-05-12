using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateChestTreasure : MonoBehaviour
{
    [SerializeField] private GameObject treasure;
    void Start()
    {
        Instantiate(treasure);
    }

    void Update()
    {
        
    }
}
