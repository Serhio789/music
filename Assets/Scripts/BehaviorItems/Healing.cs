public class Healing : ItemForPlayer
{
    public float healPoint;
    public void HealingPlayer()
    {
        playerObject.GetComponent<PlayerHealth>().Healing(healPoint);
        playerObject.GetComponent<Inventori>().DestroyObject(idItem);
        Destroy(gameObject);
    }

    public override void Using()
    {
        HealingPlayer();
    }
}
