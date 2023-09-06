using UnityEngine;

public class BouncerComponent : MonoBehaviour
{
    //TODO: Sacar valores de inicialización a scriptables
    [SerializeField]
    private static float initialBallSpeed = 3f;
    [SerializeField]
    private static int initialBallStrength = 1;


    Rigidbody2D rb;
    protected float ballSpeed;
    protected int ballStrength; 
    
    public void Initialize(float ballSpeed)
    {
        this.Initialize(ballSpeed, initialBallStrength);
    }
    public void Initialize(int ballStrength)
    {
        this.Initialize(initialBallSpeed, ballStrength);
    }
    private void Initialize(float ballSpeed, int ballStrength)
    {
        this.ballSpeed = ballSpeed;
        this.ballStrength = ballStrength;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * ballSpeed;
    }

    private void Update()
    {
        if(rb.velocity == Vector2.zero)
        {
            rb.velocity = Vector2.left * ballSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = rb.velocity.normalized * ballSpeed;
        //Previene que la bola choque en recto constantemente
        if (IsStraightCollision(collision))
        {
            rb.velocity = Vector2.one * ballSpeed;
        }
    }

    private bool IsStraightCollision(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;
        Vector2 vel = rb.velocity;
        float angle = Vector2.Angle(vel, -normal);
        return angle == 180;
    }

    public int GetBallStrength()
    {
        return ballStrength;
    }
}
