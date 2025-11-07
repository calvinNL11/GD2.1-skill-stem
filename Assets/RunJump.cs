using UnityEngine;

public class RunJump : MonoBehaviour
{

    [SerializeField] float Vbegin = 2;
    [SerializeField] float Gbegin = -2;
    Vector3 acc = Vector3.zero;
    Vector3 vel = Vector3.zero;
    Animator animator;
    float t = 0;
    float maxt = 0.867f;
    enum State {run,jump};
    State Mystate = State.run;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        if (Mystate == State.run)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.Play("Jump");
                vel = new Vector3(0,Vbegin ,0);
                Gbegin = -2 * Vbegin / maxt;
                acc = new Vector3(0, Gbegin, 0);
                Mystate = State.jump;
                t = 0;
            }
        }

        if(Mystate == State.jump)
        {
            t += Time.deltaTime;
            if (t > maxt)
            {
                vel = Vector3.zero;
                acc = Vector3.zero;
                Mystate = State.run;
            }
           
        }
        vel += acc * Time.deltaTime;
        transform.position += vel * Time.deltaTime;
    }
}
