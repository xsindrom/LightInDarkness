using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Transform transformer;
    public Vector2 offset;
    private void Awake()
    {
        transformer = GetComponent<Transform>();
    }
    private void Follow()
    {
        transformer.position = new Vector3(target.position.x - offset.x, transformer.position.y - offset.y, transformer.position.z);
    }
    private void LateUpdate()
    {
        Follow();
    }
}
