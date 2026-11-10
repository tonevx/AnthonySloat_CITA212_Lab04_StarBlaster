using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{
    [SerializeField] EnemyWaveScriptableObject enemyWave;
    [SerializeField] float speed;
    Transform[] getPoints;
     int pointIndex = 0;
    void Start()
    {
        getPoints = enemyWave.EnemyPoints();
    }

    void Update()
    {
        PathWaves();
    }
    public void PathWaves()
    {
        Vector3 TargetPositions = getPoints[pointIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, TargetPositions, speed * Time.deltaTime);
        if(transform.position == TargetPositions)
        {
            pointIndex++;
        }
        if(pointIndex >= getPoints.Length)
        {
            pointIndex = 0;
        }
    }
}
