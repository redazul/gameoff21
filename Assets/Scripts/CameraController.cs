using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Camera _camera;
    public float zoomSpeed = 50f;
    public float zoomPosition;
    public float panSpeed = 20f;
    public float panBorderThickness = 5f;
    public Vector3 cameraPosition;
    public Vector2 panLimit;
    public float zoomInLimit;
    public float zoomOutLimit;

    
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log(_camera.orthographicSize);
        cameraPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        cameraPosition = transform.position;
        Debug.Log(Input.mouseScrollDelta.y);

        if(Input.mouseScrollDelta.y >=1 )
        {
            zoomPosition -= zoomSpeed * Time.deltaTime;
        }

        if(Input.mouseScrollDelta.y <= -1)
        {
            zoomPosition += zoomSpeed * Time.deltaTime;
        }

        //up
        if(Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            cameraPosition.y += panSpeed * Time.deltaTime;
        }

        //right
        if(Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            cameraPosition.x += panSpeed * Time.deltaTime;
        }


        //down
        if(Input.mousePosition.y <= panBorderThickness)
        {
            cameraPosition.y -= panSpeed * Time.deltaTime;
        }

        //left
        if(Input.mousePosition.x <= panBorderThickness)
        {
            cameraPosition.x -= panSpeed * Time.deltaTime;
        }

        cameraPosition.x = Mathf.Clamp(cameraPosition.x,-panLimit.x,panLimit.x);
        cameraPosition.y = Mathf.Clamp(cameraPosition.y,-panLimit.y,panLimit.y);
        zoomPosition = Mathf.Clamp(zoomPosition,zoomInLimit,zoomOutLimit);
        transform.position = cameraPosition;
        _camera.orthographicSize = zoomPosition;
        
    }
}
