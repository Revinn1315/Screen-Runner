using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFilter;
    public float groundDistance = 0.5f;
    CapsuleCollider2D touchingColl;
    Animator animator;
    Rigidbody2D rb;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];

    [SerializeField] private bool _isGrounded = true;

    public bool isGrounded
    { 
        get 
        {
            return _isGrounded;
        } 
        private set
        {
            _isGrounded = value;
            animator.SetBool(AnimationStrings.isGrounded, value);
        }
    }
    
    private void Awake()
    {
        touchingColl = GetComponent<CapsuleCollider2D>();    
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = touchingColl.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
    }
}
