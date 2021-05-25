using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{

    public float mouse_sensitivity = 100f;
    public Transform player_body;
    float Rotation_x = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float mouse_x = Input.GetAxis("Mouse X") * mouse_sensitivity * Time.deltaTime;
        float mouse_y = Input.GetAxis("Mouse Y") * mouse_sensitivity * Time.deltaTime;

        Rotation_x -= mouse_y;
        Rotation_x = Mathf.Clamp(Rotation_x, -90f, 90f);

        transform.localRotation = Quaternion.Euler(Rotation_x, 0f, 0f);
        player_body.Rotate(Vector3.up * mouse_x);

    }
}
