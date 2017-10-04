﻿using UnityEngine;
using System.Collections;
using System;

public class thirdPersonCam : MonoBehaviour {


    public Transform lookAt;
    public Transform camTransform;

    private const float Y_ANGLE_MIN = -40f;
    private const float Y_ANGLE_MAX = 40f;

    private const float MAX_ZOOM = 30f;
    private const float MIN_ZOOM = 70f;

    //private float shiftx = 2f;
    public float shiftz = 15f;
    public bool mouse = false;
    //private Camera cam;
    float dis = 16f;
    Vector3 dest;
   // private float distance = 15f;
    private float currentX = 0;
    private float currentY = 0f;
    public float sensivityX = 4f;
    public float sensivityY = 1f;

    private Animator ani;

    private void Start()
    {
        //Vector3 dir = new Vector3(0, 0, -distance);
        // Quaternion rotation = Quaternion.Euler(currentY * sensivityY, currentX * sensivityX, 0);
        //ani = GameObject.Find("Jackle").GetComponent<Animator>();
        dis = MIN_ZOOM;
        camTransform = transform;
        //cam = Camera.main;

    }
    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        //ani.SetFloat("InputMouseH", (currentX %90 - (lookAt.transform.eulerAngles.y/4)) );
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        dis += Input.GetAxis("Mouse ScrollWheel");
        dis = Mathf.Clamp(dis, MAX_ZOOM, MIN_ZOOM);
        //print(dis);
    }
    void OnMouseDown()
    {
        mouse = true;
    }

    void OnMouseUp()
    {
        mouse = false;
    }

    private void LateUpdate()
    {
        //RaycastHit hit;
        Vector3 dir;
        if (!mouse)
            dir = new Vector3(0, 0, -dis);
        else
        {
            dir = new Vector3(0, 0, -dis - shiftz);
        }
        //dir += -Vector3.forward;
        Quaternion rotation = Quaternion.Euler(currentY * sensivityY, currentX * sensivityX, 0);
        dest = lookAt.position + rotation * dir;

        //if (Physics.Linecast(camTransform.position, dest, out hit))
       // {
       //     camTransform.position = Vector3.Lerp(camTransform.position, hit.point +hit.normal* 0.5f, 20f * Time.deltaTime);
        //}else
            camTransform.position = Vector3.Lerp(camTransform.position, dest, Time.deltaTime * 20f);

        // if(currentY>= lookAt.position.y)
        //  camTransform.LookAt(lookAt.position+Vector3.up*(Mathf.Sqrt(currentY/lookAt.position.y))/2 );
        //else
        //camTransform.LookAt(lookAt.position + 3f*Vector3.up);
        camTransform.LookAt(lookAt.position + 4f * Vector3.up );

        camTransform.Rotate(-10f,0f, 0f);
      //  ani.SetFloat("InputMouseH", ( Mathf.Clamp(camTransform.rotation.y - lookAt.rotation.y , -.3f, .3f)));
        
       // print(currentY);
    }


}

