using UnityEngine;

namespace Mechadroids {
    public class EnemyFollowState : IEntityState {
        private readonly IEntityHandler entityHandler;
        private readonly EnemyReference enemyReference;
        private Transform playerTransform;

        public EnemyFollowState(IEntityHandler entityHandler, EnemyReference enemyReference) {
            this.entityHandler = entityHandler;
            this.enemyReference = enemyReference;
        }

        public void Enter() {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            // Optionally set idle animation
        }

        public void LogicUpdate() {



        }

        public void PhysicsUpdate() {
            RotateTowards((playerTransform.position -enemyReference.transform.position).normalized);
        }

        public void Exit() {
            // Cleanup if necessary

        }


        private void RotateTowards(Vector3 direction) {
            if(direction.magnitude == 0) return;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            enemyReference.transform.rotation = Quaternion.Slerp(
                enemyReference.transform.rotation,
                targetRotation,
                enemyReference.enemySettings.enemy.patrolRotationSpeed * Time.deltaTime
            );
        }


    }

}
