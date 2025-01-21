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
        if (Treee.instance.gameOn){
            for (int i = 0; i < rounds; i++){
                currentRound = (i+1);
                if (Treee.instance.gameOn){
                    Announcements.instance.Announce("Round " + currentRound + " Started!", 3);
                    for (int u = 0; u < enemiesPerRound; u++){
                        if (Treee.instance.gameOn){
                            GameObject newEnemy = Instantiate(enemy);
                            newEnemy.transform.position = spawner.position;
                            yield return new WaitForSeconds(cooldown);
                        }
                        else break;
                    }
                    if (Treee.instance.gameOn){
                        Announcements.instance.Announce("Boss incoming!", 3);
                        GameObject newBoss = Instantiate(boss);
                        newBoss.transform.position = spawner.position;
                    }
                    else break;
                    yield return new WaitForSeconds(cooldown);
                }
            }
            if (Treee.instance.gameOn){
                Announcements.instance.Announce("You Won!", 10);
                Treee.instance.Win();
                Treee.instance.gameOn = false;
            }
        }
    }
}
