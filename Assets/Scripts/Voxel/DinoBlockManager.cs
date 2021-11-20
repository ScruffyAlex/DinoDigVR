using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class DinoBlockManager : MonoBehaviour
{

    public GameObject bone1;
    public GameObject bone2;
    //public GameObject bone3;
    //public GameObject spawnBlock;
    GameObject newbone;
    Vector3 whereHit;
    Vector3 spawnLocation;
    public Transform panelLocation;

    public void RanSpawn(Vector3 hitpoint)
    {
        whereHit = hitpoint;
        spawnLocation = panelLocation.position;
        int spawnNum = Random.Range(1, 5);
        {
           Debug.Log("Spawn Number" + spawnNum);
           if(spawnNum == 1)
            {
                Debug.Log("Dino no spawn");
            }
           else if(spawnNum == 2)
            {
                Debug.Log("Dino no spawn");
            }
            else if (spawnNum == 3)
            {
                SpawnBone();
            }
            else if (spawnNum == 4)
            {
                Debug.Log("Dino no spawn");
            }
            else if (spawnNum == 5)
            {
                Debug.Log("Dino no spawn");
            }
        }
    }

    public void SpawnBone()
    {
        int whichBone = Random.Range(1, 3);

        if (whichBone == 1)
        {
            Debug.Log("Spawn");
            Instantiate(bone1);
            newbone = Instantiate(bone1, spawnLocation, Quaternion.identity);
        }
        else if (whichBone == 2)
        {
            Debug.Log("Spawn2");
            Instantiate(bone2);
            newbone = Instantiate(bone2, spawnLocation, Quaternion.identity);
        }
        else if (whichBone == 3)
        {
            Debug.Log("Spawn3");
            Instantiate(bone1);
            newbone = Instantiate(bone1, spawnLocation, Quaternion.identity);
        }
    }
}


