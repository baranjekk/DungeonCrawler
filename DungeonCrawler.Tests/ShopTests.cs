using DungeonCrawler.Core.Characters;
using DungeonCrawler.Core.Items;
using DungeonCrawler.Core.ShopLogic;

namespace DungeonCrawler.Tests
{
    public class ShopTests
    {
        [Fact]
        public void Shop_BuyItemDeductsGold()
        {
            Player player = new Player("TestPlayer");
            Shop shop = new Shop();

            Potion potion = new Potion(
                "Health Potion",
                "Restores 30 HP.",
                30,
                ItemRarity.Common,
                20);

            shop.AddItem(potion);

            bool result = shop.BuyItem(player, 0);

            Assert.True(result);
            Assert.Equal(80, player.Gold);
        }

        [Fact]
        public void Shop_BuyItemAddsItemToInventory()
        {
            Player player = new Player("TestPlayer");
            Shop shop = new Shop();

            Potion potion = new Potion(
                "Health Potion",
                "Restores 30 HP.",
                30,
                ItemRarity.Common,
                20);

            shop.AddItem(potion);

            shop.BuyItem(player, 0);

            Assert.Contains(potion, player.Inventory.Items);
        }

        [Fact]
        public void Shop_BuyItemRemovesItemFromShop()
        {
            Player player = new Player("TestPlayer");
            Shop shop = new Shop();

            Potion potion = new Potion(
                "Health Potion",
                "Restores 30 HP.",
                30,
                ItemRarity.Common,
                20);

            shop.AddItem(potion);

            shop.BuyItem(player, 0);

            Assert.Equal(0, shop.GetItemCount());
        }

        [Fact]
        public void Shop_CannotBuyItemWithoutEnoughGold()
        {
            Player player = new Player("TestPlayer");
            Shop shop = new Shop();

            Weapon weapon = new Weapon(
                "Expensive Sword",
                "Very expensive sword.",
                50,
                ItemRarity.Rare,
                150);

            shop.AddItem(weapon);

            bool result = shop.BuyItem(player, 0);

            Assert.False(result);
            Assert.Equal(100, player.Gold);
            Assert.Empty(player.Inventory.Items);
            Assert.Equal(1, shop.GetItemCount());
        }

        [Fact]
        public void Shop_SellItemGivesHalfPrice()
        {
            Player player = new Player("TestPlayer");
            Shop shop = new Shop();

            Weapon weapon = new Weapon(
                "Iron Sword",
                "A simple sword.",
                10,
                ItemRarity.Common,
                60);

            player.Inventory.AddItem(weapon);

            bool result = shop.SellItem(player, 0);

            Assert.True(result);
            Assert.Equal(130, player.Gold);
        }

        [Fact]
        public void Shop_SellItemRemovesItemFromInventory()
        {
            Player player = new Player("TestPlayer");
            Shop shop = new Shop();

            Weapon weapon = new Weapon(
                "Iron Sword",
                "A simple sword.",
                10,
                ItemRarity.Common,
                60);

            player.Inventory.AddItem(weapon);

            shop.SellItem(player, 0);

            Assert.Empty(player.Inventory.Items);
        }

        [Fact]
        public void Shop_CannotSellInvalidItemIndex()
        {
            Player player = new Player("TestPlayer");
            Shop shop = new Shop();

            bool result = shop.SellItem(player, 0);

            Assert.False(result);
            Assert.Equal(100, player.Gold);
        }
    }
}