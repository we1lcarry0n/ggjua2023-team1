using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private float forwardOffset;

    private void LateUpdate()
    {
        camera.position = new Vector3(transform.position.x, camera.position.y, transform.position.z - forwardOffset);
    }
}
