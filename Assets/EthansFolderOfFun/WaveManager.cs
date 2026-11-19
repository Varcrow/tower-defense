using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WaveData
{
  public float duration = 10f;
  // enemyOne and enemyTwo are temp names till we decide what type of enemies we actually want
  public int enemyOne = 5;
  public int enemyTwo = 2;
}

public class WaveManager : MonoBehaviour
{
  public WaveData[] waves;
  public Button startWaveButton;

  // enemyOne and enemyTwo are temp names till we decide what type of enemies we actually want
  public GameObject enemyOnePrefab;
  public GameObject enemyTwoPrefab;

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
    for (int i = 0; i < wave.enemyOne; i++)
    {
      SpawnEnemy(enemyOnePrefab);
      yield return new WaitForSeconds((wave.duration / 3) / wave.enemyOne);
    }

    for (int i = 0; i < wave.enemyTwo; i++)
    {
      SpawnEnemy(enemyTwoPrefab);
      yield return new WaitForSeconds((wave.duration / 3) / wave.enemyTwo);
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
