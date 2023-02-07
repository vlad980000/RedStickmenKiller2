using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Player _player;

    [SerializeField] private float _spawnDistance;
    [SerializeField] private float _spawnSpeed;
    [SerializeField] private float _startSpawnDelay;

    [SerializeField] private LevelReloader _levelReloader;

    [SerializeField] private List<EnemySettings> _enemySettings = new List<EnemySettings>();

    [SerializeField] private int _levelIndex;

    private Coroutine _coroutine;
    public int LevelCount => _enemySettings.Count;

    private void OnEnable()
    {
        _player.StopCreateEnemy += OnBaseIsReached;
    }

    private void OnDisable()
    {
        _player.StopCreateEnemy -= OnBaseIsReached;
    }

    public void SetEnemySettingsIndex(int levelIndex)
    {
        _levelIndex = levelIndex;
        Debug.Log(levelIndex);
        _coroutine = StartCoroutine(StartCreateEnemy(_levelIndex));
    }

    public void StartCoroutineEnemyes(int index)
    {
        _coroutine = StartCoroutine(StartCreateEnemy(index));
    }

    public void OnBaseIsReached()
    {
        StopCoroutine(_coroutine);
    }

    private void OnLevelCompleted()
    {

    }

    private IEnumerator StartCreateEnemy(int enemySettingsIndex)
    {
        var spawnSpeed = new WaitForSeconds(_spawnSpeed);
        var startSpawnDelay = new WaitForSeconds(_startSpawnDelay);

        yield return startSpawnDelay;

        while (true)
        {
            var transformSpawn = GetRandomX();
            for (int i = 0; i < _enemySettings[enemySettingsIndex].SpawnIndex; i++)
            {
                var enemy = Instantiate(_enemy, new Vector3(transformSpawn + (i * 4), 0, _player.transform.position.z + _spawnDistance), Quaternion.LookRotation(Vector3.back));
                enemy.SetPLayer(_player);
                enemy.SetStats(_enemySettings[enemySettingsIndex].Health, _enemySettings[enemySettingsIndex].Damage, _enemySettings[enemySettingsIndex].Reward);
            }
            yield return spawnSpeed;
        }
    }

    private float GetRandomX()
    {
        return Random.Range(-11f ,4f);
    }
}
