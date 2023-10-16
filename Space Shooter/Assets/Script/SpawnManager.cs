using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyContainer;
    private bool isPlayerAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnRoutine()
    {
        while (isPlayerAlive)
        {
            Vector3 position = new Vector3(Random.Range(-9, 9), 6.37f, 0);
            GameObject newEnemy = Instantiate(enemyPrefab,position,Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform; 
            yield return new WaitForSeconds(5f);
        }
    }
     public void OnPlayerDeath()
    {
        isPlayerAlive = false;
    }
}
