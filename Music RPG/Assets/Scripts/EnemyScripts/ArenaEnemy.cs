using UnityEngine;

public class ArenaEnemy : MonoBehaviour
{
    //For diff enemies
    // 0 = standard

    public Transform enemyPos;
    public Transform playerPos;
    //public bool stand = false;

    //Radius
    private int meleeRad; //Recom 2
    private int chaseRad; //Recom 10
    private int RangeRad; //Recom 20

    //Shield
    private GameObject shield; //ASK SEAN FOR EXP. WAS GONNA USE FOR SPAWN AND DELETE!
    private bool shielded = false;

    //Used to face player
    private Transform playerLocation;
    private Transform enemyLocation;

    //Range on beat
    private Beattimer rangeBeatTimer = new Beattimer();
    private int rangeBeatStep = -1;
    private bool rangeOnBeat = false;
    //Trown projectile
    private GameObject spawnPoint;
    private GameObject projectile;
    private float forwardForce = 35f;
    private DamageControl damConRange;
    private double rangeDam;
    //Animation
    private Beattimer rangeAnimBeatTimer = new Beattimer();
    private bool rangeAnimOnBeat = false;

    //Shockwave on beat
    private Beattimer shockwaveBeatTimer = new Beattimer();
    private int shockwaveBeatStep = -1;
    private bool shockwaveOnBeat = false;
    private GameObject shockwaveObject;
    private DamageControl[] damConShock;
    private double shockDam;
    //Animation
    private Beattimer shockwaveAnimBeatTimer = new Beattimer();
    private bool shockwaveAnimOnBeat = false;

    //Spread on beat
    private float spreadAngel = 40f;
    private Beattimer spreadBeatTimer = new Beattimer();
    private int spreadBeatStep = -1;
    public bool spreadOnBeat = false;
    //Dangerzone spawns 1 beat faster
    private GameObject dangerZone;
    public bool dangerZoneOnBeat = false;
    private Beattimer dangerZoneTimer = new Beattimer();
    //Animation
    private Beattimer spreadAnimBeatTimer = new Beattimer();
    private bool spreadAnimOnBeat = false;

    //Animation
    private Animator animator;
    private int attackingHash = Animator.StringToHash("enemyAttacking");
    private int attackHash = Animator.StringToHash("Attacking");
    private int stompingHash = Animator.StringToHash("enemyStomp");
    private int stompHash = Animator.StringToHash("Stomp");


    //######################################################
    //TEMPLATE
    //
    //private Beattimer tempBeatTimer = new Beattimer();
    //public int tempBeatStep = 4;
    //private bool tempOnBeat = false;
    //
    //START
    //tempBeatTimer.setBeatStep(tempBeatStep);
    //
    //UPDATE
    //tempOnBeat = tempBeatTimer.onBeat(BeatManager.beat);
    //
    //TEMPLATE
    //######################################################

    public ArenaEnemy(Transform enemyPos, Animator animator, GameObject spawnpoint, GameObject projectile, int rangeBeatStep, double rangeDam, GameObject shock, int shockwaveBeatStep, double shockDam, GameObject danger, int spreadBeatStep, GameObject shield)
    {
        this.enemyPos = enemyPos;
        this.spawnPoint = spawnpoint;
        this.projectile = projectile;
        this.rangeBeatStep = rangeBeatStep;
        this.rangeDam = rangeDam;
        this.shockwaveObject = shock;
        this.shockwaveBeatStep = shockwaveBeatStep;
        this.shockDam = shockDam;
        this.dangerZone = danger;
        this.spreadBeatStep = spreadBeatStep;
        this.shield = shield;
        this.animator = animator;

        playerPos = GameObject.Find("Player").transform;

        if (rangeBeatStep == shockwaveBeatStep)
        {
            this.shockwaveBeatStep = shockwaveBeatStep * 2;
        }

        if (rangeBeatStep > 0 && rangeBeatStep < 8)
        {
            rangeAnimBeatTimer.setBeatStep(7);
            rangeBeatTimer.setBeatStep(8);
        }
        else
        {
            rangeAnimBeatTimer.setBeatStep(this.rangeBeatStep - 1);
            rangeBeatTimer.setBeatStep(this.rangeBeatStep);
        }

        if (shockwaveBeatStep > 0 && shockwaveBeatStep < 8)
        {
            shockwaveAnimBeatTimer.setBeatStep(7);
            shockwaveBeatTimer.setBeatStep(8);
        }
        else
        {
            shockwaveAnimBeatTimer.setBeatStep(this.shockwaveBeatStep - 1);
            shockwaveBeatTimer.setBeatStep(this.shockwaveBeatStep);
        }

        if (spreadBeatStep > 0 && spreadBeatStep < 8)
        {
            dangerZoneTimer.setBeatStep(6);
            spreadBeatTimer.setBeatStep(8);
            spreadAnimBeatTimer.setBeatStep(7);
        }
        else
        {
            dangerZoneTimer.setBeatStep(this.spreadBeatStep - 2);
            spreadBeatTimer.setBeatStep(this.spreadBeatStep);
            spreadAnimBeatTimer.setBeatStep(this.spreadBeatStep - 1);
        }

    }

    public void EnemyBehaviour()
    {
        shield.gameObject.transform.Rotate(0, -10, 0);
        damConShock = shockwaveObject.GetComponentsInChildren<DamageControl>();
        foreach (DamageControl damageControl in damConShock)
        {
            damageControl.setDamage(shockDam);
        }

        damConRange = this.projectile.GetComponent<DamageControl>();
        damConRange.setDamage(rangeDam);
        rangeOnBeat = rangeBeatTimer.onBeat(BeatManager.beat);
        shockwaveOnBeat = shockwaveBeatTimer.onBeat(BeatManager.beat);
        spreadOnBeat = spreadBeatTimer.onBeat(BeatManager.beat);
        dangerZoneOnBeat = dangerZoneTimer.onBeat(BeatManager.beat);
        //Animations
        shockwaveAnimOnBeat = shockwaveAnimBeatTimer.onBeat(BeatManager.beat);
        rangeAnimOnBeat = rangeAnimBeatTimer.onBeat(BeatManager.beat);
        spreadAnimOnBeat = spreadAnimBeatTimer.onBeat(BeatManager.beat);

        /*Animations
        animator.SetBool(attackingHash, rangeOnBeat);
        animator.SetBool(stompingHash, shockwaveOnBeat);
        */

        //if (!stand)
        //{
        //    FacePlayer();
        //}
        defence();
        animationPlayer();
        attackMove();
    }

    //private void FacePlayer()
    //{
    //    Vector3 direction = (playerPos.position - enemyPos.position).normalized;
    //    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    //    enemyPos.rotation = Quaternion.Slerp(enemyPos.rotation, lookRotation, Time.deltaTime * 5f);
    //}

    //private void FacePlayer()
    //{
    //    playerLocation = GameObject.Find("Player").transform;
    //    enemyLocation = GameObject.Find("EnemyBattle").transform;

    //    Vector3 direction = (GameObject.Find("Player").transform.position - transform.position).normalized;
    //    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    //    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    //}

    private void animationPlayer()
    {
        if (spreadAnimOnBeat)
        {
            spreadAnimBeatTimer.setBeatStep(this.spreadBeatStep);
            animator.Play(attackHash);
        }
        if (shockwaveAnimOnBeat)
        {
            shockwaveAnimBeatTimer.setBeatStep(this.shockwaveBeatStep);
            if (!spreadAnimOnBeat)
            {
                animator.Play(stompHash);
            }
        }
        if (rangeAnimOnBeat)
        {   
            rangeAnimBeatTimer.setBeatStep(this.rangeBeatStep);
            if (!spreadAnimOnBeat && !shockwaveAnimOnBeat)
            {
                animator.Play(attackHash);
            }
        }
    }

    private void attackMove()
    {
        if (dangerZoneOnBeat)
        {
            // #####################
            // Put animations here
            // Maybe some charging animation
            // #####################
            dangerZoneTimer.setBeatStep(this.spreadBeatStep);
            shielded = true;
            //Rigidbody shieldRB = Instantiate(shield, enemyPos.transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)).GetComponent<Rigidbody>();
            //Rigidbody line = Instantiate(dangerZone, enemyPos.transform.position + new Vector3(0, -2f, 0), Quaternion.Euler(0, enemyPos.transform.rotation.eulerAngles.y - spreadAngel / 2, 0)).GetComponent<Rigidbody>();
            //Rigidbody line2 = Instantiate(dangerZone, enemyPos.transform.position + new Vector3(0, -2f, 0), Quaternion.Euler(0, enemyPos.transform.rotation.eulerAngles.y + spreadAngel / 2, 0)).GetComponent<Rigidbody>();

            float half = spreadAngel / 2;
            float spreadStep = spreadAngel / 5;

            enemyPos.transform.Rotate(0, -half, 0);
            for (int i = 0; i < spreadStep; i++)
            {
                enemyPos.transform.Rotate(0, 5, 0);
                Instantiate(dangerZone, enemyPos.transform.position + new Vector3(0, -1.7f, 0), Quaternion.Euler(0, enemyPos.transform.rotation.eulerAngles.y, 0)).GetComponent<Rigidbody>();
            }
            enemyPos.transform.Rotate(0, -half, 0);
        }
        if (spreadOnBeat)
        {
            //animator.SetBool(attackingHash, true);
            //animator.Play(attackHash);
            // #####################
            // Put animations here
            // Maybe some spinning animation
            // #####################
            spreadBeatTimer.setBeatStep(this.spreadBeatStep);
            Spread();
            shielded = false;

            //animator.SetBool(attackingHash, false);
        }
        if (shockwaveOnBeat)
        {
            //animator.Play(stompHash); //Here
            shockwaveBeatTimer.setBeatStep(this.shockwaveBeatStep);
            if (!spreadOnBeat && !dangerZoneOnBeat)
            {
                //animator.Play(stompHash);
                //animator.SetBool(stompingHash, true);

                // #####################
                // Put animations here
                // Maybe some stomp
                // #####################
                Shockwave();

                //animator.SetBool(stompingHash, false);
            }
        }
        if (rangeOnBeat) //
        {
            rangeBeatTimer.setBeatStep(this.rangeBeatStep);
            if (!shockwaveOnBeat && !spreadOnBeat && !dangerZoneOnBeat)
            {
                //animator.Play(attackHash); //Here
                //animator.SetBool(attackingHash, true);

                // #####################
                // Put animations here
                // Maybe some shooting
                // #####################
                Range();
                
                //animator.SetBool(attackingHash, false);
            }
        }
    }

    private void Range()
    {
        Rigidbody rb = Instantiate(projectile, spawnPoint.transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)).GetComponent<Rigidbody>();
        rb.AddForce(spawnPoint.transform.forward * forwardForce, ForceMode.Impulse);

        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy/Projectile/Projectile SFX", rb.transform.position);
    }

    private void Shockwave()
    {
        Quaternion rotation = Quaternion.Euler(270, 0, 0);
        Rigidbody rb = Instantiate(shockwaveObject, enemyPos.transform.position + new Vector3(0, -1.5f, 0), rotation).GetComponent<Rigidbody>();
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy/Stomp/Stomp SFX", enemyPos.transform.position);
    }

    private void Spread()
    {
        float half = spreadAngel / 2;
        float spreadStep = spreadAngel / 5;

        enemyPos.transform.Rotate(0, -half, 0);
        for (int i = 0; i < spreadStep; i++)
        {
            enemyPos.transform.Rotate(0, 5, 0);
            Range();
        }
        //enemyPos.transform.Rotate(0, 180, 0);
        //for (int i = 0; i < spreadStep; i++)
        //{
        //    enemyPos.transform.Rotate(0, -5, 0);
        //    Range();
        //}
        //enemyPos.transform.Rotate(0, 180, 0);
    }

    private void defence()
    {
        if (BeatManager.beat) //shielded || 
        {
            shield.transform.position = new Vector3(shield.transform.parent.position.x, -10, shield.transform.parent.position.z);
        }
        else
            shield.transform.position = new Vector3(shield.transform.parent.position.x, shield.transform.parent.position.y, shield.transform.parent.position.z);
        if (shielded)
        {
            shield.transform.position = new Vector3(shield.transform.parent.position.x, shield.transform.parent.position.y, shield.transform.parent.position.z);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player with Enemy");
        }
    }

}
