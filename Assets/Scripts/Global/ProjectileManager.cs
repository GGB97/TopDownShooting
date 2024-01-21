using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager instance;

    [SerializeField] ParticleSystem _impactParticleSystem;

    [SerializeField] GameObject testObj;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    public void ShootBullet(Vector2 startPos, Vector2 dir, RangedAttackData attackData)
    {
        GameObject obj = Instantiate(testObj);

        obj.transform.position = startPos;
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();
        attackController.InitializeAttack(dir, attackData, this);

        obj.SetActive(true);
    }
}
