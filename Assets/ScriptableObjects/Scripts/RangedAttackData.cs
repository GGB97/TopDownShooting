using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangedAttackData", menuName = "TopDownController/Attacks/Ranged", order = 1)]
public class RangedAttackData : AttackSO
{
    [Header("Ranged Attack Data")]
    public string bulletNameTag;
    public float duration; // 지속 시간
    public float spread; //탄이 퍼지는 정도
    public int numberofProjectilesPerShot; //한번에 쏠 양
    public float multipleProjectilesAngel; //한번에 쏠때 앵글
    public Color projectileColor; 

}
