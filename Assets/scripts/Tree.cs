using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Tree : MonoBehaviour
{
    public static Tree instance;
    public int health = 10;
    public bool gameOn = false;
    public GameObject[] nutSpawn;
    public float spawnCoolDown = 1;
    public GameObject collectable;
    public GameObject endGameMenu;

    void Awake(){
        gameOn = true;
        instance = this;
    }

    void Start(){
        StartCoroutine(NutSpawning());
    }

    void Update()
    {
        if (health <= 0 && gameOn){
            Lose();
            gameOn = false;
            Announcements.instance.Announce("You lost!", 10);
        }
    }

    public void Lose(){
        StopCoroutine(EnemySpawner.instance.spawning());
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < enemies.Length; i++){
            Destroy(enemies[i]);
        }
        transform.Rotate(0, 0, 90);
        transform.position = new Vector2(-5, -4.5f);
        Squirrel.instance.Fall();
        endGameMenu.SetActive(true);
    }
    public void Win(){
        endGameMenu.SetActive(true);
    }

    public IEnumerator NutSpawning(){
        int randomPoint = Random.Range(0, nutSpawn.Length);
        GameObject newCollectable = Instantiate(collectable);
        newCollectable.transform.position = nutSpawn[randomPoint].transform.position;
        yield return new WaitForSeconds(spawnCoolDown);
        if (gameOn){
            StartCoroutine(NutSpawning());
        }
    }
}
