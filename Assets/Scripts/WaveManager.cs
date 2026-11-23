using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WaveData
{
  public float duration = 10f;
  // enemyOne and enemyTwo are temp names till we decide what type of enemies we actually want
  public int regularEnemy = 5;
  public int fastEnemy = 2;
  public int heavyEnemy = 2;
}

public class WaveManager : MonoBehaviour
{
  public WaveData[] waves;
  public Button startWaveButton;

  public GameObject regularEnemyPrefab;
  public GameObject fastEnemyPrefab;
  public GameObject heavyEnemyPrefab;

  public Transform[] wayPoints;

  private int currentWave = 0;
  private bool waveRunning = false;

  void Start()
  {
    startWaveButton.onClick.AddListener(StartWave);
  }

  public void StartWave()
  {
    if (waveRunning) return;
    if (currentWave >= waves.Length) return;

    StartCoroutine(RunWave());
  }

  IEnumerator RunWave()
  {
    waveRunning = true;
    startWaveButton.interactable = false;
    WaveData wave = waves[currentWave];

    // Need one of these loops per enemy types

    for (int i = 0; i < wave.regularEnemy; i++)
    {
      SpawnEnemy(regularEnemyPrefab);
      yield return new WaitForSeconds((wave.duration / 3) / wave.regularEnemy);
    }

    for (int i = 0; i < wave.fastEnemy; i++)
    {
      SpawnEnemy(fastEnemyPrefab);
      yield return new WaitForSeconds((wave.duration / 3) / wave.fastEnemy);
    }

    for (int i = 0; i < wave.heavyEnemy; i++)
    {
      SpawnEnemy(heavyEnemyPrefab);
      yield return new WaitForSeconds((wave.duration / 3) / wave.heavyEnemy);
    }

    yield return new WaitForSeconds(wave.duration / 3);
    waveRunning = false;
    startWaveButton.interactable = true;
    currentWave++;
  }

  void SpawnEnemy(GameObject prefab) {
    GameObject e = Instantiate(prefab, wayPoints[0].transform.position, Quaternion.identity);
    Enemy enemy = e.GetComponent<Enemy>();
    enemy.wayPoints = wayPoints;
  }
}
