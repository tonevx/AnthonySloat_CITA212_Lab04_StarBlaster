using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform pathPrefab;

    [SerializeField] float enemymoveSpeed = 10f;

    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }
    public float GetEnemyMoveSpeed()
    {
        return enemymoveSpeed;
    }
    public Transform[] GetWayPoints()
    {
        Transform[] wayPoints = new Transform[pathPrefab.childCount];
        for (int i = 0; i < pathPrefab.childCount; i++)
        {
            wayPoints[i] = pathPrefab.GetChild(i);
        }
        return wayPoints;
    }
}
