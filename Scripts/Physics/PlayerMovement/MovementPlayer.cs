using UnityEngine;

public class MovementPlayer : MonoBehaviour, IPlayerMovement
{
    private Transform transformer;
    private Rigidbody2D rbody;

    private void Start()
    {
        transformer = gameObject.GetComponent<Transform>();
        rbody = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Move(float speed, Vector2 direction)
    {
        transformer.Translate(direction * speed * Time.deltaTime);
    }
    public void Jump(float height)
    {
        rbody.velocity = Vector2.up * height;
    }
}
