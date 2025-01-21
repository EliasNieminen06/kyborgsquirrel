using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public GameObject tree;
    public Rigidbody2D rb;
    public float speed;
    public int damage;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        tree = GameObject.FindGameObjectWithTag("tree");
    }

    void Update()
    {
        if (health <= 0){
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, tree.transform.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("tree")){
            other.GetComponent<Treee>().health -= damage;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("nut")){
            health--;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("exnut")){
            health -= 10;
            Destroy(other.gameObject);
        }
    }
}
