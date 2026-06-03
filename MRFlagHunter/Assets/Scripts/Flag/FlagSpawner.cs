using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagSpawner : MonoBehaviour
{
    public static FlagSpawner Instance;

    public GameObject goldFlagPrefab;

    public Transform[] spawnPoints;

    private readonly List<GameObject> activeFlags =
        new();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnFlag();
    }

    public void SpawnFlag()
    {
        int index =
            Random.Range(0, spawnPoints.Length);

        Transform point =
            spawnPoints[index];

        GameObject flag =
            Instantiate(
                goldFlagPrefab,
                point.position,
                Quaternion.identity);

        activeFlags.Add(flag);
    }

    public void FlagCollected()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2f);

        SpawnFlag();
    }
}
