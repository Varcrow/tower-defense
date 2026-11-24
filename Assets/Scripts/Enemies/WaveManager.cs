using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WaveData
{
  public float duration = 10f;
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

    // Start all spawners at the same time
    StartCoroutine(SpawnGroup(regularEnemyPrefab, wave.regularEnemy, wave.duration));
    StartCoroutine(SpawnGroup(fastEnemyPrefab, wave.fastEnemy, wave.duration));
    StartCoroutine(SpawnGroup(heavyEnemyPrefab, wave.heavyEnemy, wave.duration));

    // Wave is "over" once the duration has elapsed
    yield return new WaitForSeconds(wave.duration);

    waveRunning = false;
    startWaveButton.interactable = true;
    currentWave++;
  }

  IEnumerator SpawnGroup(GameObject prefab, int count, float duration)
  {
    if (count <= 0) yield break;

    float interval = duration / count;
    for (int i = 0; i < count; i++)
    {
      SpawnEnemy(prefab);
      yield return new WaitForSeconds(interval);
    }

  }

  void SpawnEnemy(GameObject prefab)
  {
    GameObject e = Instantiate(prefab, wayPoints[0].transform.position, Quaternion.identity);
    Enemy enemy = e.GetComponent<Enemy>();
    enemy.wayPoints = wayPoints;
  }
}
