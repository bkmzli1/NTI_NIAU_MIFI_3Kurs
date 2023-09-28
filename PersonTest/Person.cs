using System;

namespace PersonTest
{
    public class Person
    {
        public enum Statys
        {
            Ребёнок,
            Школьник,
            Студент,
            Работник,
            Пенсионер
        }

        private string fam = "", health = "";
        private int age = 0, salary = 0, countChildren;
        private const int childrenMax = 20;
        private Person[] children = new Person[childrenMax];
        private Statys staty = Statys.Работник;


        public string Fam
        {
            get => fam;
            set => fam = value;
        }

        public string Health
        {
            get => health;
            set => health = value;
        }

        public int Age
        {
            get => age;
            set
            {
                age = value;
                staty = age switch
                {
                    < 7 => Statys.Работник,
                    < 17 => Statys.Школьник,
                    < 22 => Statys.Студент,
                    < 65 => Statys.Работник,
                    _ => Statys.Пенсионер
                };
            }
        }

        public int Salary
        {
            get => salary;
            set => salary = value;
        }

        public Statys Staty
        {
            get => staty;
            set => staty = value;
        }

        public void TestPersonProps()
        {
            Person person1 = new Person(), person2 = new Person();
            person1.Fam = "Пуфыстик";
            person1.Age = 21;
            ConsolPrintPrson(person1);
            person2.Fam = "Lord11";
            person2.Age = person1.Age + 1;
            ConsolPrintPrson(person2);
        }

        void ConsolPrintPrson(Person prs)
        {
            Console.WriteLine("Фамилия {0}, возраст = {1},Статус = {2}", prs.Fam, prs.Age, Staty);
        }

        public Person this[int i]
        {
            get
            {
                if (i >= 0 && i < countChildren)
                {
                    return (children[i]);
                }
                else
                {
                    return children[0];
                }
            }
        }
    }
}