using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float timer;
    private float maxTimer;
    public GameObject enemy;

    public float timerMin = 5f;
    public float timerMax = 12f;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        maxTimer = Random.Range(timerMin,timerMax);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("SpawnEnemyTimer");

    }

    void SpawnEnemy()
    {
        float y = 1.25f;
        Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0, 1f), y, 0));
        spawnPoint.z = 0;

        //adjust x axis position
        float dist = (this.transform.position - Camera.main.transform.position).z;
        float leftBoarder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        float rightBoarder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

        Vector3 enemySize = enemy.GetComponent<Renderer>().bounds.size;
        spawnPoint.x = Mathf.Clamp(spawnPoint.x, leftBoarder + enemySize.x / 2, rightBoarder - enemySize.x / 2);
        


        GameObject.Instantiate(enemy, spawnPoint, new Quaternion(0, 0, 0, 0));
    }

    IEnumerator SpawnEnemyTimer()
    {
        if(timer >= maxTimer)
        {
            SpawnEnemy();
            timer = 0;
            maxTimer = Random.Range(timerMin, timerMax);

        }
        timer += .1f;
        yield return new WaitForSeconds(.1f);
    }
}
