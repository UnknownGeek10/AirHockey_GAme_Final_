using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckController : MonoBehaviour
{
    public ScoreManager ScoreManagerInstance;
    public static bool WasGoal { get; private set; }
    private Rigidbody2D rb;
    public float maxSpeed;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!WasGoal)
        {
            if (collision.tag == "BotGoal")
            {

                ScoreManagerInstance.Increment(ScoreManager.Score.PlayerScore);
                WasGoal = true;

                StartCoroutine(ResetPuck(1));
            }
            else if (collision.tag == "PlayerGoal")
            {
                ScoreManagerInstance.Increment(ScoreManager.Score.BotScore);
                WasGoal = true;
                StartCoroutine(ResetPuck(-1));
            }
        }
    }

    private IEnumerator ResetPuck(int xMulty)
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        rb.velocity = new Vector2(0, 0);
        rb.position = new Vector2(4 * xMulty, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }

    public void CenterPuck()
    {
        rb.position = new Vector2(0, 0);
        rb.velocity = new Vector2(0, 0);
    }
}
