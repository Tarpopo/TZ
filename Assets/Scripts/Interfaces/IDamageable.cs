public interface IDamageable
{
    bool IsDeath { get; }
    void TakeDamage(int damage);
}