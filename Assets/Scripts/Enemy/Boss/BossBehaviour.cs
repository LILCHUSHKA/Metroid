using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class BossBehaviour : MonoBehaviour
{
    [HideInInspector] public UnityEvent<Transform> OnPlayerFind;
    [HideInInspector] public UnityEvent<bool> OnHeroIsDead;

    [Header("–азмер области, в которой босс будет атаковать")]
    [SerializeField] protected Vector2 attackAreaSize;

    protected Vector2 startPosition;
    protected Vector3 characterScale;

    DamageHandler damageHandler;
    [HideInInspector] public EnemyHealthHandler healthHandler;
    Character character;

    protected Animator animator;
    [HideInInspector] public Transform playerTransform = null;
    protected BoxCollider2D bossTrigger;

    [HideInInspector] public int availableStages = 0, stageNumber = 1;

    [Header("—писок стадий у босса с их параметрами")]
    [SerializeField] List<Stage> stages;

    private void Awake()
    {
        character = GetComponent<Character>();
        healthHandler = GetComponent<EnemyHealthHandler>();
        animator = GetComponent<Animator>();
        damageHandler = GetComponent<DamageHandler>();
        bossTrigger = GetComponent<BoxCollider2D>();

        startPosition = transform.position;
        characterScale = transform.localScale;
    }

    private void OnEnable()
    {
        healthHandler.OnHealthChange.AddListener(health =>
        {
            if (character.health == stages[availableStages].nextStageHealth)
            {
                if (stages[availableStages].stageType == Stage.StageTypes.faze)
                    ActiveNextFaze(stages[availableStages].stageName);

                availableStages++;
            }
        });

        damageHandler.OnGiveDamage.AddListener(player => HitPlayer(playerTransform));
    }

    protected bool CheckPlayerPosition(Vector2 areaType)
    {
        return (Vector2.Distance(transform.position, playerTransform.position) < areaType.x / 1.5f)
            || playerTransform.position.x < transform.position.x;
    }

    public void CreateSolution(string nextAnimationName)
    {
        int solution = Random.Range(1, 10);

        if (solution > 4)
        {
            if (availableStages >= stageNumber)
            {
                if (CheckPlayerPosition(attackAreaSize)) PlayNextPunch(nextAnimationName);
                else return;
            }
            else return;
        }
        else return;
    }

    protected void PlayNextPunch(string punchName)
    {
        stageNumber++;

        if (stageNumber == availableStages) animator.SetTrigger(punchName);
        else stageNumber = 1;
    }

    protected virtual void ActiveNextFaze(string nextFazeAnimationName) => animator.Play(nextFazeAnimationName);

    protected virtual void HitPlayer(Transform player)
    {
    }
}

[System.Serializable]
public class Stage
{
    public string stageName;
    public int nextStageHealth;

    public enum StageTypes
    {
        stage,
        faze
    }
    public StageTypes stageType;
}