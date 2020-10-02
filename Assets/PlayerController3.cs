using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController3 : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 5.0f;
    bool collideWithTrap = false;
    GameObject director;
    GameObject charic;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.director = GameObject.Find("GameDirector3");
        this.charic = GameObject.Find("cat");
    }

    void Update()
    {
        //if (this.transform.position.x >= 2 && this.transform.position.x <= 4)
        //{
        //    GameObject[] trapFloor = GameObject.FindGameObjectsWithTag("trapFloor");
        //    trapFloor[0].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //}
        if ((Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0) || (Input.GetKeyDown(KeyCode.Space) && collideWithTrap == true))
        {
            Debug.Log(this.rigid2D.velocity.y);
            Debug.Log(collideWithTrap);
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            //collideWithTrap = false;
        }
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        if (transform.position.y < -10)
        {
            this.director.GetComponent<GameDirector3>().LifeDown();
            charic.transform.position = new Vector3(0, 1, 0);
            this.director.GetComponent<GameDirector3>().ChangeScene();
        }
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        { 
            this.animator.speed = 1.0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Flag")
            SceneManager.LoadScene("GameClear");
        //if (other.gameObject.tag == "moveFloor1")
        //{
        //    rigid2D.bodyType = RigidbodyType2D.Kinematic;
        //    this.transform.position = new Vector3(other.gameObject.transform.position.x, this.transform.position.y, this.transform.position.z);
        //}


    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "trapFloor2")
        {
            //Debug.Log("trapFloor2");
            collideWithTrap = true;
            other.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            //this.transform.position = new Vector3(other.gameObject.transform.position.x, this.transform.position.y, this.transform.position.z);
        }

    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "trapFloor2")
        {
            //Debug.Log("trapFloor2");
            collideWithTrap = false;
            //this.transform.position = new Vector3(other.gameObject.transform.position.x, this.transform.position.y, this.transform.position.z);
        }

    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "moveFloor1")
        {
            //collideWithFloor = true;
            //rigid2D.bodyType = RigidbodyType2D.Kinematic;
            this.transform.position = new Vector3(other.gameObject.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
    }
    
}
