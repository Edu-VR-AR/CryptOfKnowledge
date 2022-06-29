using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _timeBetweenSpawn = 2.0f;

    private SpawnPoint[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = gameObject.GetComponentsInChildren<SpawnPoint>();
        StartCoroutine(CreateNewEnemy());
    }

    private IEnumerator CreateNewEnemy()
    {
        bool isInWork = true;

        while (isInWork)
        {
            Transform transform = _spawnPoints[Random.Range(0, _spawnPoints.Length)].GetComponent<Transform>();
            GameObject newEnemy = Instantiate(_enemy.gameObject, transform.position, transform.rotation);

            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }
}
