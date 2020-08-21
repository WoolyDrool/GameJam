using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildPickup : MonoBehaviour
{
    public Transform theChild = null;
    public Transform holdPosition;
    public Vector3 holdPos;
    public float range = 3;
    public bool isHoldingChild = false;
    public float throwForce = 500;
    public RaycastHit2D hit2D;
    public Ray2D ray;
    public float chargeCounter;
    float chargeMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        holdPos = new Vector3(holdPosition.position.x, holdPosition.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.E) && !isHoldingChild)
        {
            hit2D = Physics2D.Raycast(holdPosition.position, holdPosition.TransformDirection(Vector2.up), range);
            {
                isHoldingChild = true;
                theChild = hit2D.transform;
                theChild.parent = holdPosition;
                
                
            }
        }

        if(isHoldingChild)
        {
            theChild.localPosition = holdPosition.localPosition;
        }
        
        if(Input.GetButtonDown("Fire1") && isHoldingChild)
        {
            theChild.GetComponent<Rigidbody2D>().AddForce(holdPosition.TransformDirection(Vector2.up) * throwForce, ForceMode2D.Impulse);
            Debug.Log("rele");
            holdPosition.DetachChildren();
            isHoldingChild = false;
            theChild = null;
        }
    }
}
