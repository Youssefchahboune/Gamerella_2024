using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    private string facingDirection = "LEFT";
    [SerializeField] private Transform characterTransform;
    
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.right = -direction;

        Debug.Log(transform.rotation.z);

        if((transform.rotation.z > 0.71 ||  transform.rotation.z < -0.71) && facingDirection != "RIGHT")
        {
            //Debug.Log("Facing right");
            facingDirection = "RIGHT";
            characterTransform.localScale = new Vector3((-1 * characterTransform.localScale.x), characterTransform.localScale.y, characterTransform.localScale.z);
            transform.localScale = new Vector3(-1,-1, 1);

        }
        else if ((transform.rotation.z <= 0.71 && transform.rotation.z >= -0.71) && facingDirection != "LEFT")
        {

            //Debug.Log("Facing Left");
            facingDirection = "LEFT";
            characterTransform.localScale = new Vector3(-characterTransform.localScale.x, characterTransform.localScale.y, characterTransform.localScale.z);
            transform.localScale = new Vector3(1,1, 1);

        }
        Debug.Log(facingDirection);
    }
}
