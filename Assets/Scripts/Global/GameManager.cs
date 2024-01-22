using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform Player { get; private set; }
    [SerializeField] string PlayerTag = "Player";
    HealthSystem playerHealthSystem;

    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] Slider hpGauseSlider;
    [SerializeField] GameObject gameOverUI;

    [SerializeField] int currentWaveIndex = 0;
    int currentSpawnCount = 0;
    int waveSpawnCount = 0;
    int waveSpawnPosCount = 0;

    public float spawnInterval = .5f;
    public List<GameObject> enemyPrefebs = new();

    [SerializeField] Transform spawnPositionsRoot;
    List<Transform> spawnPositions = new();

    private void Awake()
    {
        instance = this;
        Player = GameObject.FindGameObjectWithTag(PlayerTag).transform;

        playerHealthSystem = Player.GetComponent<HealthSystem>();
        playerHealthSystem.OnDamage += UpdateHealthUI;
        playerHealthSystem.OnHeal += UpdateHealthUI;
        playerHealthSystem.OnDeath += GameOver;

        gameOverUI.SetActive(false);

        for(int i = 0; i < spawnPositionsRoot.childCount; i++)
        {
            spawnPositions.Add(spawnPositionsRoot.GetChild(i));
        }
    }

    private void Start()
    {
        //UpgradeStatInit();
        StartCoroutine(nameof(StartNextWave));
    }

    IEnumerator StartNextWave()
    {
        while (true)
        {
            if (currentSpawnCount == 0)
            {
                UpdateWaveUI();
                yield return new WaitForSeconds(2f);

                if (currentWaveIndex % 10 == 0)
                {
                    waveSpawnPosCount = waveSpawnPosCount + 1 > waveSpawnPosCount ? waveSpawnPosCount : waveSpawnPosCount + 1;
                    waveSpawnCount = 0;
                }

                if (currentWaveIndex % 5 == 0)
                {

                }

                if (currentWaveIndex % 3 == 0)
                {
                    waveSpawnCount += 1;
                }

                for(int i =0; i< waveSpawnPosCount; i++)
                {
                    int posIdx = Random.Range(0, spawnPositions.Count);
                    for(int j = 0; j < waveSpawnCount; j++)
                    {
                        int prefabIdx = Random.Range(0, enemyPrefebs.Count);
                        GameObject enemy = Instantiate(enemyPrefebs[prefabIdx], spawnPositions[posIdx].position, Quaternion.identity); ;
                        enemy.GetComponent<HealthSystem>().OnDeath += OnEnemyDeath;
                        // enemy.GetComponent<CharStatsHandler>();
                        currentSpawnCount++;
                    }
                }
                currentWaveIndex++;

            }

            yield return null; // null�� �����ϰ� �ݺ������� ���ѹݺ��� �����ϸ� update�� �ֱⰡ ���� ����.
        }
    }

    private void OnEnemyDeath()
    {
        currentSpawnCount--;
    }

    private void UpdateHealthUI()
    {
        hpGauseSlider.value = playerHealthSystem.CurrentHealth / playerHealthSystem.MaxHealth;
    }

    private void GameOver()
    {
        gameOverUI.SetActive(true);
        StopAllCoroutines(); // StopCoroutine(nameof(StartNextWave));

    }

    void UpdateWaveUI()
    {
        waveText.text = (currentWaveIndex + 1).ToString();
    }

    public void ReStartGame()
    {
        // SceneManager.LoadScene("MainScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // ���� Ȱ��ȭ �Ǿ��ִ� �� -> ���� ���� �ε��� ��
    }

    public void ExitGame()
    {
        Application.Quit(); // ����
    }
}
