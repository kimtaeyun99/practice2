using System.ComponentModel;

namespace Item_system
{
    public enum ItemType
    {
        Sword, Staff, Bow, Armor, Potion, Scroll
    }

    interface IEquippable
    {
        void Equip();
        void UnEquip();
    }

    interface ISellable
    {
        void Sell();
    }

    public abstract class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public ItemType Type { get; set; }
        public bool IsEquipped { get; set; }

        public Item(string name, int price, ItemType type)
        {
            Name = name;
            Price = price;
            Type = type;
            IsEquipped = false;
        }

        public abstract void ShowInfo();

        public virtual int ItemGeatAttkBonus() { return 0; }
        public virtual int ItemGetDefBonus() { return 0; }
        public virtual int ItemGetHpBonus() { return 0; }
        public virtual int Heal_Hp() { return 0; }
        public virtual int Heal_Mp() { return 0; }
    }

    public class Sword : Item, IEquippable, ISellable
    {
        public string Weapon_job = "전사";
        public int Atk { get; private set; }

        public Sword(string name, int atk, int price) : base(name, price, ItemType.Sword)
        {
            Atk = atk;
        }

        public override void ShowInfo()
        {
            if (Price == 0)
                Console.WriteLine($"[이름] : {Name} | [종류] : {ItemType.Sword.ToString()} | [공격력] : {Atk}");
            else
                Console.WriteLine($"[이름] : {Name} | [종류] : {ItemType.Sword.ToString()} | [공격력] : {Atk} | [가격] : {Price}Gold");
        }

        public override int ItemGeatAttkBonus() { return Atk; }

        public void Sell()
        {
            if (Price == 0) Console.WriteLine("이 아이템은 판매할 수 없습니다.");
            else Console.WriteLine("아이템을 판매했습니다.");
        }

        public void Equip() { Console.WriteLine($"{Name}을 장착했습니다. 공격력이 {Atk} 증가합니다."); }
        public void UnEquip() { Console.WriteLine($"{Name}을 해제했습니다."); }
    }

    public class Staff : Item, IEquippable, ISellable
    {
        public int Atk { get; private set; }

        public Staff(string name, int atk, int price) : base(name, price, ItemType.Staff)
        {
            Atk = atk;
        }

        public override void ShowInfo()
        {
            if (Price == 0)
                Console.WriteLine($"[이름] : {Name} | [종류] : {ItemType.Staff.ToString()} | [공격력] : {Atk}");
            else
                Console.WriteLine($"[이름] : {Name} | [종류] : {ItemType.Staff.ToString()} | [공격력] : {Atk} | [가격] : {Price}Gold");
        }

        public override int ItemGeatAttkBonus() { return Atk; }

        public void Sell()
        {
            if (Price == 0) Console.WriteLine("이 아이템은 판매할 수 없습니다.");
            else Console.WriteLine("아이템을 판매했습니다.");
        }

        public void Equip() { Console.WriteLine($"{Name}을 장착했습니다. 공격력이 {Atk} 증가합니다."); }
        public void UnEquip() { Console.WriteLine($"{Name}을 해제했습니다."); }
    }

    public class Bow : Item, IEquippable, ISellable
    {
        public int Atk { get; private set; }

        public Bow(string name, int atk, int price) : base(name, price, ItemType.Bow)
        {
            Atk = atk;
        }

        public override void ShowInfo()
        {
            if (Price == 0)
                Console.WriteLine($"[이름] : {Name} | [종류] : {ItemType.Bow.ToString()} | [공격력] : {Atk}");
            else
                Console.WriteLine($"[이름] : {Name} | [종류] : {ItemType.Bow.ToString()} | [공격력] : {Atk} | [가격] : {Price}Gold");
        }

        public override int ItemGeatAttkBonus() { return Atk; }

        public void Sell()
        {
            if (Price == 0) Console.WriteLine("이 아이템은 판매할 수 없습니다.");
            else Console.WriteLine("아이템을 판매했습니다.");
        }

        public void Equip() { Console.WriteLine($"{Name}을 장착했습니다. 공격력이 {Atk} 증가합니다."); }
        public void UnEquip() { Console.WriteLine($"{Name}을 해제했습니다."); }
    }

    public class Armor : Item, IEquippable, ISellable
    {
        public int Def { get; private set; }
        public int Hp { get; private set; }

        public Armor(string name, int def, int hp, int price) : base(name, price, ItemType.Armor)
        {
            Def = def;
            Hp = hp;
        }

        public override void ShowInfo()
        {
            if (Price == 0)
                Console.WriteLine($"[이름] : {Name} | [종류] : {ItemType.Armor.ToString()} | [방어력] : {Def} | [체력] : {Hp}");
            else
                Console.WriteLine($"[이름] : {Name} | [종류] : {ItemType.Armor.ToString()} | [방어력] : {Def} | [체력] : {Hp} | [가격] : {Price}Gold");
        }

        public override int ItemGetDefBonus() { return Def; }
        public override int ItemGetHpBonus() { return Hp; }

        public void Sell()
        {
            if (Price == 0) Console.WriteLine("이 아이템은 판매할 수 없습니다.");
            else Console.WriteLine("아이템을 판매했습니다.");
        }

        public void Equip() { Console.WriteLine($"{Name}을 장착했습니다. 방어력이 {Def} 증가합니다. 최대체력이 {Hp} 증가합니다."); }
        public void UnEquip() { Console.WriteLine($"{Name}을 해제했습니다."); }
    }

    public class Heal_Potion : Item, ISellable
    {
        public int Heal_amount = 10;

        public Heal_Potion() : base("빨간 물약", 100, ItemType.Potion) { }

        public override void ShowInfo()
        {
            Console.WriteLine($"[이름] : {Name} | [종류] : {ItemType.Potion.ToString()} | [체력 회복량] : {Heal_amount} | [가격] : {Price}Gold");
        }

        public void Sell() { Console.WriteLine("아이템을 판매했습니다."); }
    }

    public class Mana_Potion : Item, ISellable
    {
        public int Mana_amount = 3;

        public Mana_Potion() : base("파란 물약", 300, ItemType.Potion) { }

        public override void ShowInfo()
        {
            Console.WriteLine($"[이름] : {Name} | [종류] : {ItemType.Potion.ToString()} | [마나 회복량] : {Mana_amount} | [가격] : {Price}Gold");
        }

        public void Sell() { Console.WriteLine("아이템을 판매했습니다."); }
    }

    public class Heal_Scroll : Item, ISellable
    {
        public int Heal_amount = 30;

        public Heal_Scroll() : base("체력회복 주문서", 0, ItemType.Scroll) { }

        public override void ShowInfo()
        {
            Console.WriteLine($"[이름] : {Name} | [종류] : {ItemType.Scroll.ToString()} | [체력 회복량] : {Heal_amount}");
        }

        public void Sell() { Console.WriteLine("이 아이템은 판매할 수 없습니다."); }
    }

    public class Mana_scroll : Item, ISellable
    {
        public int Mana_amount = 10;

        public Mana_scroll() : base("마나회복 주문서", 0, ItemType.Scroll) { }

        public override void ShowInfo()
        {
            Console.WriteLine($"[이름] : {Name} | [종류] : {ItemType.Scroll.ToString()} | [마나 회복량] : {Mana_amount}");
        }

        public void Sell() { Console.WriteLine("이 아이템은 판매할 수 없습니다."); }
    }
    public class Mystery_potion : Item, ISellable
    {
        public int Mystery_potion_probability { get; set; }
        public int Heal_amount { get; set; }
        public int Mana_amount { get; set; }
        public Mystery_potion() : base("수상한 물약", 150, ItemType.Potion)
        {
            Random rand = new Random();
            int mystery_potion_probability = rand.Next(0, 99);
            Mystery_potion_probability = mystery_potion_probability;
            if(Mystery_potion_probability > 30)
            {
                Heal_amount = 0;
                Mana_amount = 0;
            }
            else if(Mystery_potion_probability <= 30 && Mystery_potion_probability >10)
            {
                int heal_amount = rand.Next(-10, 30);
                Heal_amount = heal_amount;
            }
            else if(Mystery_potion_probability <= 10 && Mystery_potion_probability >0)
            {
                int mana_amount = rand.Next(-5, 10);
                Mana_amount = mana_amount;
            }
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"[이름] : {Name} | [종류] : {ItemType.Potion.ToString()} | [가격] : {Price}Gold");
            Console.WriteLine("이상한 액체가 담긴 수상한 물약... 마시면 랜덤한 효과가 발동된다!");
        }
        public void Sell()
        {
            Console.WriteLine("아이템을 판매했습니다.");
        }


    }
}
