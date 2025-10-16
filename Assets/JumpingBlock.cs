using UnityEngine;

public class JumpingBlock : MonoBehaviour
{
    [SerializeField] private Vector3 gravityBegin = new Vector3(0, -9.81f, 0);
    [SerializeField] private Transform Block;
    [SerializeField] Vector3 velocityBegin = new Vector3(0, 5, 0);
    private float beginY;

    private Vector3 velocity;
    private Vector3 gravity;

    enum State
    {
        Grounded,
        Airborne
    }
    private State myState = State.Grounded;

    void Start()
    {
        beginY = Block.position.y;
        velocity = velocityBegin;
    }

    void Update()
    {

        if (myState == State.Grounded)
        {
            velocity = Vector3.zero;
            gravity = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                gravity = gravityBegin;
                velocity = velocityBegin;
                myState = State.Airborne;
            }
        }
        else if (myState == State.Airborne)
        {
            if (Block.position.y <= beginY)
            {
                velocity = Vector3.zero;
                gravity = Vector3.zero;
                Block.position = new Vector3(Block.position.x, beginY, 0);
                myState = State.Grounded;
            }
        }

        velocity += gravity * Time.deltaTime;
        Block.position += velocity * Time.deltaTime;
    }
}
