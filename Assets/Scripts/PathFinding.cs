using UnityEngine;

public class PathFinding : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;
    Transform[] wayPoints;
    int waypointIndex = 0;
    void Start()
    {
        wayPoints = waveConfig.GetWayPoints();
        transform.position = waveConfig.GetStartingWayPoint().position;
    }

    void Update()
    {
        FollowPath();
    }
    void FollowPath()
    {
        if (waypointIndex < wayPoints.Length)
        {
            Vector3 targetPosition = wayPoints[waypointIndex].position;
            float moveDelta = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveDelta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
