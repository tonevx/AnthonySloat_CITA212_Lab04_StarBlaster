using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Waves", menuName = "Enemy Waves/New Enemy Wave")]
public class EnemyWaveScriptableObject : ScriptableObject
{
    [SerializeField] Transform enemyWave;
    public Transform[] EnemyPoints()
    {
        Transform[] enemyPoints = new Transform[enemyWave.childCount];
        for (int i = 0; i < enemyWave.childCount; i++)
        {
            enemyPoints[i] = enemyWave.GetChild(i);
        }
        return enemyPoints;
    }
}
