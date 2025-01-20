using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] private float life;

    public void RecieveDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    public float GetLife()
    {
        return life;
    }
}
