using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp27
{
    enum Gender { Male, Female };
    internal class FamilyMember
    {
        public FamilyMember Mother { get { return mother; } set { mother = value; } }
        public FamilyMember Father { get { return father; } set { father = value; } }
        public string Name { get { return name; } set { name = value; } }
        public Gender Sex { get { return sex; } set { sex = value; } }
        public ListT<FamilyMember> Children { get; }



        FamilyMember mother;
        FamilyMember father;
        string name;
        Gender sex;
        ListT<FamilyMember> children;

        public void MothersLine()
        {
            if (sex == Gender.Female)
                Console.WriteLine(name);
            MothersLinePrivate();
        }
        private void MothersLinePrivate()
        {
            if (mother != null)
            {
                Console.WriteLine(mother.name);
                mother.MothersLinePrivate();
            }
        }

        public void PrintRelatives()
        {
            Console.WriteLine($"Отец: {this.father?.name ?? "Отсутствует"}, Мать: {this.mother?.name ?? "Отсутствует"}");
            Console.Write($"Я: {name ?? "Отсутствует"}, ");

            Console.Write("Супруги: ");
            var spouseList = new List<FamilyMember>();
            foreach (var child in children)
            {
                if (child.mother != null && child.mother.sex != this.sex && !spouseList.Contains(child.mother))
                {
                    spouseList.Add(child.mother);
                }
                if (child.father != null && child.father?.sex != this.sex && !spouseList.Contains(child.father))
                {
                    spouseList.Add(child.father);
                }
            }
            foreach (var spouse in spouseList)
            {
                Console.Write(spouse.name + " ");
            }
            Console.WriteLine();

            Console.Write("Братья/Сестры: ");

            var brosList = new List<FamilyMember>();
            if(mother != null)
            {
                foreach (var child in mother?.children ?? null)
                {
                    if (child != this && !brosList.Contains(child))
                    {
                        brosList.Add(child);
                        Console.Write(child.name);
                    }
                }
            }
            if(father != null)
            {
                foreach (var child in father.children)
                {
                    if (child != this && !brosList.Contains(child))
                    {
                        brosList.Add(child);
                        Console.Write(child.name);
                    }
                }
            }
            Console.WriteLine();
            Console.Write("Дети: ");
            foreach(var child in children)
            {
                Console.Write(child.name + " ");
            }
            
        }

        public void AddChild(FamilyMember child)
        {
            if (child != null)
                children.Add(child);
        }

        public FamilyMember()
        {
            children = new ListT<FamilyMember>();
        }

        public FamilyMember(FamilyMember Mother, FamilyMember Father, string Name, Gender Sex)
        {
            children = new ListT<FamilyMember>();
            this.mother = Mother;
            this.father = Father;
            this.name = Name;
            this.sex = Sex;
        }
    }

}