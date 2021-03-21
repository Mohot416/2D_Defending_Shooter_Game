using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierStatusController : MonoBehaviour
{
    public int HealthPoints = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthPoints <= 0)
            Destroy(gameObject, 0);
    }

}
