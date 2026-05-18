using Console_Game;
using Item_system;

namespace Character_system
{
    public class Character
    {
        public string Name { get; set; }
        public string Job_name { get; set; }
        public string Weapon_able { get; set; }
        public int Level { get; set; }
        public int EXP { get; set; }

        public int HP { get; set; }
        public int Default_HP { get; set; }
        public int Bonust_HP { get; set; }
        public int MP { get; set; }
        public int Default_MP { get; set; }
        public int Atk { get; set; }
        public int Default_Atk { get; set; }
        public int Bonust_Atk { get; set; }
        public int Def { get; set; }
        public int Default_Def { get; set; }
        public int Bonust_Def { get; set; }
        public int Levelbonus { get; set; }

        public List<Item> inventory = new List<Item>(15);

        public Character(string name)
        {
            Name = name;
            Levelbonus = (Level - 1) * 5;

            for (int i = 0; i < 15; i++)
            {
                inventory.Add(null);
            }
        }
        private int gold;
        public int Gold
        {
            get => gold;
            set => gold = value < 0 ? 0 : value;
        }
        public void Levelup()
        {
            if (EXP >= 100)
            {
                EXP = 0;
                Level++;
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine("===== 캐릭터 정보 =====");
            Console.WriteLine($"닉네임 : {Name}");
            Console.WriteLine($"직업 : {Job_name}");
            Console.WriteLine($"레벨 : {Level}");
            Console.WriteLine($"경험치 : {EXP}");
            Console.WriteLine($"최대 체력 : {HP} ({Default_HP} + {Bonust_HP} + {Levelbonus})");
            Console.WriteLine($"최대 마나 : {MP}");
            Console.WriteLine($"공격력 : {Atk} ({Default_Atk} + {Bonust_Atk} + {Levelbonus})");
            Console.WriteLine($"방어력 : {Def} ({Default_Def} + {Bonust_Def})");
            Console.WriteLine($"GOLD : {Gold}");
        }
    }

    public class Warrior : Character
    {
        public Warrior(string name) : base(name)
        {
            Job_name = "전사";
            Level = 1;
            EXP = 0;
            Default_HP = 100;
            Default_MP = 10;
            Default_Atk = 10;
            Default_Def = 50;

            HP = Default_HP;
            MP = Default_MP;
            Atk = Default_Atk;
            Def = Default_Def;

            Gold = 0;
            Levelbonus = 0;
            Weapon_able = "Sword";
        }
    }

    public class Mage : Character
    {
        public Mage(string name) : base(name)
        {
            Job_name = "마법사";
            Level = 1;
            EXP = 0;
            Default_HP = 70;
            Default_MP = 20;
            Default_Atk = 10;
            Default_Def = 20;

            HP = Default_HP;
            MP = Default_MP;
            Atk = Default_Atk;
            Def = Default_Def;

            Gold = 0;
            Levelbonus = 0;
            Weapon_able = "Staff";
        }
    }
    public class Archer : Character
    {
        public Archer(string name) : base(name)
        {
            Job_name = "궁수";
            Level = 1;
            EXP = 0;
            Default_HP = 70;
            Default_MP = 15;
            Default_Atk = 10;
            Default_Def = 30;

            HP = Default_HP;
            MP = Default_MP;
            Atk = Default_Atk;
            Def = Default_Def;

            Gold = 0;
            Levelbonus = 0;
            Weapon_able = "Bow";
        }
    }
}
