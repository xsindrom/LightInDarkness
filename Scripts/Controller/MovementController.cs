using UnityEngine;

public class MovementController : MonoBehaviour
{
    private IPlayerMovement movement;

    public PhysicStats physicStats { get; set; }
    public bool goUp { get; set; }

    public void Init(IPlayerMovement movement, PhysicStats physicStats)
    {
        this.movement = movement;
        this.physicStats = physicStats;
    }

    private void Update()
    {
        movement.Move(physicStats.speed, Vector2.right);
        if (goUp) { movement.Jump(physicStats.height); }
    }
}
