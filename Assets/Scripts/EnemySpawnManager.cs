using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zombie.Characters;

namespace ZombieRunner.Characters
{
    public class EnemySpawnManager : MonoBehaviour
    {

        //[SerializeField]
        //Transform[] SpawmCoordinates;

        [SerializeField]
        ZombieCharacter ZombiePrefab;

        Player player;

        float timeSinceLastTrigger = 3000;
        float spawnCooldown = 3000;

        // Use this for initialization
        void Start()
        {
            player = FindObjectOfType<Player>();
        }

        // Update is called once per frame
        void Update()
        {
            timeSinceLastTrigger += Time.deltaTime;
            if (player.IsHelicopterCalled() && timeSinceLastTrigger > spawnCooldown)
            {
                print("Time to spawn zombies");
                Spawn();
                spawnCooldown = 0;
            }
        }

        void Spawn()
        {
            // Find a random index between zero and one less than the number of spawn points.
            //int spawnPointIndex = Random.Range(0, SpawmCoordinates.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            var newZombie = Instantiate(ZombiePrefab, transform.position,Quaternion.identity);

            print("Setting destination to player " + player.transform.position);

            newZombie.SetDestination(player.transform.position);
        }
    }
}
