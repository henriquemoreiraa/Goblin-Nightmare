using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

     private GameObject spawnedMonster; 

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnMonsters() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(1, 5));
        
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0) {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Goblin>().speed = Random.Range(4, 10);
            } else {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Goblin>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-9f, 9f, 1f);
            }
        }
    }
}
