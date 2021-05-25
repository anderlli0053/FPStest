using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    public float jump_height = 3f;
    Vector3 velocity;
    public float gravity = 9.81f;
    public Transform floor_checker;
    public float floor_distance = 0.4f;
    public LayerMask floor_mask;
    bool is_on_floor;



    void Update()
    {
        is_on_floor = Physics.CheckSphere(floor_checker.position, floor_distance, floor_mask);


        if (is_on_floor && velocity.y < 0) 
        {
            velocity.y = -2f;
        }




        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);


        if(Input.GetButtonDown("Jump") && is_on_floor)
        {
            velocity.y = Mathf.Sqrt(jump_height * -2f * gravity);
        }






        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
