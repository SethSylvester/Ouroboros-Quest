using UnityEngine;

public class JesterBossBehavior : MonoBehaviour
{
    //private variables
    private int hp = 100;
    //Timers
    private float attackTimerDefault = 8.0f;
    private float attackTimer;
    private float vulnerabilityTimerDefault = 5.0f;
    private float vulnerabilityTimer;
    private float knifeForkTimeDefault = 1.5f;
    private float knifeForkTime;
    private float SuperWaveTimerDefault = 1f;
    private float SuperWaveTimer;

    //int Timers
    private int attackLimit = 2;
    private int attacks;

    //The character booleans
    private bool canAttack = true;

    private bool hasAttack = false;
    private bool vulnerable = false;

    private bool waveOne = false;
    private bool waveTwo = false;
    private bool waveThree = false;

    //Which attack its using
    public Attack currentAttack = new Attack();

    //Attack GameObjects
    [SerializeField]
    private GameObject spreadShot;
    [SerializeField]
    private GameObject knifeFork;
    [SerializeField]
    private GameObject knifeShower;
    [SerializeField]
    private GameObject WaveOne;
    [SerializeField]
    private GameObject WaveTwo;
    [SerializeField]
    private GameObject WaveThree;

    //Knife Fork Projectiles & Variables
    [SerializeField]
    private GameObject projectile1;
    [SerializeField]
    private GameObject projectile2;
    [SerializeField]
    private GameObject projectile3;
    [SerializeField]
    private GameObject projectile4;

    //KnifeFork booleans
    private bool active1 = false;
    private bool active2 = false;
    private bool active3 = false;
    private bool active4 = false;

    public bool returning = false;


    // Start is called before the first frame update
    private void Start()
    {
        //Set the timers to their default
        attackTimer = attackTimerDefault;
        vulnerabilityTimer = vulnerabilityTimerDefault;
        knifeForkTime = knifeForkTimeDefault;
        SuperWaveTimer = SuperWaveTimerDefault;
    }

    // Update is called once per frame
    private void Update()
    {
        if (hasAttack && canAttack)
        {
            //Attack
            BossAttack();

            //Tick down the timer after picking the attack
            AttackTimer();
        }
        else if (canAttack)
        {
            SelectAttack();
        }
    }

    private void BossAttack()
    {
        switch (currentAttack)
        {
            case Attack.Spreadshot:
                if (spreadShot.activeSelf == false)
                {
                    spreadShot.SetActive(true);
                }
                break;

            case Attack.KnifeFork:
                if (knifeFork.activeSelf == false)
                { knifeFork.SetActive(true); }

                KnifeFork();
                break;

            case Attack.KnifeShower:
                if (knifeShower.activeSelf == false)
                {
                    knifeShower.SetActive(true);
                }
                break;
            case Attack.SuperAttack:
                SuperAttackOne();
                break;
            case Attack.None:
                Vulnerability();
                break;
        }
    }

    //When the boss isnt attacking
    private void Vulnerability()
    {
        attacks = 0;
        vulnerable = true;
    }

    private void AttackTimer()
    {
        //Tick down the attack timer
        attackTimer -= Time.deltaTime;
        
        //When the timers at 0 reset it and the has attack
        if (attackTimer <= 0)
        {
            attackTimer = attackTimerDefault;
            hasAttack = false;
        }
    }

    private void SelectAttack()
    {
        //Disable all attacks
        spreadShot.SetActive(false);
        knifeFork.SetActive(false);
        knifeShower.SetActive(false);

        waveOne = false;
        waveTwo = false;
        waveThree = false;

        if (attacks < attackLimit)
        {
            vulnerable = false;

            //Pick a random attack
            currentAttack = (Attack)Random.Range(1, 5);

            //Reset the knifefork attack if its picked
            if (currentAttack == Attack.KnifeFork)
            { ResetKnifeFork(); }

            attacks++;
        }

        else
        {
            currentAttack = Attack.None;
            attackTimer = 5.0f;
        }

        //Tell the Jester it has an attack
        hasAttack = true;
    }

    private void SuperAttackOne()
    {
        if (!waveOne)
        {
            waveOne = true;
            WaveOne.SetActive(true);
        }
        SuperWaveTimer -= Time.deltaTime;
        if (SuperWaveTimer <= 0 || waveTwo || waveThree)
        {
            SuperAttackTwo();
        }
    }

    private void SuperAttackTwo()
    {
        if (WaveOne.activeSelf)
        { WaveOne.SetActive(false); }

        if (!waveTwo)
        {
            waveTwo = true;
            WaveTwo.SetActive(true);
            SuperWaveTimer = SuperWaveTimerDefault;
        }

        SuperWaveTimer -= Time.deltaTime;

        if (SuperWaveTimer <= 0 || waveThree)
        {
            SuperAttackThree();
        }

    }

    private void SuperAttackThree()
    {
        if (WaveTwo.activeSelf)
        { WaveTwo.SetActive(false); }

        if (!waveThree)
        {
            waveThree = true;
            WaveThree.SetActive(true);
            SuperWaveTimer = 4;
        }

        SuperWaveTimer -= Time.deltaTime;

        if (SuperWaveTimer <= 0)
        {
            WaveThree.SetActive(false);
            SuperWaveTimer = SuperWaveTimerDefault;
            attacks = 2;
        }
    }

    private void KnifeFork()
    {
        //Tick down the timer
        knifeForkTime -= Time.deltaTime;

        //if all are active and ready to return
        if (active1 && active2 && active3 && active4 && knifeForkTime <= 0)
        { returning = true; }

        else if (!active1)
        {
            projectile1.SetActive(true);
            active1 = true;
        }
        else if (!active2 && knifeForkTime <= 0)
        {
            projectile2.SetActive(true);
            active2 = true;
            knifeForkTime = knifeForkTimeDefault;
        }
        else if (!active3 && knifeForkTime <= 0)
        {
            projectile3.SetActive(true);
            active3 = true;
            knifeForkTime = knifeForkTimeDefault;
        }
        else if (!active4 && knifeForkTime <= 0)
        {
            projectile4.SetActive(true);
            active4 = true;
            knifeForkTime = knifeForkTimeDefault;
        }
    }

    private void ResetKnifeFork()
    {
        //Reset timer
        knifeForkTime = knifeForkTimeDefault;
        //Reset booleans
        returning = false;
        active1 = false;
        active2 = false;
        active3 = false;
        active4 = false;
    }

    public void TakeDamage(int damage)
    {
        //Do more damage if vulnerable
        if (vulnerable)
        {
            damage *= 5;
        }

        //subtract damage from hp
        hp -= damage;

        //Die if HP is less than or equal to zero
        if (hp <= 0)
        { Die(); }

    }

    private void Die()
    {
        //Disable all attacks
        spreadShot.SetActive(false);
        knifeFork.SetActive(false);
        knifeShower.SetActive(false);
        WaveOne.SetActive(false);
        WaveTwo.SetActive(false);
        WaveThree.SetActive(false);

        //Disable the boss from attacking
        canAttack = false;
    }

    public int GetHealth()
    {
        return hp;
    }
}
public enum Attack
{
    None,
    Spreadshot,
    KnifeFork,
    KnifeShower,
    SuperAttack,
}