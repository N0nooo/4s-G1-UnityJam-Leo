using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour
{
    public float chasingTime;
    float chasingTimer;

    [Range(.1f, .8f)]
    public float distanceDistractionValue = 0.2f;

    /// <summary>
    /// 0 = Triggered
    /// 1 = Distracted
    /// </summary>
    private int alertIndex;

    [SerializeField] Transform[] patrolPoints;
    [SerializeField] float movementSpeed;
    public int destination;
    [SerializeField] float chaseSpeed;

    public GameObject player;

    public GameObject enemyLight;
    public Rigidbody2D enemy;
    
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // moves to patrol point A
        if (destination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, movementSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
            {
                transform.localScale = new Vector3(-1, 2, 1);
                enemyLight.transform.localScale = new Vector3(-1, 2, 1);
                destination = 1;
            }
        }
        // moves to patrolpoint B
        else if (destination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, movementSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                enemyLight.transform.localScale = new Vector3(1, 1, 1);
                destination = 0;
            }
        }
    }
    
    /// <summary>
    /// if the players colliders is in reach, enemy starts to chase
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //gameover
            
        }
    }
}
