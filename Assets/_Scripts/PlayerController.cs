using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(0, 15), Tooltip("Velocidad del personaje")]
    private float speed = 5;

    private const string AXIS_H = "Horizontal";
    private const string AXIS_V = "Vertical";

    private Animator _animator;
  [SerializeField]  private bool walking = false;
    public Vector2 lastmovement = Vector2.zero;


    private const string WALKING = "Walking";
    private const string LAST_H = "LastH";
    private const string LAST_V = "LastV";

    private Rigidbody2D _rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        MovimientoPersnaje();
        
    }

    private void MovimientoPersnaje()
    {
        walking = false;
        //S = V*t
        if (Mathf.Abs(Input.GetAxisRaw(AXIS_H)) > 0.2f)
        {
            /*
            Vector3 translation = new Vector3(Input.GetAxisRaw(AXIS_H) * speed * Time.deltaTime,0,0);
            this.transform.Translate(translation);
            walking = true;
            lastmovement = new Vector2(Input.GetAxisRaw(AXIS_H),0);*/

            _rigidbody2D.velocity = new Vector2(Input.GetAxisRaw(AXIS_H)* this.speed, _rigidbody2D.velocity.y);
            this.walking = true;
            lastmovement = new Vector2(Input.GetAxisRaw(AXIS_H), 0);
        }

        if (Mathf.Abs(Input.GetAxisRaw(AXIS_V)) > 0.2f)
        {
           /* Vector3 translation = new Vector3(0,Input.GetAxisRaw(AXIS_V) * speed * Time.deltaTime, 0);
            this.transform.Translate(translation);
            walking = true;
            lastmovement = new Vector2(0, Input.GetAxisRaw(AXIS_V));*/
           _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Input.GetAxisRaw(AXIS_V) * this.speed);
           this.walking = true;
           lastmovement = new Vector2(0, Input.GetAxisRaw(AXIS_V));
        }
    }

    private void LateUpdate()
    {
        if (!walking)
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
        _animator.SetFloat(AXIS_H, Input.GetAxisRaw(AXIS_H));
        _animator.SetFloat(AXIS_V, Input.GetAxisRaw(AXIS_V));
        _animator.SetBool(WALKING, walking);
        _animator.SetFloat(LAST_H, lastmovement.x);
        _animator.SetFloat(LAST_V, lastmovement.y);
        
    }
}
