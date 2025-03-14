using System;
using System.Text;
using ClassLibrary;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        ISubscriptionCreator[] creators = { new WebSite(), new MobileApp(), new ManagerCall() };
        string[] sources = { "Веб-сайт", "Мобільний додаток", "Дзвінок менеджера" };
        for (int i = 0; i < creators.Length; i++)
        {
            Console.WriteLine($"Підписка через {sources[i]}:");
            ISubscription subscription = creators[i].CreateSubscription();
            PrintSubscription(subscription);
            Console.WriteLine();
        }
    }
    static void PrintSubscription(ISubscription subscription)
    {
        string subscriptionType = subscription switch
        {
            DomesticSubscription => "Домашня підписка",
            EducationalSubscription => "Освітня підписка",
            PremiumSubscription => "Преміум підписка",
            _ => "Невідомий тип підписки"
        };
        Console.WriteLine($"Тип підписки: {subscriptionType}");
        Console.WriteLine($"- Щомісячна плата: {subscription.GetMonthlyFee()}$");
        Console.WriteLine($"- Мінімальний період: {subscription.GetMinPeriod()} місяців");
        Console.WriteLine($"- Канали: {string.Join(", ", subscription.GetChannels())}\n");
    }
}