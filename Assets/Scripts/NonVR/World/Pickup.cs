using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    Collision currentcollision;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collide)
    {
        if (collide.tag == "Player")
        {
            Destroy(gameObject);
        }
        Debug.Log("Entered");
    }

    private void DestroyMaterial()
    {
        if (currentcollision.collider.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
        else
        {
            //Debug.Log(health);
        }
    }
}

