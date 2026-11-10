using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform enemyPrefab;

    [SerializeField] float enemymoveSpeed = 10f;

    public Transform GetStartingWayPoint()
    {
        return enemyPrefab.GetChild(0);
    }
    public float GetEnemyMoveSpeed()
    {
        return enemymoveSpeed;
    }
    public Transform[] GetWayPoints()
    {
        Transform[] wayPoints = new Transform[enemyPrefab.childCount];
        for (int i = 0; i < enemyPrefab.childCount; i++)
        {
            wayPoints[i] = enemyPrefab.GetChild(i);
        }
        return wayPoints;
    }
}
