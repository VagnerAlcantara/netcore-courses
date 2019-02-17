namespace ModernStore.Infra.Transations
{
    public interface IUow
    {
        void Commit();
        void Rollback();
    }
}
