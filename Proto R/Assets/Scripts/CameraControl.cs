using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 TargetOffset;
    [SerializeField] private float cameraSpeed;
    [SerializeField] Camera mainCamera;
    [SerializeField] Vector3 viewCam;
    [SerializeField] float lookPos;
    [SerializeField] private float sensitivity;
    [SerializeField] float midPoint;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        viewCam = (Input.mousePosition - _player.position);

        float distance;
        distance= Mathf.Clamp(viewCam.x, 0.0f, 1.0f);

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 vector3 = new Vector3 (Mathf.Clamp((hit.point.x + _player.position.x) / 2, _player.position.x - 7f, _player.position.x + 0.5f),
                transform.position.y,
    
                Mathf.Clamp((hit.point.z + _player.position.z) / 2, _player.position.z - 7f, _player.position.z + 0.5f));

                transform.position = Vector3.Lerp(transform.position, vector3, 0.2f);
        }
               

    }

    

}

   


    




