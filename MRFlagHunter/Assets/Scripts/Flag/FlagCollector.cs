using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCollector : MonoBehaviour
{
    public float collectDistance = 1.0f;

    void Update()
    {
        bool triggerPressed =
            Input.GetKeyDown(KeyCode.J);

        if (triggerPressed)
        {
            TryCollect();
        }
    }

    void TryCollect()
    {
        Flag[] flags = FindObjectsOfType<Flag>();

        foreach (var flag in flags)
        {
            float distance =
                Vector3.Distance(
                    transform.position,
                    flag.transform.position);

            if (distance < collectDistance)
            {
                ScoreManager.Instance.AddScore(flag.score);

                Destroy(flag.gameObject);

                FlagSpawner.Instance.FlagCollected();

                break;
            }
        }
    }
}
