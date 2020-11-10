using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCamera : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 headsetPos;
    GameObject centerEye;
    void Start()
    {
        centerEye =GameObject.Find("VRCamera");
    }

    // Update is called once per frame
    void Update()
    {
        System.DateTime myTime =  System.DateTime.Now;
        headsetPos = centerEye.transform.position;
        Debug.Log(headsetPos+", Time : "+myTime.TimeOfDay);
    }
}
