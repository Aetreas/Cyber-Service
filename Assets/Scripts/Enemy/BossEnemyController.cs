using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyController : MonoBehaviour
{
    public GameObject enemyObj;
    public ThirdPersonMovement pc;
    public GameObject FixScrapPrompt;
    public GameObject FixScrapDialog;
    public GameObject hostileMesh;
    //public GameObject AttackCollider;
    
    public bool fixInteract = false;
    public bool scrapInteract = false;
    public bool enemyDown = false;
    public bool isFixed = false;
    public bool EnemyCanAttack = true;
    public bool EnemyIsAttacking = false;
    public float EnemyAttackCooldown = 3.0f;
    public int maxHealth = 150;    
    public int currentHealth;

    //FOV attack detector
    public float radius;
    [Range(0,360)]

    public float angle;
    public GameObject playerRef;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public bool attackRange;

    
    // Jan's Variable Implementations
    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public float startWaitTime = 4;
    public float timeToRotate = 2;
    public float speedWalk = 6;
    public float speedRun = 8;

    public float viewRadius = 15;
    public float viewAngle = 90;
    public LayerMask playerMask;
    public LayerMask obstacleMask;
    public float meshResolution = 1f;
    public int edgeIterations = 4;
    public float edgeDistance = 0.5f;

    public Transform[] waypoints;
    int m_CurrentWaypointIndex;

    Vector3 playerLastPosition = Vector3.zero;
    Vector3 m_PlayerPosition;

    float m_WaitTime;
    float m_TimeToRotate;
    bool m_PlayerInRange;
    bool m_PlayerNear;
    bool m_IsPatrol;
    bool m_CaughtPlayer;

    //soundeffects
    [SerializeField] private AudioClip damagesoundclip;
    [SerializeField] private AudioClip fixsoundclip;
    [SerializeField] private AudioClip destroysoundclip;


    private void Awake()
    {
        //Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        FixScrapPrompt.SetActive(false);
        FixScrapDialog.SetActive(false);
        //AttackCollider.SetActive(false);
        //Jan's Variable Initializing
        m_PlayerPosition = Vector3.zero;
        m_IsPatrol = true;
        m_CaughtPlayer = false;
        m_PlayerInRange = false;
        m_WaitTime = startWaitTime;
        m_TimeToRotate = timeToRotate;

        m_CurrentWaypointIndex = 0;
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speedWalk;
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);

        //FOV attack detection
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(AttackFOVRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        //fix and scrap bool stuff
        if (Input.GetButtonDown("Interact"))
        {
            fixInteract = true;
        }

        if (Input.GetButtonDown("Interact2"))
        {
            scrapInteract = true;
        }

        if (Input.GetButtonUp("Interact"))
        {
            fixInteract = false;
        }

        if (Input.GetButtonUp("Interact2"))
        {
            scrapInteract = false;
        }

        //death function
        if (currentHealth <= 0)
        {
            GetComponent<BoxCollider>().enabled = false;
            FixScrapPrompt.SetActive(true);
            enemyDown = true;
            EnemyCanAttack = false;
            Stop();
            //Destroy(enemyObj);
        }

        //damage tester
        //if (Input.GetKeyDown(KeyCode.K))
        //{
            //EnemyTakeDamage(20);
            //Debug.Log(GameManager.gameManager.enemyHP.Health);
        //}

        //Jan's Update Function Calls
        EnvironmentView();

        if (!m_IsPatrol)
        {
            Chasing();
        }
        else
        {
            Patrolling();
        }

        if (attackRange == true)
        {
            if(EnemyCanAttack == true)
            {
                speedWalk = 0;
                EnemyAttack();
            }
        }
        else
        {
            speedWalk = 6;
            GetComponent<Animator>().ResetTrigger("Attack");
            Patrolling();
        }


        //GetComponent<Animator>().SetTrigger("Attack");
    }

    public void EnemyTakeDamage(int amount)
    {
        SoundEffectScripts.instance.PlaySoundClip(damagesoundclip, transform, 1f);
        currentHealth -= amount;
        Debug.Log(currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && enemyDown == true && isFixed == false)
        {
            FixScrapDialog.SetActive(true);
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Player" && fixInteract == true && enemyDown == true)
        {
            SoundEffectScripts.instance.PlaySoundClip(fixsoundclip, transform, 1f);
            hostileMesh.SetActive(false);
            fixInteract = false;
            FixScrapPrompt.GetComponent<BoxCollider>().enabled = false;
            ThirdPersonMovement.Instance.AddHonor();
            ThirdPersonMovement.Instance.AddTotalBots();
            FixScrapDialog.SetActive(false);
            GetComponent<Animator>().ResetTrigger("Walking");
            GetComponent<Animator>().SetBool("FixedAnimation", true);
            //GetComponent<Animator>().SetBool("Idle", true);
            GetComponent<Rigidbody>().isKinematic = true;
            isFixed = true;
            this.enabled = false;
        }

        if (other.gameObject.tag == "Player" && scrapInteract == true && enemyDown == true && isFixed == false)
        {
            SoundEffectScripts.instance.PlaySoundClip(destroysoundclip, transform, 1f);

            scrapInteract = false;
            Destroy(enemyObj);
            FixScrapDialog.SetActive(false);
            ThirdPersonMovement.Instance.AddTotalBots();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FixScrapDialog.SetActive(false);
        }
        
    }

    public void EnemyAttack()
    {
        EnemyIsAttacking = true;
        EnemyCanAttack = false;
        StartCoroutine(EnemyDealDamage());
        GetComponent<Animator>().SetTrigger("Attack");
        StartCoroutine(ResetEnemyCooldown());
    }

    IEnumerator EnemyDealDamage()
    {
        if(EnemyIsAttacking)
        {
            yield return new WaitForSeconds(0.5f);
            pc.PlayerTakeDamage(11);
            //Debug.Log(GameManager.gameManager.playerHP.Health);
        }
    }

    private IEnumerator AttackFOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    public void FieldOfViewCheck()//detects player character for attacking, respects objects on the wall layer such that player cannot be damaged through them.
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    attackRange = true;
                    
                else
                    attackRange = false;
            }
            else
                attackRange = false;
        }
        else if (attackRange)
            attackRange = false;
    }

    //Jan's tutorial methods

    private void Chasing()
    {
        m_PlayerNear = false;
        playerLastPosition = Vector3.zero;

        if (!m_CaughtPlayer)
        {
            Move(speedRun);
            navMeshAgent.SetDestination(m_PlayerPosition);
        }
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if (m_WaitTime <= 0 && !m_CaughtPlayer && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 6f)
            {
                m_IsPatrol = true;
                m_PlayerNear = false;
                Move(speedWalk);
                m_TimeToRotate = timeToRotate;
                m_WaitTime = startWaitTime;
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            }
            else
            {
                if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 2.5f)
                {
                    Stop();
                    m_WaitTime -= Time.deltaTime;
                }
            }
        }
    }
    private void Patrolling()
    {
        if (m_PlayerNear)
        {
            if (m_TimeToRotate <= 0)
            {
                Move(speedWalk);
                LookingPlayer(playerLastPosition);
            }
            else
            {
                Stop();
                m_TimeToRotate -= Time.deltaTime;
            }
        }
        else
        {
            m_PlayerNear = false;
            playerLastPosition = Vector3.zero;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (m_WaitTime <= 0)
                {
                    NextPoint();
                    Move(speedWalk);
                    m_WaitTime = startWaitTime;
                }
                else
                {
                    Stop();
                    m_WaitTime -= Time.deltaTime;
                }
            }
        }
    }
    void Move(float speed)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speed;
        GetComponent<Animator>().SetTrigger("Walking");
        GetComponent<Animator>().SetBool("Idle", false);
    }
    void Stop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0;
        GetComponent<Animator>().SetBool("Idle", true);
    }
    public void NextPoint()
    {
        m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
    }
    void CaughtPlayer()
    {
        m_CaughtPlayer = true;
    }
    void LookingPlayer(Vector3 character)
    {
        navMeshAgent.SetDestination(character);
        if (Vector3.Distance(transform.position, character) <= 0.3)
        {
            if (m_WaitTime <= 0)
            {
                m_PlayerNear = false;
                Move(speedWalk);
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
                m_WaitTime = startWaitTime;
                m_TimeToRotate = timeToRotate;
            }
            else
            {
                Stop();
                m_WaitTime -= Time.deltaTime;
            }
        }
    }
    void EnvironmentView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, playerMask);

        for (int i = 0; i < playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToPlayer) < viewAngle / 2)
            {
                float dstToPlayer = Vector3.Distance(transform.position, player.position);
                if (!Physics.Raycast(transform.position, dirToPlayer, dstToPlayer, obstacleMask))
                {
                    m_PlayerInRange = true;
                    m_IsPatrol = false;
                }
                else
                {
                    m_PlayerInRange = false;
                }
            }
            if (Vector3.Distance(transform.position, player.position) > viewRadius)
            {
                m_PlayerInRange = false;
            }
            if (m_PlayerInRange)
            {
                m_PlayerPosition = player.transform.position;
            }
        }
    }

    IEnumerator ResetEnemyCooldown()
    {
        StartCoroutine(ResetEnemyBool());
        yield return new WaitForSeconds(EnemyAttackCooldown);
        EnemyCanAttack = true;
    }

    IEnumerator ResetEnemyBool()
    {
        yield return new WaitForSeconds(2.0f);
        EnemyIsAttacking = false;
    }
    }
