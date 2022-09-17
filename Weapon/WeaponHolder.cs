using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHolder : MonoBehaviour
{
    public Vector2 PointerPosition {get; set;}
    public Animator animator;

    public int damage = 1;
    public float delay = 0.67f;
    public bool attackOnDelay;
    public Transform circleOrigin;
    public float radius;
    void Update()
    {
        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;

        
    }

    public void Attack()
    {
        if(attackOnDelay)
            return;
        animator.SetTrigger("Attack");
        //IsAttacking = true;
        attackOnDelay = true;
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackOnDelay = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    public void DetectColliders()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(circleOrigin.position,radius);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log(this.name + "We hit" + enemy.name);
            Health health;
            if(health = enemy.GetComponent<Health>())
            {
                health.GetHit(damage,transform.parent.gameObject);
            }
        }
    }
}
