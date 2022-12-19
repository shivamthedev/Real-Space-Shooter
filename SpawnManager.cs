using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject _Enemy;
    [SerializeField]
    GameObject _EnemyContainer;
    bool _stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while(_stopSpawning == false)
        {
            Vector3 SpawnPos = new Vector3(Random.Range(-8f, 8f), -7.5f, 0);
            GameObject newEnemy = Instantiate(_Enemy, SpawnPos, Quaternion.identity);
            newEnemy.transform.parent = _EnemyContainer.transform;
            yield return new WaitForSeconds(4.0f);
        }
    }

    public void onPlayerDeath()
    {
        _stopSpawning = true;
    }
}
