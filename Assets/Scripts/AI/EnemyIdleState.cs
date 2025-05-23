using UnityEngine;

namespace Mechadroids {
    public class EnemyIdleState : IEntityState {
        private readonly IEntityHandler entityHandler;
        private readonly EnemyReference enemyReference;
        private float idleDuration = 2f;
        private float idleTimer;

        public EnemyIdleState(IEntityHandler entityHandler, EnemyReference enemyReference) {
            this.entityHandler = entityHandler;
            this.enemyReference = enemyReference;
        }

        public void Enter() {
            idleTimer = 0f;
            // Optionally set idle animation
        }

        public void LogicUpdate() {
            idleTimer += Time.deltaTime;
            if(idleTimer >= idleDuration) {
                TransitionToPatrolState();
            }
        }

        public void PhysicsUpdate() {
            // No physics updates needed in idle state
        }

        public void Exit() {
            // Cleanup if necessary
        }

        private void TransitionToPatrolState() {
            Exit();
            entityHandler.EntityState = new EnemyPatrolState(entityHandler, enemyReference);
            entityHandler.EntityState.Enter();
        }
        /*private void SetNextPatrolDestination() {
            if(enemyReference.enemySettings.routeSettings.routePoints.Length == 0) return;
            currentPatrolIndex %= enemyReference.enemySettings.routeSettings.routePoints.Length;
        }

        private void MoveTowardsPatrolPoint() {
            if(enemyReference.enemySettings.routeSettings.routePoints.Length == 0) return;

            Vector3 targetPoint = enemyReference.enemySettings.routeSettings.routePoints[currentPatrolIndex];
            targetPoint.y = enemyReference.transform.position.y;
            Vector3 direction = (targetPoint - enemyReference.transform.position).normalized;

            // Move towards the target point
            enemyReference.transform.position += direction * enemyReference.enemySettings.enemy.patrolSpeed * Time.deltaTime;

            // Rotate towards the target point
            RotateTowards(direction);

            // Check if the enemy has reached the patrol point
            if(Vector3.Distance(enemyReference.transform.position, targetPoint) <= 0.1f) {
                currentPatrolIndex = (currentPatrolIndex + 1) % enemyReference.enemySettings.routeSettings.routePoints.Length;
                SetNextPatrolDestination();
            }
        }*/

    }

}
