using myAPI.Models;
using MySql.Data.MySqlClient;

public class OrderRepository
{
    private readonly string _connectionString;

    public OrderRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public List<Order> GetOrders()
    {
        List<Order> orders = new List<Order>();
        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            using (MySqlCommand command = new MySqlCommand("SELECT id, Contract, PPLot, current_status, sequence FROM wip_view",connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new Order
                        {
                            OrderID = reader.GetInt64(0),
                            Contract = reader.GetString(1),
                            PPLot = reader.GetString(2),
                            CurrentStatus = reader.GetBoolean(3),
                            Sequence = reader.GetInt32(4),
                        });
                    }
                }
            }
        }

            
        return orders;
    }
    public Order GetOrders(long id)
    {
        Order order = new Order();
        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            using (MySqlCommand command = new MySqlCommand($"SELECT id, Contract, PPLot, current_status, sequence FROM wip_view where id = {id}", connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {

                        order.OrderID = reader.GetInt64(0);
                        order.Contract = reader.GetString(1);
                        order.PPLot = reader.GetString(2);
                        order.CurrentStatus = reader.GetBoolean(3);
                        order.Sequence = reader.GetInt32(4);
                        
                    }
                }
            }
        }


        return order;
    }
}
