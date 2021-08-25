using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{

    public enum RockType
    {
        NONE,
        DIRT,
        MUD,
        STONE,
        STONE2
    }

    string currentCollision;

    public RockType currentType;
    public float health;
    public string[] tagNames = { "Spoon", "Shovel", "Pickaxe", "Drill"};

    void Start()
    {

        switch (currentType)
        {
            case RockType.DIRT:
                health = 2;
                break;
            case RockType.MUD:
                health = 4;
                break;
            case RockType.STONE:
                health = 6;
                break;
            case RockType.STONE2:
                health = 10;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentCollision = collision.collider.tag;

        collisionHandler();
        DestroyMaterial();


        //    if (collision.gameObject.tag == "Shovel")
        //    {
        //        //If the GameObject has the same tag as specified, output this message in the console
        //        health -= 1;
        //        DestroyMaterial();
        //    }
    }

   private void DestroyMaterial()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
        else
        {
            Debug.Log(health);
        }
    }

    private void collisionHandler()
    {
        switch (currentType)
        {
            case RockType.NONE:
                break;
            case RockType.DIRT:
                if(currentCollision == "Spoon")
                {
                    health -= 1;
                    Debug.Log("Spoon");
                }
                else if (currentCollision == "Shovel")
                {
                    health -= 3;
                    Debug.Log("Shovel");
                }
                else if (currentCollision == "Pickaxe")
                {
                    health -= 0.5f;
                    Debug.Log("Pickaxe");
                }
                else if (currentCollision == "Drill")
                {
                    health -= 0.2f;
                    Debug.Log("Drill");
                }
                break;
            case RockType.MUD:
                if (currentCollision == "Spoon")
                {
                    health -= 0.5f;
                    Debug.Log("Spoon");
                }
                else if (currentCollision == "Shovel")
                {
                    health -= 3;
                    Debug.Log("Shovel");
                }
                else if (currentCollision == "Pickaxe")
                {
                    health -= 0f;
                    Debug.Log("Pickaxe");
                }
                else if (currentCollision == "Drill")
                {
                    health -= 0f;
                    Debug.Log("Drill");
                }
                break;
            case RockType.STONE:
                if (currentCollision == "Spoon")
                {
                    health -= 0.1f;
                    Debug.Log("Spoon");
                }
                else if (currentCollision == "Shovel")
                {
                    health -= 0.5f;
                    Debug.Log("Shovel");
                }
                else if (currentCollision == "Pickaxe")
                {
                    health -= 2;
                    Debug.Log("Pickaxe");
                }
                else if (currentCollision == "Drill")
                {
                    health -= 1f;
                    Debug.Log("Drill");
                }
                break;
            case RockType.STONE2:
                if (currentCollision == "Spoon")
                {
                    health -= 0;
                    Debug.Log("Spoon");
                }
                else if (currentCollision == "Shovel")
                {
                    health -= 0;
                    Debug.Log("Shovel");
                }
                else if (currentCollision == "Pickaxe")
                {
                    health -= 0.5f;
                    Debug.Log("Pickaxe");
                }
                else if (currentCollision == "Drill")
                {
                    health -= 2f;
                    Debug.Log("Drill");
                }
                break;
            default:
                break;
        }
    }
}
