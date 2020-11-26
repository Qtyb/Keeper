namespace Common.EventBus.Interfaces
{
    public interface IEventBusSubscriber
    {
        void SetupSubscriber();

        void Subscribe<T>()
            where T : class;
    }
}