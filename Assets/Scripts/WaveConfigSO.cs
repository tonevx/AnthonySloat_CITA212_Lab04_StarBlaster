using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] Transform pathPrefab;

    [SerializeField] float enemymoveSpeed = 10f;
    [SerializeField] float enemySpawnInterval = 1f;
    [SerializeField] float enemySpawnVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;
    [SerializeField] float waveDelay = 2f;

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
    public int GetEnemyCount()
    {
        return enemyPrefab.Length;
    }
    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefab[index];
    }
    public float GetRandomEnemySpawnTime()
    {
        float spawnTime = Random.Range(enemySpawnInterval - enemySpawnVariance, 
        enemySpawnInterval + enemySpawnVariance);
        spawnTime = Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
        return spawnTime;
    }
    public float GetWaveDelay()
    {
        return waveDelay;
    }
}
