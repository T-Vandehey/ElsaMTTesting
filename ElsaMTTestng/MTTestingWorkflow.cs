using Elsa.Activities.Console;
using Elsa.Activities.MassTransit;
using Elsa.Builders;
using ElsaMTTestng.Models;

namespace ElsaMTTestng
{
    public class MTTestingWorkflow : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder
            .ReceiveMassTransitMessage(activity => activity.Set(x => x.MessageType, _ => typeof(One)))
            .WriteLine("****************************************")
            .WriteLine("Received One Message")
            .WriteLine("****************************************")

            .WriteLine("****************************************")
            .ReceiveMassTransitMessage(activity => activity.Set(x => x.MessageType, _ => typeof(Two)))
            .WriteLine("Received Two Message")
            .WriteLine("****************************************")

            .WriteLine("****************************************")
            .ReceiveMassTransitMessage(activity => activity.Set(x => x.MessageType, _ => typeof(Three)))
            .WriteLine("Received Three Message")
            .WriteLine("****************************************")

            .WriteLine("****************************************")
            .ReceiveMassTransitMessage(activity => activity.Set(x => x.MessageType, _ => typeof(Four)))
            .WriteLine("Received Four Message")
            .WriteLine("****************************************")

            .WriteLine("****************************************")
            .ReceiveMassTransitMessage(activity => activity.Set(x => x.MessageType, _ => typeof(Five)))
            .WriteLine("Received Five Message")
            .WriteLine("****************************************")


            .WriteLine("****************************************")
            .WriteLine("----- Finished Workflow -----")
            .WriteLine("****************************************");
        }
    }
}
