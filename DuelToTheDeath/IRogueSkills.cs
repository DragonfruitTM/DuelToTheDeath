using System;

public interface IRogueSkills
{
    void BowAttack(int otherObjectHitPoints);

    void SwordAttack(int otherObjectHitPoints);

    void DeadAttack(int otherObjectHitPoints, int healthPoints);

    void ShieldDefense(int otherObjectAttackPoints);

    void DodgeAttackDefense(int otherObjectAttackPoints);

    void CollectHealthPointsFromCorpses(int healthPoints);

    void TakeRestHealthRestoration(int healthPoints);
}
