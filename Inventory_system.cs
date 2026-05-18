using Character_system;
using Item_system;

namespace Inventory_system
{
    public class Inventory
    {
        public void ShowInventory(Character_system.Character character)
        {
            Console.WriteLine("===== 인벤토리 =====");
            Console.WriteLine("");
            Console.WriteLine($"현재 보유 골드 : {character.Gold} Gold");
            Console.WriteLine("");
            for (int i = 0; i < character.inventory.Count; i++)
            {
                if (character.inventory[i] != null)
                {
                    if (character.inventory[i].IsEquipped)
                    {
                        Console.Write($"{i + 1}. (E) {character.inventory[i].Name}");
                    }
                    else
                    {
                        Console.Write($"{i + 1}. {character.inventory[i].Name}");
                    }
                }
                else
                {
                    Console.Write($"{i + 1}. [빈칸]");
                }
                if ((i + 1) % 5 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine("");
        }
        public void InventoryEquip(Character character)
        {
            Console.WriteLine("장착할 아이템을 선택해 주세요.");
            string input = Console.ReadLine();
            int choice;
            if (int.TryParse(input, out choice))
            {
                if (character.Weapon_able == ItemType.Sword.ToString())
                {
                    
                }
            }
            else
            {
                Console.WriteLine("숫자를 입력해주세요.");
            }
        }

        public int GetEmptySlot(Character character)
        {
            for(int i=0; i<character.inventory.Count; i++)
            {
                if (character.inventory[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}

