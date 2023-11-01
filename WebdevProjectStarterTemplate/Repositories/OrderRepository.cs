using Dapper;
using System.Data;
using WebdevProjectStarterTemplate.Models;

namespace WebdevProjectStarterTemplate.Repositories
{
    public class OrderRepository
    {
    private IDbConnection GetConnection()
        {
            return new DbUtils().GetDbConnection();
        }
        
        public IEnumerable<Order> Get(int TableID) //Alle bestellingen van 1 tafel ophalen
        {
            string sql = "SELECT * FROM tableOrder WHERE TableID = @TableID ORDER BY Name ASC";

            using var connection = GetConnection();
            var order = connection.Query<Order>(sql, new { TableID });
            return order;
        }
        public IEnumerable<Order> GetAllOrders() // alle bestellingen ophalen
        {
            string sql = "Select * From tableOrder Order By TableID ASC";

            using var connection = GetConnection();
            var order = connection.Query<Order>(sql);
            return order;
        }

        public void AddToOrder(int TableID, int ProductID, int Amount) //voeg 1 product toe aan de bestelling
        {
            string sql = "Insert INTO webdevproject.tableOrder Select @ProductID, Name, Price, @TableID, @Amount, 0, 0 FROM Product WHERE ProductID = @ProductID ON DUPLICATE KEY UPDATE Amount = Amount + 1";

            using var connection = GetConnection();
            connection.Execute(sql, new { TableID, ProductID, Amount });
        }

        public void RemoveFromOrder(int TableID, int ProductID) // verwijder alles van 1 product van de bestelling
        {
            string sql = "DELETE FROM webdevproject.tableorder WHERE TableID = @TableID AND ProductID = @ProductID";

            using var connection = GetConnection();
            connection.Execute(sql, new { TableID, ProductID});
        }

        public void RemoveOneFromOrder(int TableID, int ProductID, int Amount) //verwijder 1 product van de bestelling
        {
            string sql;
            if(Amount > 1)
            {
                sql = "UPDATE webdevproject.tableorder SET Amount = Amount-1 WHERE TableID = @TableID AND ProductID = @ProductID AND Amount > AmountPaid";
            }
            else
            {
               sql = "DELETE FROM webdevproject.tableorder WHERE TableID = @TableID AND ProductID = @ProductID AND Amount > AmountPaid";
            }
            using var connection = GetConnection();
            connection.Execute(sql, new { TableID, ProductID, Amount });
        }

        public void AllesBetalen(int TableID) //Geen comment nodig volgens mij
        {
            string sql = "Update tableorder SET AmountPaid = Amount Where TableID = @TableID";

            using var connection = GetConnection();
            connection.Execute(sql, new { TableID });
        }

        public void DeelsBetalen(int TableID) //Hier ook niet
        {
            string sql = "Update tableOrder SET AmountPaid = AmountPaid + AmountWantsToPay Where TableID = @TableID AND AmountWantsToPay <= Amount - AmountPaid";
            using var connection = GetConnection();
            connection.Execute(sql, new { TableID });
        }

        public void Add1ToPay(int TableID, int ProductID, int AmountWantsToPay) //Product toevoegen die je wilt betalen
        {
            string sql = "Update tableOrder Set AmountWantsToPay = AmountWantsToPay+1 WHERE TableID = @TableID AND ProductID = @ProductID AND AmountWantsToPay < Amount - AmountPaid";

            using var connection = GetConnection();
            connection.Execute(sql, new { TableID, ProductID, AmountWantsToPay });
        }
        public void Remove1ToPay(int TableID, int ProductID, int AmountWantsToPay) //Product verwijderen die je niet wilt betalen
        {
                string sql = "Update tableOrder Set AmountWantsToPay = AmountWantsToPay-1 WHERE TableID = @TableID AND ProductID = @ProductID AND AmountWantsToPay > 0";

                using var connection = GetConnection();
                connection.Execute(sql, new { TableID, ProductID, AmountWantsToPay });
            }

        }
    }






