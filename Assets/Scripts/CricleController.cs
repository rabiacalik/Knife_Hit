using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CricleController : MonoBehaviour
{

    [SerializeField] private float rotateSpeed = 1.0f;

    private void Update()
    {
        SetCircleRotate();
    }

    private void SetCircleRotate()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime); // z ekseninde donsun
    }

}
