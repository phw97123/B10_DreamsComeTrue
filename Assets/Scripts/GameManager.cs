using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject recovery;
    public GameObject energy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeRecovery", 0, 0.5f);
        InvokeRepeating("makeEnergy", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void makeRecovery()
    {
        Instantiate(recovery);
       
    }
    void makeEnergy()
    {
        Instantiate(energy);

    }
}
