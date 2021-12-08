using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControl : MonoBehaviour
{
    public float zoomSpeed = 2.0f;
    public float turnSpeed = 2.0f;

    private float xRotate = 0.0f;
    private float cameraFov;

    public GameObject target;
    private float time;
    private bool openState = true;

    void Start()
    {
        cameraFov = Camera.main.fieldOfView;
    }

    void Update()
    {
        if (cameraFov >= 80)
        {
            StartCoroutine(ZoomCamera(60.0f));
        }

        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            StartCoroutine(MoveCamera());
        }
    }

    IEnumerator MoveCamera()
    {
        float yRotateSize = -Input.GetAxis("Mouse X") * turnSpeed;
        float yRotate = transform.eulerAngles.y + yRotateSize;
        float xRotateSize = Input.GetAxis("Mouse Y") * turnSpeed;

        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 50);
        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

        yield return new WaitForSeconds(.03f);
    }
    internal IEnumerator ZoomCamera(float zoomValue)
    {
        if (openState)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoomValue, Time.deltaTime);
            time += Time.deltaTime;
        }

        if (time > 3f)
        {
            openState = false;
        }
       
        yield return new WaitForSeconds(.1f);
    }
}