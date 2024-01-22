using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    ProjectileManager _projectileManager;
    TopDownCharController _controller;

    [SerializeField] Transform projectileSpawnPos;
    Vector2 _aimDirection = Vector2.right;

    public AudioClip shootingClip;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharController>();
    }
    private void Start()
    {
        _projectileManager = ProjectileManager.instance;
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;

    }

    void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection; 
    }

    void OnShoot(AttackSO attackSO)
    {
        RangedAttackData rangedAttackData = attackSO as RangedAttackData;
        float projecttilesAngleSpace = rangedAttackData.multipleProjectilesAngel;
        int numberOfProjectilesPerShot = rangedAttackData.numberofProjectilesPerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projecttilesAngleSpace + 0.5f * rangedAttackData.multipleProjectilesAngel;

        float angle; float randomSpread;
        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            angle = minAngle + projecttilesAngleSpace * i;
            randomSpread = Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
            angle += randomSpread;
            CreateProjectile(rangedAttackData, angle);
        }
    }
    void CreateProjectile(RangedAttackData rangedAttackData, float angle)
    {
        _projectileManager.ShootBullet(
            projectileSpawnPos.position, // 발사 위치
            RotateVector2(_aimDirection, angle), // 회전각
            rangedAttackData // 발사 정보
            );

        if (shootingClip)
            SoundManager.PlayClip(shootingClip);
    }

    static Vector2 RotateVector2(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }
}
