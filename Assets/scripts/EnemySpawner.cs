using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    public int rounds = 10;
    public int enemiesPerRound = 5;
    public int currentRound = 0;
    public GameObject enemy;
    public GameObject boss;
    public Transform spawner;
    public float cooldown;

    void Awake(){
        instance = this;
    }

    void Start(){
        StartCoroutine(spawning());
    }

    public IEnumerator spawning(){
        if (Tree.instance.gameOn){
            for (int i = 0; i < rounds; i++){
                currentRound = (i+1);
                if (Tree.instance.gameOn){
                    Announcements.instance.Announce("Round " + currentRound + " Started!", 3);
                    for (int u = 0; u < enemiesPerRound; u++){
                        if (Tree.instance.gameOn){
                            GameObject newEnemy = Instantiate(enemy);
                            newEnemy.transform.position = spawner.position;
                            yield return new WaitForSeconds(cooldown);
                        }
                        else break;
                    }
                    if (Tree.instance.gameOn){
                        Announcements.instance.Announce("Boss incoming!", 3);
                        GameObject newBoss = Instantiate(boss);
                        newBoss.transform.position = spawner.position;
                    }
                    else break;
                    yield return new WaitForSeconds(cooldown);
                }
            }
            if (Tree.instance.gameOn){
                Announcements.instance.Announce("You Won!", 10);
                Tree.instance.Win();
                Tree.instance.gameOn = false;
            }
        }
    }
}
