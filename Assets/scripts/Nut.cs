using Unity.VisualScripting;
using UnityEngine;

public class Nut : MonoBehaviour
{
    void OnCollisionEnter2D(){
        Destroy(gameObject);
    }
}
