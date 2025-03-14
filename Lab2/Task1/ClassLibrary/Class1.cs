using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface ISubscription
    {
        decimal GetMonthlyFee();
        int GetMinPeriod();
        string[] GetChannels();
    }
    public class DomesticSubscription : ISubscription
    {
        public decimal GetMonthlyFee() => 8m;
        public int GetMinPeriod() => 1;
        public string[] GetChannels() => new[] { "News", "Movies", "Sports" };
    }
    public class EducationalSubscription : ISubscription
    {
        public decimal GetMonthlyFee() => 10m;
        public int GetMinPeriod() => 6;
        public string[] GetChannels() => new[] { "Documentaries", "Science", "Kids" };
    }
    public class PremiumSubscription : ISubscription
    {
        public decimal GetMonthlyFee() => 20m;
        public int GetMinPeriod() => 12;
        public string[] GetChannels() => new[] { "All Channels", "4K Movies", "Exclusive Sports" };
    }
    public interface ISubscriptionCreator
    {
        ISubscription CreateSubscription();
    }
    public class WebSite : ISubscriptionCreator
    {
        public ISubscription CreateSubscription()
        {
            return new DomesticSubscription();
        }
    }
    public class MobileApp : ISubscriptionCreator
    {
        public ISubscription CreateSubscription()
        {
            return new EducationalSubscription();
        }
    }
    public class ManagerCall : ISubscriptionCreator
    {
        public ISubscription CreateSubscription()
        {
            return new PremiumSubscription();
        }
    }
}