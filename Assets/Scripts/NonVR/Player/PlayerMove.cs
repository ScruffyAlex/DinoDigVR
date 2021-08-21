using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //Vector3 direction = Vector3.zero;
        //direction.x = Input.GetAxis("Horizontal");
        //direction.z = Input.GetAxis("Vertical");

        //Vector3 velocity = direction * speed;
        //transform.position += velocity * Time.deltaTime;
        
    }
}
