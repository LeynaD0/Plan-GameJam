using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemy;
    [SerializeField]
    int posX, posZ, EnemyCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (EnemyCount < 20)
        {
            posX = Random.Range(-34, 0);
            posZ = Random.Range(-33, 32);
            int i = Random.Range(0, enemy.Length);
            Instantiate(enemy[i], new Vector3(posX, 1, posZ), Quaternion.identity);
            yield return new WaitForSeconds(1);
            EnemyCount += 1;
        }
    }
}
