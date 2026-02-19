using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Contracts.Messaging
{
    // Decide which queue get message 
    public static class Exchange
    {
        // Operator
        public const string OperatorEvent = "operator.events";
    }

    // Tell exchange what is about
    public static class RoutingKeys
    {
        // Operator
        public const string OperatorCreated = "operator.created";
        public const string OperatorDeleted = "operator.deleted";

    }

    // Own By Who which service it belong to who consume it
    public static class Queues
    {
        public const string OpeartorCreatedQueue = "operator.created.queue";
        public const string OperatorDeletedQueue = "operator.deleted.queue";

    }

}
