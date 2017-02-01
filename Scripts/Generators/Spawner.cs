using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject[] toSpawn;
    public Vector3 offset = Vector3.zero;
    public float minTimeToSpawn = 0.0f;
    public float maxTimeToSpawn = 0.0f;
    private void Start()
    {
        StartCoroutine(GenerateGround());
    }

    private IEnumerator GenerateGround()
    {
        yield return new WaitForSeconds(Random.Range(minTimeToSpawn, maxTimeToSpawn));
        Instantiate(toSpawn[Random.Range(0, toSpawn.Length)], transform.position + offset, Quaternion.identity);
        StartCoroutine(GenerateGround());
    }

}
