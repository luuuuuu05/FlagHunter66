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
        if (GameManager.Instance != null && !GameManager.Instance.IsPlaying)
            return;

        Flag[] flags = FindObjectsOfType<Flag>();

        foreach (var flag in flags)
        {
            float distance =
                Vector3.Distance(
                    transform.position,
                    flag.transform.position);

            if (distance < collectDistance)
            {
                FlagType flagType = flag.GetComponent<FlagType>();
                int scoreValue = flagType != null
                    ? flagType.GetScore()
                    : flag.score;

                ScoreManager.Instance.AddScore(scoreValue);

                Destroy(flag.gameObject);

                FlagSpawner.Instance.FlagCollected();

                break;
            }
        }
    }
}
