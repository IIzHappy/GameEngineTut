using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    [SerializeField] GameObject _enemyParent;
    [SerializeField] GameObject _enemy;
    List<EnemyBase> _enemies = new List<EnemyBase>();

    public float _spawnDelay = 1;

    Vector2 _playerPos;

    [SerializeField] float _spawnDistance = 20;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (_enemyParent == null)
        {
            _enemyParent = gameObject;
        }
        StartCoroutine(SpawnTimer(_spawnDelay));
    }

    public void SpawnEnemy()
    {
        Vector2 spawnPos = RandomDir() * _spawnDistance;
        EnemyBase enemy = Instantiate(_enemy, _playerPos + spawnPos, Quaternion.identity, _enemyParent.transform).GetComponent<EnemyBase>();
        _enemies.Add(enemy);
        enemy.GetPlayerPos(_playerPos);
    }

    Vector2 RandomDir()
    {
        Vector2 dir = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
        if (dir == Vector2.zero)
        {
            dir = RandomDir();
        }
        return dir;
    }

    public void UpdatePlayerPos(Vector2 pos)
    {
        _playerPos = pos;
        foreach(EnemyBase enemy in _enemies)
        {
            enemy.GetPlayerPos(pos);
        }
    }

    public void RemoveEnemy(EnemyBase enemy)
    {
        _enemies.Remove(enemy);
        Destroy(enemy.gameObject);
    }

    IEnumerator SpawnTimer(float spawnDelay)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            SpawnEnemy();
        }
    }
}
