namespace ClinicManager.Domain.Entities.SubscriptionAggregate
{
    public class SubscriptionCartEntity : EntityBase
    {
        public SubscriptionCartEntity()
        {}

        public SubscriptionCartEntity(SubscriptionEntity subscription, string cartEntryName, int amount)
        {
            _subscriptionId = subscription.Id;
            _cartEntryName  = cartEntryName;
            _amount         = amount;
        }
        public void Set(SubscriptionEntity subscription, string cartEntryName, int amount)
        {
            _subscriptionId = subscription.Id;
            _cartEntryName  = cartEntryName;
            _amount         = amount;
        }

        private string _cartEntryName;
        public string CartEntryName => _cartEntryName;

        private int _amount;
        public int Amount => _amount;

        public SubscriptionEntity Subscription { get; set; }
        public int SubscriptionId => _subscriptionId;
        private int _subscriptionId;

    }
}
