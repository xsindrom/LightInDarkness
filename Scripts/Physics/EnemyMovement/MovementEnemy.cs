using UnityEngine;
using System;
public class MovementEnemy : MonoBehaviour
{
    public float speed = 0.0f;
    
    public ITraectory traectory;
    
    private Transform transformer;
    
    private void Start()
    {
        transformer = transform;
        traectory = transformer.GetComponent<ITraectory>();
    }
    private void FixedUpdate()
    {
        transformer.Translate(new Vector2(traectory.X,traectory.Y) * speed);
    }
}
