﻿using System;
using System.Collections;
using UnityEngine;
using Zombie.Characters;

namespace ZombieRunner.Characters
{
    //[RequireComponent(typeof(HealthSystem))]
    [RequireComponent(typeof(ZombieCharacter))]
    //[RequireComponent(typeof(WeaponSystem))]
    public class ZombieAI : MonoBehaviour
    {
        [SerializeField] float chaseRadius = 9f;
        [SerializeField] WaypointContainer patrolPath;
        [SerializeField] float waypointTolerance = 2.0f;
        [SerializeField] float waypoinDwellTime = 2.0f;


        enum State { Idle, Attacking, Patrolling, Chasing }
        State state = State.Idle;

        Player player;
        //PlayerControl player;
        ZombieCharacter character;
        float currentWeaponRange = 4f;
        float distanceToPlayer;
        int nextwayPointIndex = 0;

        void Start()
        {
            player = GameObject.FindObjectOfType<Player>();
            character = GetComponent<ZombieCharacter>();
        }

        void Update()
        {
            distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            //WeaponSystem weaponSystem = GetComponent<WeaponSystem>();
           // currentWeaponRange = weaponSystem.GetCurrentWeapon().GetMaxAttackRange();
            bool inWeaponCircle = distanceToPlayer <= currentWeaponRange;
            bool inChaseRing = distanceToPlayer > currentWeaponRange && distanceToPlayer <= chaseRadius;
            bool outsideChaseRing = distanceToPlayer > chaseRadius;

            if (outsideChaseRing)
            {
                state = State.Patrolling;

                //stop what we are doing
                StopAllCoroutines();

                //weaponSystem.StopAttacking();

                //start patrolling
                StartCoroutine(Patrol());

            }

            if (inChaseRing)
            {
                //stop what we are doing
                StopAllCoroutines();

               // weaponSystem.StopAttacking();

                //chase player
                StartCoroutine(ChasePlayer());
            }

            if (inWeaponCircle)
            {
                state = State.Attacking;
                //stop what we are doing
                StopAllCoroutines();

                //attack player
                //weaponSystem.AttackTarget(player.gameObject);

            }
        }

        IEnumerator Patrol()
        {
            state = State.Patrolling;

            while (patrolPath != null)
            {
                Vector3 nextWaypointPos = patrolPath.transform.GetChild(nextwayPointIndex).position;
                character.SetDestination(nextWaypointPos);
                CycleWaypointWhenClose(nextWaypointPos);
                yield return new WaitForSeconds(waypoinDwellTime);
            }

            //so pra nao dar erro> REMOVER
            yield return new WaitForSeconds(waypoinDwellTime);
        }

        private void CycleWaypointWhenClose(Vector3 nextWaypointPos)
        {
            if (Vector3.Distance(transform.position, nextWaypointPos) <= waypointTolerance)
            {
                nextwayPointIndex = (nextwayPointIndex + 1) % patrolPath.transform.childCount;
            }
        }

        IEnumerator ChasePlayer()
        {
            state = State.Chasing;
            while (distanceToPlayer >= currentWeaponRange)
            {
                character.SetDestination(player.transform.position);
                yield return new WaitForEndOfFrame();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(255f, 0f, 0, .5f);
            Gizmos.DrawWireSphere(transform.position, currentWeaponRange);

            Gizmos.color = new Color(0f, 0f, 255, .5f);
            Gizmos.DrawWireSphere(transform.position, chaseRadius);
        }
    }

}