using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public string foodName;
    private Transform dragging = null;
    private Vector3 offset;
    private Rigidbody2D rb;

    [SerializeField] private Sprite sprite;
    [SerializeField] private bool isClonable;
    
    private RecipeManager recipeManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = rb.GetComponent<Sprite>();
        recipeManager = GameObject.FindObjectOfType<RecipeManager>();
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
                if (hit.transform.gameObject.CompareTag("Clone"))
                {
                    // Iniciar el arrastre del clon
                    dragging = hit.transform;
                    offset = dragging.position - UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
                else
                {
                    GameObject clone = Instantiate(hit.transform.gameObject, hit.transform.position, hit.transform.rotation);
                    clone.tag = "Clone";
                    dragging = clone.transform;
                    offset = dragging.position - UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<FoodItem>())
        {
            if (collision.gameObject.CompareTag("Clone") && gameObject.CompareTag("Clone"))
            {
                FoodItem result = recipeManager.FindRecipeResult(gameObject.GetComponent<FoodItem>(), collision.gameObject.GetComponent<FoodItem>());
                if (result != null)
                {
                    Debug.Log(result.sprite);
                    Instantiate(result.gameObject, collision.transform);
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}
