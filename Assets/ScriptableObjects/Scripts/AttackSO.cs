using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu] Ű����
//      ScriptableObject�� ������ �� ������ �޴����� ��� ǥ�õ����� �����մϴ�.
//      ScriptableObject�� �����͸� �����ϰ� Unity �����Ϳ��� ����ϱ� ���� ��ü���� �ڷ� �����Դϴ�.
// fileName: ������ ScriptableObject�� �⺻ ���� �̸�
// menuName: ������ �޴����� ��� ��ġ������ ��Ÿ���ϴ�.
//      "TopDownController/Attacks/Default"�� �������� "Assets" �޴����� "Create" ���� ������ "TopDownController" �޴� �Ʒ� "Attacks" �޴��� "Default" ����޴��� �ش��ϴ� ��θ� ��Ÿ���ϴ�.
// order: �޴������� ������ ��Ÿ���ϴ�. ���� ���ڰ� ���� �켱������ �����ϴ�
[CreateAssetMenu(fileName = "DefaultAttackData", menuName = "TopDownController/Attacks/Default", order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("Attack Info")] // <- ���� ���� ����ǥ�ø� ���� Ű����
    public float size;
    public float delay;
    public float poewr;
    public float speed;
    public LayerMask target;

    [Header("Knock Back Info")]
    public bool isOnKnockback;
    public float isOnKnockPower;
    public float isOnKnockTime;
}
