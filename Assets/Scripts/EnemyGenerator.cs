using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float _timeBetweenSpawn = 2.0f;

    private SpawnPoint[] _spawnPoints;    
    private float _timeAfterLastSpawn = 0;

    private void Awake()
    {
        _spawnPoints = gameObject.GetComponentsInChildren<SpawnPoint>();
    }

    private void Update()
    {
        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn>_timeBetweenSpawn)
        {
            _timeAfterLastSpawn = 0;
            CreateNewEnemy();
        }
    }

    private void CreateNewEnemy()
    {
        Transform transform = _spawnPoints[Random.Range(0, _spawnPoints.Length)].GetComponent<Transform>();
        GameObject newEnemy = Instantiate(Enemy, transform.position, transform.rotation);
    }
}
