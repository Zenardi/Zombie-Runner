using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    enum EnemyStateAI
    {
        Attack,
        Chase,

    };

    [RequireComponent(typeof (NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target; // target to aim for
        private Animator animator;
        private float stoppingDistance = 2f;
        private bool closeEnough = false;
        private EnemyStateAI enemyStateAi = EnemyStateAI.Chase;
        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            animator = GetComponent<Animator>();
            
	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        // Update is called once per frame
        private void Update()
        {
            if (target != null)
            {
                closeEnough = Vector3.Distance(target.position, this.transform.position) < stoppingDistance;

                if (closeEnough)
                {
                    
                    StopAllCoroutines();
                    StartCoroutine(StopAndAttack());
                }
                else if (enemyStateAi == EnemyStateAI.Chase)
                {
                    if (closeEnough)
                    {
                        enemyStateAi = EnemyStateAI.Attack;
                    }
                    else
                    {
                        StopAllCoroutines();
                        StartCoroutine(ChasePlayer());
                    }
                }
            }
            else
            {
                // We still need to call the character's move function, but we send zeroed input as the move param.
                character.Move(Vector3.zero, false, false);
            }

        }

        private IEnumerator ChasePlayer()
        {
            animator.SetBool("runToIdle0", false);
            animator.SetBool("idle0ToRun", true);
            Vector3 direction = target.position - this.transform.position;
            //right now this causes Apex to face the player with its stinger. this will be useful for the virus effected, but wasn't what I was going for

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                            Quaternion.LookRotation(direction), 0.1f); //same as above note. not sure what went wrong


            agent.SetDestination(target.position);


            // use the values to move the character
            character.Move(agent.desiredVelocity, false, false);

            yield return new WaitForEndOfFrame();
        }

        private IEnumerator StopAndAttack()
        {
            //agent.SetDestination(target.position);

            animator.SetBool("idle0ToRun", false);
            animator.SetBool("runToIdle0", true);

            // use the values to move the character
            character.Move(Vector3.zero, false, false);

            yield return new WaitForEndOfFrame();

        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
