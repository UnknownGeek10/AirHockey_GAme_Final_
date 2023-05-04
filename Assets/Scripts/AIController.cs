using UnityEngine;

public class AIController : MonoBehaviour
{
    //public CountdownController countdownController;
    //public countdownTime CountdownTime;
    public float MaxMovementSpeed;
    private Rigidbody2D rb;
    private Vector2 startingPosition;

    public Rigidbody2D Puck;
    public SpriteRenderer PuckRenderer;
    private float puckRadius;

    public Transform AIBoundaryHolder;
    private Boundary aiBoundary;

    public Transform PuckBoundaryHolder;
    private Boundary puckBoundary;

    private Vector2 targetPosition;

    private bool isFirstTimeInOpponentsHalf = true;
    private float offsetYFromTarget;
    float timer = 3f;
    //public Text countdownDisplay ;

    private void Start()
    {
       // Puck.gameObject.SetActive(true);
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;

        aiBoundary = new Boundary(AIBoundaryHolder.GetChild(0).position.y,
                              AIBoundaryHolder.GetChild(1).position.y,
                              AIBoundaryHolder.GetChild(2).position.x,
                              AIBoundaryHolder.GetChild(3).position.x);

        puckBoundary = new Boundary(PuckBoundaryHolder.GetChild(0).position.y,
                              PuckBoundaryHolder.GetChild(1).position.y,
                              PuckBoundaryHolder.GetChild(2).position.x,
                              PuckBoundaryHolder.GetChild(3).position.x);

        puckRadius = PuckRenderer.bounds.extents.x;
    }

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;


        if (!PuckController.WasGoal && timer<=0)
            {
                float movementSpeed;

                if (Puck.position.x < puckBoundary.left)
                {
                    if (isFirstTimeInOpponentsHalf)
                    {
                        isFirstTimeInOpponentsHalf = false;
                        offsetYFromTarget = Random.Range(-1f, 1f);
                    }

                    movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.3f);
                    targetPosition = new Vector2(startingPosition.x, Mathf.Clamp(Puck.position.y + offsetYFromTarget, aiBoundary.down, aiBoundary.up));
                }
                else
                {
                    isFirstTimeInOpponentsHalf = true;

                    movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);

                    float addX, addY;

                    if (Puck.position.x > rb.position.x) addX = puckRadius; else if (Puck.position.x == rb.position.x) addX = 0; else addX = puckRadius * -1;
                    if (Puck.position.y > rb.position.y) addY = puckRadius; else if (Puck.position.y == rb.position.y) addY = 0; else addY = puckRadius * -1;

                    targetPosition = new Vector2(Mathf.Clamp(Puck.position.x + addX, aiBoundary.left, aiBoundary.right),
                                                 Mathf.Clamp(Puck.position.y + addY, aiBoundary.down, aiBoundary.up));
                }

                rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, movementSpeed * Time.fixedDeltaTime));
            }
        

        
    }

        public void ResetPosition()
        {
            rb.position = startingPosition;
            isFirstTimeInOpponentsHalf = true;
        }
    
}