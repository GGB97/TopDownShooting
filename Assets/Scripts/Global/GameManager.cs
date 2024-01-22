using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform Player {  get; private set; }
    [SerializeField] string PlayerTag = "Player";

    private void Awake()
    {
        instance = this;
        Player = GameObject.FindGameObjectWithTag(PlayerTag).transform;
    }
}
