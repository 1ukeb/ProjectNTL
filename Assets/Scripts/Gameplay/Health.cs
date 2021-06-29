using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTL.Gameplay
{
    public class Health : MonoBehaviour
    {
        [SerializeField] protected int maxHealth;
        [SerializeField] protected int currentHealth;

        protected bool isDead;
        public bool isImmune;
        
        public virtual void Reset()
        {
            currentHealth = maxHealth;
            isDead = false;
        }

        public virtual void TakeDamage(int damage)
        {
            if(isImmune || isDead)
                return;

            currentHealth -= damage;

            if(currentHealth <= 0)
                Die();
        }

        public virtual void Heal(int heal)
        {
            currentHealth += heal;
        }

        public virtual void Die()
        {
            isDead = true;
        }
    }
}
