using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform _gunTransform;
    public Transform _aimTransform;


    public Gun(Transform gunTransform, Transform aimTransform)
    {

        _gunTransform = gunTransform;
        _aimTransform = aimTransform;
    }


    public void Update()
    {
        var dir = _aimTransform.position - _gunTransform.position;
        var angle = Vector3.Angle(Vector3.down, dir);
        var axis = Vector3.Cross(Vector3.down, dir);
        _gunTransform.rotation = Quaternion.AngleAxis(angle, axis);
    }

}
