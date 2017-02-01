using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
public class Restarter : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GameObjectsTags.PLAYER_tag))
        {
            BuildPlayer.Instance.OnDestroyPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.gameObject.CompareTag(GameObjectsTags.PLAYER_tag))
        {
            BuildPlayer.Instance.OnDestroyPlayer();
        }
    }
}
