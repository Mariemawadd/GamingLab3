using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float Cameraspeed;
    public float minX,maxX;
    public float minY,maxY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
        {
            if(Target!=null)
            {
                Vector2 newCamposition=Vector2.Lerp(transform.position,Target.position,Time.deltaTime*Cameraspeed);
            float CalmpX=Mathf.Clamp(newCamposition.x,minX,maxX);
            float ClampY=Mathf.Clamp(newCamposition.y,minY,maxY);
            transform.position=new Vector3(CalmpX,ClampY,-10f);
            }
        }
}
