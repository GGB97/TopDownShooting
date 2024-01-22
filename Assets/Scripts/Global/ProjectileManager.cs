using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager instance;

    [SerializeField] ParticleSystem _impactParticleSystem;

    ObjectPool objectPool;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        objectPool = GetComponent<ObjectPool>();
    }

    public void ShootBullet(Vector2 startPos, Vector2 dir, RangedAttackData attackData)
    {
        GameObject obj = objectPool.SpawnFromPool(attackData.bulletNameTag);

        obj.transform.position = startPos;
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();
        attackController.InitializeAttack(dir, attackData, this);

        obj.SetActive(true);
    }

    public void CreateImpactParticleesAtPosition(Vector3 pos, RangedAttackData attackData)
    {
        _impactParticleSystem.transform.position = pos;
        ParticleSystem.EmissionModule em = _impactParticleSystem.emission;

        em.SetBurst(0, new ParticleSystem.Burst(0, Mathf.Ceil(attackData.size * 5)));
        ParticleSystem.MainModule mainModule = _impactParticleSystem.main;
        mainModule.startSpeedMultiplier = attackData.size * 10f;
        _impactParticleSystem.Play();
    }
}
