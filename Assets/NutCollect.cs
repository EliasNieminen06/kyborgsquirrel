using Unity.VisualScripting;
using UnityEngine;

public class NutCollect : MonoBehaviour
{
    public float lifeSpan;
    void Start(){
        Destroy(gameObject, lifeSpan);
    }
    void OnMouseDown(){
        Squirrel.instance.nuts++;
        Destroy(this.gameObject);
    }

}
