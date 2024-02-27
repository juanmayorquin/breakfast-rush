using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    private Transform dragging = null;
    private Vector3 offset;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                                                 float.PositiveInfinity, LayerMask.GetMask("Movable"));

            if (hit)
            {
                dragging = hit.transform;
                offset = dragging.position - UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragging = null;
        }

        if (dragging != null)
        {
            dragging.position = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bread") && gameObject.CompareTag("ham"))
        {

        }
    }
}
