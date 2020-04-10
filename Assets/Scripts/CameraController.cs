using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //change size to zoom in/out the view
    //clamp values to min and max
    //use the mouse wheel scroll to controll the zoom

    private void LateUpdate()
    {
        Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
