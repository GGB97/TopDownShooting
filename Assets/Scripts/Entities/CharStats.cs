using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override,
}

[Serializable]
public class CharStats
{
    public StatsChangeType statsChangeType;
    [Range(0, 100)] public int maxHealth;
    [Range(0f, 20f)] public float speed;

    // 공격 데이터
    public AttackSO attackSO;
}
