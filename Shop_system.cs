using Item_system;
using Inventory_system;

namespace Shop_system
{
    public class Shop
    {
        public void Shop_Run(Character_system.Character character)
        {
            Gear_Shop gear_shop = new Gear_Shop();
            Expendable_Shop expendable_Shop = new Expendable_Shop();

            while (true)
            {
                Console.Clear();
                Shop_info();
                string input_shop_menu = Console.ReadLine();
                int shop_menu;

                if (int.TryParse(input_shop_menu, out shop_menu))
                {
                    switch (shop_menu)
                    {
                        case 1:
                            Console.Clear();
                            gear_shop.Buyitem(character, null);
                            break;
                        case 2:
                            Console.Clear();
                            expendable_Shop.Buyitem(character, null); 
                            break;
                        case 3:
                            Console.Clear();
                            SellItem(character, 0);
                            break;
                        case 4:
                            Console.Clear();
                            Inventory inventory = new Inventory();
                            inventory.ShowInventory(character);
                            Console.ReadKey(true);
                            break;
                        case 0:
                            Console.WriteLine("상점을 나갑니다.");
                            Console.ReadKey(true);
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("잘못된 번호입니다.");
                            Console.ReadKey(true);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    continue;
                }
            }
        }

        public virtual void ShowShop()
        {
            Console.WriteLine("기본 상점입니다.");
        }

        public virtual void Buyitem(Character_system.Character character, Item item)
        {
            Console.WriteLine("기본 구매 로직입니다.");
        }

        public void Shop_info()
        {
            Console.WriteLine("===== 상점 =====");
            Console.WriteLine("1. 장비상점");
            Console.WriteLine("2. 소모품상점");
            Console.WriteLine("3. 아이템 판매");
            Console.WriteLine("4. 인벤토리 목록");
            Console.WriteLine("0. 돌아가기");
            Console.WriteLine("================");
        }
        public void BuyItem_system(Character_system.Character character, Item item)
        {
            Inventory inventory = new Inventory();
            int slot = inventory.GetEmptySlot(character);

            if (slot == -1)
            {
                Console.WriteLine("인벤토리가 가득 찼습니다.");
                Console.ReadKey(true);
                return;
            }
            if (character.Gold < item.Price)
            {
                Console.WriteLine("골드가 부족합니다.");
                Console.ReadKey(true);
                return;
            }

            character.Gold -= item.Price;
            character.inventory[slot] = item;
            Console.WriteLine($"{item.Name} 구매하였습니다.");
            Console.WriteLine($"구매골드 : {item.Price} | 현재 소지 골드 : {character.Gold}");
            Console.ReadKey(true);
        }
        public void SellItem_system(Character_system.Character character, int slot)
        {
            Inventory inventory = new Inventory();

            if (slot < 0 || slot >= character.inventory.Count)
            {
                Console.WriteLine("잘못된 번호입니다.");
                Console.ReadKey(true);
                return;
            }

            Item item = character.inventory[slot];
            if (item == null)
            {
                Console.WriteLine("해당 슬롯에 아이템이 없습니다.");
                Console.ReadKey(true);
                return;
            }
            if (item.Price == 0)
            {
                Console.WriteLine($"{item.Name}은(는) 판매할 수 없습니다.");
                Console.ReadKey(true);
                return;
            }

            int sellprice = item.Price / 2;
            character.Gold += sellprice;
            character.inventory[slot] = null;

            Console.WriteLine($"{item.Name}을(를) 판매했습니다.");
            Console.WriteLine($"판매 골드 : {sellprice} | 현재 소지 골드 : {character.Gold}");
            Console.ReadKey(true);
        }
        public void SellItem(Character_system.Character character, int slot)
        {
            Inventory inventory = new Inventory();
            inventory.ShowInventory(character);

            Console.WriteLine("판매할 아이템 슬롯 번호를 입력하세요:");
            string input = Console.ReadLine();
            int choice;

            if (int.TryParse(input, out choice))
            {
                if (choice > 0 || choice < 11)
                {
                    int slotIndex = choice - 1;
                    SellItem_system(character, slotIndex);
                }
            }
            else
            {
                Console.WriteLine("숫자를 입력해주세요.");
            }
        }
    }

    public class Gear_Shop : Shop
    {
        private Item[] Gear_Shop_item =
        {
            new Sword("강철의 검", 15, 1000),
            new Staff("강철의 스태프", 15, 1000),
            new Bow("강철의 활", 15, 1000),
            new Armor("강철의 갑옷", 15, 15, 1000),
            new Sword("마법의 검", 30, 5000),
            new Staff("마법의 스태프", 30, 5000),
            new Bow("마법의 활", 30, 5000),
            new Armor("마법의 갑옷", 30, 30, 5000),            
        };

        public override void ShowShop()
        {
            Console.WriteLine("===== 장비 상점 =====");
            for (int i = 0; i < Gear_Shop_item.Length; i++)
            {
                Console.Write($"{i + 1}. ");
                Gear_Shop_item[i].ShowInfo();
                Console.WriteLine("");
            }
            Console.WriteLine("================");
        }

        public override void Buyitem(Character_system.Character character, Item item)
        {
            Inventory inventory = new Inventory();
            inventory.ShowInventory(character);
            ShowShop();

            Console.WriteLine("구매할 아이템 번호를 입력하세요:");
            string input = Console.ReadLine();
            int choice;

            if (int.TryParse(input, out choice))
            {
                if (choice > 0 && choice <= Gear_Shop_item.Length)
                {
                    Item selectedItem = Gear_Shop_item[choice - 1];
                    BuyItem_system(character, selectedItem);
                }
                else if (choice > Gear_Shop_item.Length)
                {
                    Console.WriteLine("잘못된 번호입니다.");
                    Console.ReadKey(true);
                    return;
                }
                else
                {
                    Console.WriteLine("잘못된 번호입니다.");
                    Console.ReadKey(true);
                }
            }
            else
            {
                Console.WriteLine("숫자를 입력해주세요.");
                Console.ReadKey(true);
            }
        }
    }

    public class Expendable_Shop : Shop
    {
        private Item[] Expendable_Shop_item =
        {
            new Heal_Potion(),
            new Mana_Potion(),
            new Mystery_potion()
        };

        public override void ShowShop()
        {
            Console.WriteLine("===== 소모품 상점 =====");
            for (int i = 0; i < Expendable_Shop_item.Length; i++)
            {
                Console.Write($"{i + 1}. ");
                Expendable_Shop_item[i].ShowInfo();
                Console.WriteLine("");
            }
            Console.WriteLine("================");
        }

        public override void Buyitem(Character_system.Character character, Item item)
        {
            Inventory inventory = new Inventory();
            inventory.ShowInventory(character);
            ShowShop();

            Console.WriteLine("구매할 아이템 번호를 입력하세요:");
            string input = Console.ReadLine();
            int choice;

            if (int.TryParse(input, out choice))
            {
                if (choice > 0 && choice <= Expendable_Shop_item.Length)
                {
                    Item selectedItem = Expendable_Shop_item[choice - 1];
                    BuyItem_system(character, selectedItem);
                }
                else
                {
                    Console.WriteLine("잘못된 번호입니다.");
                    Console.ReadKey(true);
                }
            }
            else
            {
                Console.WriteLine("숫자를 입력해주세요.");
                Console.ReadKey(true);
            }
        }
    }
}
