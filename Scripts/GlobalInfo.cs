using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInfo : MonoBehaviour
{
    public int kills;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void KillingUnit()
    {
        kills++;
    }
}
