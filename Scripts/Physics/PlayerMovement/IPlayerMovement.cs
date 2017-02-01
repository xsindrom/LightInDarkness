using UnityEngine;
using System.Collections;

public interface IPlayerMovement
{
    void Jump(float height);
    void Move(float speed, Vector2 direction);
}
