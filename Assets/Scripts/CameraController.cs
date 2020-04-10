using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //change size to zoom in/out the view
    //clamp values to min and max
    //use the mouse wheel scroll to controll the zoom

    private Vector3 mouseOriginPoint;
    private Vector3 offset;
    private bool dragging;

    private void LateUpdate()
    {
        //10f *Camera.main.orthographicSize*.1f, because otherwise, the closer you zoom in, the zoom speed would get exponentially bigger, so this keeps it constant
        //in addition, this helps the camera from getting flipped when all the way in
        //the above comment is made redundant by the fact that a constraint is added with the Clamp function, that doesn't allow the camera to exceed certain values
       Camera.main.orthographicSize= Mathf.Clamp(Camera.main.orthographicSize -= 
           Input.GetAxis("Mouse ScrollWheel")*(10f *Camera.main.orthographicSize*.1f),2.5f, 50f);

        if (Input.GetMouseButton(2)) 
        {
            offset = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            if(!dragging)
            {
                dragging = true;
                mouseOriginPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            dragging = false;
        }
        if (dragging)
            transform.position = mouseOriginPoint - offset;
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
