using UnityEngine;

class PlayerAttack
{
    private Transform attackPoint;
    private LayerMask enemyLayer;
    private Animator animator;

    public float AttackRange { get; set; }
    private float waitTimePerAttack = 0.5f;
    private float nextAttackWaitTime;
    private int damage = 1;
    private int specialDamage = 3;
    private int attacking = Animator.StringToHash("Upward Thrust");

    /*
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        combo = PlayerPrefs.GetInt("combo", 0);
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("attacking waittime is : " + nextAttackWaitTime);
        AnimationDelay();
    }
    */

    public PlayerAttack(Animator animator, Transform attackPoint, LayerMask enemyLayer)
    {
        AttackRange = 1.5f;
        this.animator = animator;
        this.attackPoint = attackPoint;
        this.enemyLayer = enemyLayer;
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayAttackAnimation();

            if (BeatManager.beat)
            {
                Collider[] hittedEnemies = GetHittedEnemies();

                foreach (Collider hittedEnemy in hittedEnemies)
                {
                    EnemyHit(hittedEnemy, damage);
                    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy/Hurt/Hurt SFX", attackPoint.position);
                }
            }
            else Stats.Instance.ResetCombo();
        }
    }

    private void SpecialAttack()
    {
        if (Stats.Instance.Combo >= 5 && Input.GetMouseButtonDown(1) && BeatManager.beat)
        {
            PlayAttackAnimation();

            Collider[] hittedEnemies = GetHittedEnemies();

            foreach (Collider hittedEnemy in hittedEnemies)
            {
                EnemyHit(hittedEnemy, specialDamage);
                Stats.Instance.ResetCombo();
            }
        }
    }

    private Collider[] GetHittedEnemies()
    {
        return Physics.OverlapSphere(attackPoint.position, AttackRange, enemyLayer);
    }

    private void EnemyHit(Collider hittedEnemy, int damage)
    {
        hittedEnemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage * 2);
        Stats.Instance.ComboUp();
    }

    private void PlayAttackAnimation()
    {
        animator.Play(attacking);
        nextAttackWaitTime = waitTimePerAttack;
    }

    public void AnimationDelay()
    {
        if(nextAttackWaitTime <= 0)
        {
            Attack();
            SpecialAttack();
        }
        else
        {
            nextAttackWaitTime -= Time.deltaTime;
        }
    }
}
