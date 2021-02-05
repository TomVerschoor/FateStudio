using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{
    //Player stats
    public GameObject playerStats;
    
    //Player position saver
    PositionSaver positionSaver;

    //Player attack
    PlayerAttack playerAttack;

    public Transform attackPoint;
    public LayerMask enemyLayer;

    //Player movement
    DirectionalMovement directionalMovement;

    //Beatdamage limiter
    private bool damaged = false;
    private Beattimer damageTakenBeatTimer = new Beattimer();
    public int damageTakenBeatStep = 2;
    private bool damageTakenOnBeat = false;

    private CharacterController controller;
    public Transform cam;
    public Transform groundCheck;
    public LayerMask groundMask;
    private GameObject enemyController;

    private Animator animator;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Stats.Instance == null)
        {
            Instantiate(playerStats, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    private void Start()
    {
        damageTakenBeatTimer.setBeatStep(damageTakenBeatStep);

        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        
        positionSaver = new PositionSaver(gameObject);
        playerAttack = new PlayerAttack(animator, attackPoint, enemyLayer);
        directionalMovement = new DirectionalMovement(animator, transform, cam, groundCheck, groundMask, controller);

        if (SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 13 || SceneManager.GetActiveScene().buildIndex == 25)
            positionSaver.LoadPosition();
    }

    // Update is called once per frame
    private void Update()
    {
        directionalMovement.PlayerMovement();

        if(SceneManager.GetActiveScene().buildIndex <= 4 && !PauseMenu.gameIsPaused)
            playerAttack.AnimationDelay();

        if (Stats.Instance.Health <= 0)
        {
            try
            {
                enemyController = GameObject.Find("EnemyOverworldController");
                EnemyOverworldController.firstInstance = true;
                Destroy(enemyController);
            }
            catch (NullReferenceException)
            {

            }
            PlayerPrefs.DeleteAll();
            Stats.Instance.ResetStats();
            SceneManager.LoadScene(Stats.Instance.Scene);
        }

        damageTakenOnBeat = damageTakenBeatTimer.onBeat(BeatManager.beat);
        if (damageTakenOnBeat)
            DamageControl.damaged = false;

        //Debug
        Debug.Log("HP: " + Stats.Instance.Health);
        if (Input.GetKeyDown("m"))
            Stats.Instance.TakeDamange(-1);

        if (Input.GetKeyDown("n"))
            Stats.Instance.TakeDamange(1);

    }

    private void FixedUpdate()
    {
            directionalMovement.PlayerJump();
    }

    public void SavePosition()
    {
            positionSaver.SavePosition();
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null || playerAttack == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, playerAttack.AttackRange);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Damage")
    //    {
    //        Debug.Log("HP: " + Stats.Instance.Health);
    //        Debug.Log("HIT " + other.gameObject.name);
    //        if (!damaged)
    //        {
    //            Debug.Log("DAMAGED!");
    //            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Synthia/Hurt/Hurt SFX");
    //            Stats.Instance.TakeDamange(1);
    //        }
    //        DamageControl.damaged = true;
    //    }
    //}

}
