using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePickUp : MonoBehaviour
{
    public AudioSource pickUpNoise;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bone")
        {
            switch(other.name)
            {
                case "Megalodon 1":
                    Debug.Log(PickedUpData.megalodon1);
                    PickedUpData.megalodon1 = true;
                    Debug.Log(PickedUpData.megalodon1);
                    Debug.Log("Picked up megalodon1");
                    break;
                case "Megalodon 2":
                    PickedUpData.megalodon2 = true;
                    break;
                case "Megalodon 3":
                    PickedUpData.megalodon3 = true;
                    break;
                case "Trex 1":
                    PickedUpData.trex1 = true;
                    break;
                case "Trex 2":
                    PickedUpData.trex2 = true;
                    break;
                case "Trex 3":
                    PickedUpData.trex3 = true;
                    break;
                case "Werewolf 1":
                    PickedUpData.werewolf1 = true;
                    break;
                case "Werewolf 2":
                    PickedUpData.werewolf2 = true;
                    break;
                case "Werewolf 3":
                    PickedUpData.werewolf3 = true;
                    break;
            }
           
            Destroy(other.gameObject, 3);
            pickUpNoise.Play();
            Debug.Log("Store Bone");
        }
        else
        {
            Debug.Log("Not a Bone");
        }
    }


}
