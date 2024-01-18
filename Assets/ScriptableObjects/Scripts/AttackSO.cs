using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu] 키워드
//      ScriptableObject을 생성할 때 에디터 메뉴에서 어떻게 표시될지를 지정합니다.
//      ScriptableObject은 데이터를 저장하고 Unity 에디터에서 사용하기 위한 자체적인 자료 구조입니다.
// fileName: 생성될 ScriptableObject의 기본 파일 이름
// menuName: 에디터 메뉴에서 어디에 위치할지를 나타냅니다.
//      "TopDownController/Attacks/Default"는 에디터의 "Assets" 메뉴에서 "Create" 섹션 하위에 "TopDownController" 메뉴 아래 "Attacks" 메뉴의 "Default" 서브메뉴에 해당하는 경로를 나타냅니다.
// order: 메뉴에서의 순서를 나타냅니다. 낮은 숫자가 높은 우선순위를 갖습니다
[CreateAssetMenu(fileName = "DefaultAttackData", menuName = "TopDownController/Attacks/Default", order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("Attack Info")] // <- 변수 위에 정보표시를 위한 키워드
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
