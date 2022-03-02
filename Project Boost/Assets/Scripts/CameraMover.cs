using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] Camera camera;
    private void Start()
    {
        camera = GetComponent<Camera>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        camera.transform.position = new Vector3(27.22f, 0 , 0);
    }
}
