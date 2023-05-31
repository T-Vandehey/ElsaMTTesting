using Elsa.Activities.MassTransit.Consumers;

namespace ElsaMTTestng
{
    public static class MTHelper
    {
        public static Type CreateWorkflowConsumer<T>() => typeof(WorkflowConsumer<>).MakeGenericType(typeof(T));

    }
}
