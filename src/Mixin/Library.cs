using System;
using System.Runtime.CompilerServices;

public interface MAgeProvider
{

}

public static class AgeProvider
{
    static ConditionalWeakTable<MAgeProvider, Fields> table;

    private sealed class Fields
    {
        internal DateTime BirthDate = DateTime.UtcNow;
    }

    static AgeProvider()
    {
        table = new ConditionalWeakTable<MAgeProvider, Fields>();
    }

    public static int GetAge(this MAgeProvider map)
    {
        DateTime dtNow = DateTime.UtcNow;
        DateTime dtBorn = table.GetOrCreateValue(map).BirthDate;
        int age = ((dtNow.Year - dtBorn.Year) * 372
                   + (dtNow.Month - dtBorn.Month) * 31
                   + (dtNow.Day - dtBorn.Day)) / 372;
        return age;
    }
    public static void SetBirthDate(this MAgeProvider mAgeProvider, DateTime birthDate)
    {
        table.GetOrCreateValue(mAgeProvider).BirthDate = birthDate;
    }

    public abstract class Animal
    {

    }

    public class Human : Animal, MAgeProvider
    {
        public string Name;
        public Human(string name)
        {
            Name = name;
        }
    }
}
