using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    public Camera Cam;
    [Space(15f)]
    public float Sensitivity;
    public float ScrollSpeed;
    public float MaxScroll;
    public float MinScroll;
    [Space(15f)]
    public float MovementSpeed;
    [Space(15f)]
    public float MaxMovementDistance;
    public float MaxYRotation;

    private Vector3 MainPos;

    public void Start()
    {
        MainPos = transform.position;
    }

    public void Update()
    {
        if (MainUI.CanMoveCam())
        {
            if (Input.GetMouseButton(0))
            {
                var x = Input.GetAxis("MX");
                var y = -Input.GetAxis("MY");

                var eulertransform = transform.rotation.eulerAngles;

                var r = new Vector3(eulertransform.x + y * Sensitivity * Time.deltaTime, eulertransform.y + x * Sensitivity * Time.deltaTime, eulertransform.z);

                var maxer = Mathf.Abs(r.x - MaxYRotation);
                var minner = Mathf.Abs(r.x - (360 - MaxYRotation));

                var rx = r.x;

                if (r.x > MaxYRotation && minner < maxer)
                    rx -= 360;

                rx = Mathf.Clamp(rx, -MaxYRotation, MaxYRotation);

                var ClampedVector = new Vector3(rx, r.y, r.z);

                transform.rotation = Quaternion.Euler(ClampedVector);
            }
            else if (Input.GetMouseButton(1))
            {
                var y = Input.GetAxis("MY");

                var max = MainPos + new Vector3(0, MaxMovementDistance);
                var min = MainPos - new Vector3(0, MaxMovementDistance);

                transform.position = ClampVector(transform.position - new Vector3(0, y * MovementSpeed * Time.deltaTime),min,max);
            }

            var Scroll = Input.GetAxisRaw("Mouse ScrollWheel");
            Cam.fieldOfView = Mathf.Clamp(Cam.fieldOfView - Scroll * ScrollSpeed * Time.deltaTime, MinScroll, MaxScroll);
        }
    }


    /// <summary>
    /// Clamps a Vector3 value between two other Vectors (Minimum and Maximum)
    /// </summary>
    public Vector3 ClampVector(Vector3 value , Vector3 min , Vector3 max)
    {
        Vector3 toreturn = new Vector3();

        for (int i = 0; i < 3; i++)
        {
            toreturn[i] = Mathf.Clamp(value[i], min[i], max[i]);
        }

        return toreturn;
    }
}
