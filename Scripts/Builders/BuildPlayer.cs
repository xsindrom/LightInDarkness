using UnityEngine;
using System.Collections;

public class BuildPlayer : SingletonRealisation<BuildPlayer>
{
    [Header("Components")]
    public Transform transformer;
    public Animator animator;
    public SpriteRenderer spriteRender;
    public Rigidbody2D rigidBody;
    public new Collider2D collider;
    [Header("PlayerStats")]
    public GameStats gameStats = new GameStats();
    public PhysicStats physicStats = new PhysicStats();

    [Header("Movement")]
    public MeterCounter meterCounter;
    public MovementController movementController;
    public IPlayerMovement movement;
    [Header("AdditionalSystems")]
    public BonusSystem bonusSystem;
    public PlayerSpeedIncreaser speedBooster;
    [Header("Childs")]
    public GameObject deathEffects;
    public GameObject tailEffects;
    public GameObject barrierEffects;
    private void Awake()
    {
        transformer = gameObject.GetComponent<Transform>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        collider = gameObject.GetComponent<Collider2D>();
        movement = gameObject.GetComponent<IPlayerMovement>();
        
        //--Init MovementController---
        movementController = gameObject.GetComponent<MovementController>();
        movementController.Init(movement, physicStats);

        //--Init MetterCounter---
        if (!meterCounter) { meterCounter = gameObject.AddComponent<MeterCounter>(); }
        meterCounter.Init(gameStats,transformer);
        //--Init BonusSystem---
        bonusSystem = gameObject.GetComponent<BonusSystem>();
        //--Init Speed booster
        speedBooster = gameObject.GetComponent<PlayerSpeedIncreaser>();
        speedBooster.Init();
        //--Init Effects---
        tailEffects = transform.FindChild("TailEffects").gameObject;
        deathEffects = transform.FindChild("DeathEffects").gameObject;
        barrierEffects = transform.FindChild("BarrierEffects").gameObject;

        //--Init Events---
        gameStats.onIsAliveChange += LeadersSystem.ReportLeader;
        gameStats.onIsAliveChange += UserStats.Instance.SaveCurrency;
    }
    public void DeActivatePlayer()
    {
        movementController.enabled = false;
        spriteRender.enabled = false;
        collider.enabled = false;
        tailEffects.SetActive(false);
        deathEffects.SetActive(true);
    }
    public void OnDestroyPlayer()
    {
        DeActivatePlayer();
        gameStats.IsAlive = false;
    }
}
