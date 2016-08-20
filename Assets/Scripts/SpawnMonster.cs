using UnityEngine;
using System.Collections;

public class SpawnMonster : MonoBehaviour {

    public GameObject[] monsterPrefabs;
    public float monsterSpawnPause = 1f;
    public float waveSpawnPause = 25f;
    public int[][] Level;

	// Use this for initialization
	void Start () {
        Level = new int[3][];
        Level[0] = new int[] {0, 2, 1, 0, 0};
        Level[1] = new int[] {1, 0, 0, 0, 0};
        Level[2] = new int[] {0, 0, 0};
        StartCoroutine(SpawnLevels());
	}
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator SpawnLevels()
    {
        for( int i = 0; i < Level.Length; i++)
        {
            StartCoroutine("SpawnWave", i);
            yield return new WaitForSeconds(waveSpawnPause);
        }
    }

    IEnumerator SpawnWave(int wave)
    {
        for( int i = 0; i < Level[wave].Length; i++)
        {
            Instantiate(monsterPrefabs[Level[wave][i]], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(monsterSpawnPause);
        }
    }
}
