using Character_system;
using Item_system;
using Shop_system;

namespace Console_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //상점테스트용 코드
            //Warrior player = new Warrior("전사");
            //Mage player1 = new Mage("마법사");
            //Archer player2 = new Archer("궁수");
            //player.Gold = 5000;
            //player1.Gold = 5000;
            //player2.Gold = 5000;

            //Shop shop = new Shop();

            //shop.Shop_Run(player1);
            //player1.ShowStatus();

            Mystery_potion mystery_Potion = new Mystery_potion();
            Console.WriteLine($"{mystery_Potion.Mystery_potion_probability}, {mystery_Potion.Heal_amount}, {mystery_Potion.Mana_amount}");
        }
    }
}
