using Unity.VisualScripting;
using UnityEngine;

public class Nut : MonoBehaviour
{
    public GameObject particle;
    void OnCollisionEnter2D(){
        if (gameObject.CompareTag("exnut")){
            GameObject newPart = Instantiate(particle);
            newPart.transform.position = transform.position;
        }
        Destroy(gameObject);
    }
}
