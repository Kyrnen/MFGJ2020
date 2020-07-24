using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CURRENTLY NOT IN USE
/// TO DO: ORGANIZE CODE TO USE THIS MAYBE
/// </summary>
public class StateManager : MonoBehaviour
{
    public float horizontal;
    public float vertical;

    public GameObject player;

    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public Rigidbody rb;

    //public void Init()
    //{
    //    SetupAnimator();
    //    rb = GetComponent<Rigidbody>();

    //}


    //void SetupAnimator()
    //{
    //    if (player == null)
    //    {
    //        anim = GetComponentInChildren<Animator>();
    //        if (anim == null)
    //        {
    //            Debug.Log("No model found");
    //        }
    //        else
    //        {
    //            player = anim.gameObject;
    //        }
    //    }
    //    if (anim == null)
    //    {
    //        anim = player.GetComponent<Animator>();
    //    }

    //    anim.applyRootMotion = false;
    //}

    /// <summary>
    /// CURRENTLY NOT IN USE
    /// Old code for vertical movement removed from Player Movement
    /// </summary>
    //readonly float v_multiplier = 5f;
    //float jumpDistance = 3f;
    //float jumpSpeed = 4f;
    //float fallSpeed = 7f;
    //int level = 0;
    //int targetLevel = 0;

    //private void CheckInput()
    //{
    //    SetSpeed();
    //    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) && canMove && line > -1)
    //    {
    //        targetLine--;
    //        canMove = false;
    //    }
    //    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) && canMove && line < 1)
    //    {
    //        targetLine++;
    //        canMove = false;
    //    }
    //    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && canMove && level < 1)
    //    {
    //        targetLevel++;
    //        canMove = false;

    //    }
    //    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) && canMove && level > 1)
    //    {
    //        targetLevel--;
    //        canMove = false;
    //    }
    //}

    //private void CheckMove()
    //{
    //    Vector3 pos = gameObject.transform.localPosition;
    //    if (!line.Equals(targetLine))
    //    {
    //        if (targetLine == -1 && pos.x > -h_multiplier)
    //        {
    //            Move(Vector3.left);
    //        }
    //        else if (targetLine == 0 && pos.x != 0)
    //        {
    //            if (line == -1 && pos.x < 0)
    //            {
    //                Move(Vector3.right);
    //            }
    //            else if (line == 1 && pos.x > 0)
    //            {
    //                Move(Vector3.left);
    //            }
    //        }
    //        else if (targetLine == 1 && pos.x < h_multiplier)
    //        {
    //            Move(Vector3.right);
    //        }

    //    }
    //    if (!level.Equals(targetLevel))
    //    {

    //        if (targetLevel == 1 && pos.y < v_multiplier)
    //        {
    //            Jump(Vector3.up);
    //        }
    //        if (targetLevel == -1 && pos.y > -v_multiplier)
    //        {
    //            Jump(Vector3.down);
    //        }
    //    }
    //}

    //IEnumerator MoveVert(Vector3 direction)
    //{
    //    Vector3 destination = transform.localPosition + direction * jumpDistance;

    //    while(transform.localPosition != destination)
    //    {
    //        transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination, jumpSpeed * Time.deltaTime);
    //        yield return null;
    //    }

    //    yield return new WaitForSeconds(.1f);
    //    Vector3 endpoint = transform.localPosition - direction * jumpDistance;

    //    while(transform.localPosition != endpoint)
    //    {
    //        transform.localPosition = Vector3.MoveTowards(transform.localPosition, endpoint, fallSpeed * Time.deltaTime);
    //        yield return null;
    //    }

    //    yield return new WaitForEndOfFrame();
    //}

    //private void Jump(Vector3 direction)
    //{
    //    StartCoroutine(MoveVert(direction));
    //    level = targetLevel = 0;
    //    canMove = true;
    //}
}
