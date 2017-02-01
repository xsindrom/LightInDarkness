using UnityEngine;
using System.Collections;

public class BuildEnemy : MonoBehaviour {

    [Header("EnemyStats")]
    public EnemyStats enemystats = new EnemyStats();
    private MovementEnemy movementEnemy;
    private void Start()
    {
        movementEnemy = gameObject.GetComponent<MovementEnemy>();
        movementEnemy.speed = enemystats.speed;
    }
}
