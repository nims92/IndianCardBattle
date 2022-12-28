using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera camera;

    [SerializeField] private float desiredHorizontalFOV;

    private void Awake()
    {
        //TODO: check for tablet devices
        camera.fieldOfView = Utilities.CalculateVerticalFOV(desiredHorizontalFOV);
    }
}