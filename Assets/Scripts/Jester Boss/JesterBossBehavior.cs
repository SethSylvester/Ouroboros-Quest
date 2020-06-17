using UnityEngine;

public class JesterBossBehavior : EnemyBehavior
{
    //private variables
    private float attackTimerDefault = 8.0f;
    private float attackTimer;

    //The character controller
    private bool hasAttack = false;

    public Attack currentAttack = new Attack();

    public float timeDefault = 1.5f;
    private float time;

    //Attack GameObjects
    [SerializeField]
    private GameObject spreadShot;
    [SerializeField]
    private GameObject knifeFork;
    [SerializeField]
    private GameObject knifeShower;

    //Knife Fork Projectiles & Variables
    [SerializeField]
    private GameObject projectile1;
    [SerializeField]
    private GameObject projectile2;
    [SerializeField]
    private GameObject projectile3;
    [SerializeField]
    private GameObject projectile4;

    private bool active1 = false;
    private bool active2 = false;
    private bool active3 = false;
    private bool active4 = false;

    public bool returning = false;


    // Start is called before the first frame update
    private void Start()
    {
        attackTimer = attackTimerDefault;
        time = timeDefault;
    }

    // Update is called once per frame
    private void Update()
    {
        if (hasAttack)
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
            }
            //Tick down the timer after picking the attack
            AttackTimer();
        }
        else
        {
            SelectAttack();
        }
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

        //Pick a random attack
        currentAttack = (Attack)Random.Range(1, 4);

        //Reset the knifefork attack if its picked
        if (currentAttack == Attack.KnifeFork)
        { ResetKnifeFork(); }

        //Tell the Jester it has an attack
        hasAttack = true;
    }

    private void KnifeFork()
    {
        //Tick down the timer
        time -= Time.deltaTime;

        //if all are active and ready to return
        if (active1 && active2 && active3 && active4 && time <= 0)
        { returning = true; }

        else if (!active1)
        {
            projectile1.SetActive(true);
            active1 = true;
        }
        else if (!active2 && time <= 0)
        {
            projectile2.SetActive(true);
            active2 = true;
            time = timeDefault;
        }
        else if (!active3 && time <= 0)
        {
            projectile3.SetActive(true);
            active3 = true;
            time = timeDefault;
        }
        else if (!active4 && time <= 0)
        {
            projectile4.SetActive(true);
            active4 = true;
            time = timeDefault;
        }
    }

    private void ResetKnifeFork()
    {
        time = timeDefault;

        returning = false;
        active1 = false;
        active2 = false;
        active3 = false;
        active4 = false;
    }
}
public enum Attack
{
    None,
    Spreadshot,
    KnifeFork,
    KnifeShower
}