using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public AudioSource pop;
    public string foodName;
    private Transform dragging = null;
    private Vector3 offset;
    private Rigidbody2D rb;

    public bool isRecipe;
    
    private RecipeManager recipeManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        recipeManager = FindObjectOfType<RecipeManager>();
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
                GameObject result = recipeManager.FindRecipeResult(gameObject.GetComponent<FoodItem>(), collision.gameObject.GetComponent<FoodItem>());
                if (result != null)
                {
                    //Debug.Log("Se ha creado: " + result.name);
                    pop.Play();
                    Instantiate(result, gameObject.transform.position, Quaternion.identity);
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}
