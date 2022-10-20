using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float cameraSpeed;
    private float cam;
    private bool xPanningRight = true;
    private bool zPanningRight = true;
    private bool cameraRotated = false;

    // x and z panning positions
    public float minX; // -4
    public float maxX; // 5
    public float minZ; // -10
    public float maxZ; // -1


    // Update is called once per frame
    void Update()
    {
        if (cameraRotated == false) {
            if (xPanningRight == true) {
                cam = transform.position.x;
                transform.position = new Vector3(cam += cameraSpeed, transform.position.y, transform.position.z);
                if (transform.position.x >= maxX) {
                    xPanningRight = false;
                    transform.Rotate(0, -90, 0);
                    cameraRotated = true;
                }
            }
            if (xPanningRight == false) {
                cam = transform.position.x;
                transform.position = new Vector3(cam -= cameraSpeed, transform.position.y, transform.position.z);
                if (transform.position.x <= minX) {
                    xPanningRight = true;
                }
            }
        }

        if (cameraRotated == true) {
            if (zPanningRight == true) {
                cam = transform.position.z;
                transform.position = new Vector3(transform.position.x, transform.position.y, cam += cameraSpeed);
                if (transform.position.z >= maxZ) {
                    zPanningRight = false;
                }
            }
            if (zPanningRight == false) {
                cam = transform.position.z;
                transform.position = new Vector3(transform.position.x, transform.position.y, cam -= cameraSpeed);
                if (transform.position.z <= minZ) {
                    zPanningRight = true;
                    transform.Rotate(0, 90, 0);
                    cameraRotated = false;
                }
            }
        }
    }
}
