using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStatsHandler : MonoBehaviour
{
    [SerializeField] CharStats baseStats;
    public CharStats CurrentStats { get; private set; }
    public List<CharStats> statsModifiers = new List<CharStats>();

    private void Awake()
    {
        UpdateCharStats();
    }

    void UpdateCharStats()
    {
        AttackSO attackSO = null;
        if (baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);
        }

        CurrentStats = new CharStats { attackSO = attackSO };
        // Todo
        CurrentStats.statsChangeType = baseStats.statsChangeType;
        CurrentStats.maxHealth = baseStats.maxHealth;
        CurrentStats.speed = baseStats.speed;
    }
}
