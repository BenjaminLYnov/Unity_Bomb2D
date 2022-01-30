using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private Animator animator;
    private int orientation = 0;

    private bool movingRight;
    private bool movingLeft;
    private bool movingUp;
    private bool movingDown;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        moving();
        returnAnimationVar();
    }

    void moving()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 && Input.GetAxisRaw("Vertical") == 0)
            movingRight = true;
        else
            movingRight = false;

        if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxisRaw("Vertical") == 0)
            movingLeft = true;
        else
            movingLeft = false;

        if (Input.GetAxisRaw("Vertical") > 0)
            movingUp = true;
        else
            movingUp = false;

        if (Input.GetAxisRaw("Vertical") < 0)
            movingDown = true;
        else
            movingDown = false;
    }

    int getOrientation()
    {
        if (Input.GetAxis("Vertical") > 0)
            orientation = 0;

        else if (Input.GetAxis("Vertical") < 0)
            orientation = 2;

        else if (Input.GetAxis("Horizontal") > 0)
            orientation = 3;

        else if (Input.GetAxis("Horizontal") < 0)
            orientation = 1;

        return orientation;
    }

    bool getIsMoving()
    {
        if (Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") != 0)
            return true;
        else
            return false;
    }

    void returnAnimationVar()
    {
        animator.SetBool("Moving Right", movingRight);
        animator.SetBool("Moving Left", movingLeft);
        animator.SetBool("Moving Up", movingUp);
        animator.SetBool("Moving Down", movingDown);
        animator.SetBool("Is Moving", getIsMoving());
        animator.SetInteger("Orientation", getOrientation());
    }
}
