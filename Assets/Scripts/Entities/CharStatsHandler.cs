using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStatsHandler : MonoBehaviour
{
    [SerializeField] CharStats baseStats;
    public CharStats CurrentStates { get; private set; }
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

        CurrentStates = new CharStats { attackSO = attackSO };
        // Todo
        CurrentStates.statsChangeType = baseStats.statsChangeType;
        CurrentStates.maxHealth = baseStats.maxHealth;
        CurrentStates.speed = baseStats.speed;
    }
}
