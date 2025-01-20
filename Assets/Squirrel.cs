using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Squirrel : MonoBehaviour
{
    public static Squirrel instance;
    public int nuts = 0;
    public GameObject nut;
    public GameObject exNut;
    public float throwingForce = 10;
    public int nutLifeTime = 2;
    public float longClickTime;
    float clickTime;

    void Awake(){
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)){
            clickTime = Time.time;
        }
        if (Input.GetMouseButtonUp(1)){
            float duration = Time.time - clickTime;
                if (duration < longClickTime){
                    if (nuts > 0){
                        ShortClick();
                    }
                    else Announcements.instance.Announce("Out of nuts!", 1);
                }
                if (duration > longClickTime){
                    if (nuts >= 3){
                        LongClick();
                    }
                    else Announcements.instance.Announce("Not enough nuts! (3 needed for explosive nut)", 3);
                }
        }

        if (nuts > 5) nuts = 5;
    }

    void ShortClick(){
        GameObject newNut = Instantiate(nut);
        newNut.transform.position = transform.position;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector2 throwDirection = (mousePosition - transform.position).normalized;
        newNut.GetComponent<Rigidbody2D>().AddForce(throwDirection * throwingForce, ForceMode2D.Impulse);
        nuts--;
        Destroy(newNut, nutLifeTime);
    }

    void LongClick(){
        GameObject newNut = Instantiate(exNut);
        newNut.transform.position = transform.position;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector2 throwDirection = (mousePosition - transform.position).normalized;
        newNut.GetComponent<Rigidbody2D>().AddForce(throwDirection * throwingForce, ForceMode2D.Impulse);
        nuts -= 3;
        Destroy(newNut, nutLifeTime);
    }
}
