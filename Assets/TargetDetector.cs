using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetector : MonoBehaviour
{
    public List<Transform> EnemiesPosition = new List<Transform>();
    private void OnTriggerEnter(Collider other)
    {
        EnemiesPosition.Add(other.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        EnemiesPosition.Remove(other.transform);
    }

    public void ClearTargetList()
    {
        for (int i = 0; i < EnemiesPosition.Count; i++)
        {
            if (!EnemiesPosition[i].gameObject.activeSelf)
            {
                EnemiesPosition.Remove(EnemiesPosition[i]);
            }
        }
    }
}
