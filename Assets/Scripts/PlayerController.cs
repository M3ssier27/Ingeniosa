using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using System;


public class PlayerController : MonoBehaviour
{

    //Personaje 
    Transform tr;
    Rigidbody rb;

    public float walkSpeed = 100; 


    //Camara 
    public Transform cameraShoulder; 
    public Transform cameraHolder; 
    private Transform cam;

    private float rotY = 0f; 

    private float rotationSpeed = 100;
    public float minAngle = -45; 
    public float maxAngle = 45;
    public float cameraSpeed = 200;

    //animaciones

    public Animator anim;
    private Vector2 animSpeed;

    // Start is called before the first frame update
    void Start()
    {
        tr = this.transform;
        rb = GetComponent<Rigidbody>();

        anim = GetComponentInChildren<Animator>(); 


        cam = Camera.main.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        MoveController(); 
        CameraControl();
        AnimControl(); 

    }

    public void AnimControl()
    {
        anim.SetFloat("X",animSpeed.x);
        anim.SetFloat("Y",animSpeed.y);
    }
    public void MoveController()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        float deltaT = Time.deltaTime;

        animSpeed = new Vector2(deltaX,deltaZ);

        Vector3 side = walkSpeed * deltaX * deltaT * tr.right; 
        Vector3 forward = walkSpeed*deltaZ*deltaT* tr.forward;

        Vector3 direction = side + forward;

        rb.velocity = direction*3f; 
    }

    public void CameraControl()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaT = Time.deltaTime;

        rotY += mouseY * rotationSpeed * deltaT*2f; 

        float rotX = mouseX* rotationSpeed * deltaT;
        tr.Rotate(0, rotX, 0); 

        rotY =Math.Clamp(rotY, minAngle, maxAngle);

        Quaternion localRotation = Quaternion.Euler(-rotY,0,0);
        cameraShoulder.localRotation = localRotation;

        cam.position = Vector3.Lerp(cam.position, cameraHolder.position, cameraSpeed* deltaT );
        cam.rotation = Quaternion.Lerp(cam.rotation, cameraHolder.rotation, cameraSpeed * deltaT);

    }
}
