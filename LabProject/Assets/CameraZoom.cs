using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
   private Camera cam;
   public float TargetZoom=3;
   private float ScrollData;
   public float ZoomSpeed=3;
    void Start()
    {
        cam=GetComponent<Camera>();
        TargetZoom=cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        ScrollData=Input.GetAxis("Mouse ScrollWheel");
        TargetZoom=TargetZoom-ScrollData;
        TargetZoom=Mathf.Clamp(TargetZoom,3,6);
        cam.orthographicSize=Mathf.Lerp(cam.orthographicSize,TargetZoom,Time.deltaTime*ZoomSpeed);
    }
}
