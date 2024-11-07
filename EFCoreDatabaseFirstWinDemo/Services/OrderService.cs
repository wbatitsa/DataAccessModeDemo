using Dapper;
using EFCoreDatabaseFirstWinDemo.Data;
using EFCoreDatabaseFirstWinDemo.Models;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDatabaseFirstWinDemo.Services
{
    public class OrderService : IOrderService
    {
        private readonly NorthwindDbConext _northwindDbConext;

        public OrderService(NorthwindDbConext northwindDbConext)
        {
            _northwindDbConext = northwindDbConext;
        }

        public void SaveOrder(Order order)
        {
            _northwindDbConext.Orders.Add(order);
            _northwindDbConext.SaveChanges();
        }
    }

    public class SqlKataOrderService : IOrderService
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public SqlKataOrderService(ISqlConnectionFactory sqlConnectionFactory)
        {
            this._sqlConnectionFactory = sqlConnectionFactory;
        }

        public void SaveOrder(Order order)
        {
            var connection = _sqlConnectionFactory.GetNewSqlConnection();
            var compiler = new SqlServerCompiler();
            var queryFactory = new QueryFactory(connection, compiler);

            connection.Open();

            var transaction = connection.BeginTransaction();

            try
            {
                order.OrderId = queryFactory.Query("Orders").InsertGetId<int>(new
                {
                    order.EmployeeId,
                    order.CustomerId,
                    order.OrderDate,
                    order.RequiredDate
                }, transaction);


                foreach (var item in order.OrderDetails)
                {
                    queryFactory.Query("Order Details").Insert(new
                    {
                        order.OrderId,
                        item.Product.ProductId,
                        item.Product.UnitPrice,
                        item.Quantity
                    }, transaction);
                }

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }


    public class DapperOrderService : IOrderService
    {

        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public DapperOrderService(ISqlConnectionFactory sqlConnectionFactory)
        {
            this._sqlConnectionFactory = sqlConnectionFactory;

        }
        public void SaveOrder(Order order)
        {
            var connection = _sqlConnectionFactory.GetNewSqlConnection();

            connection.Open();

            var transaction = connection.BeginTransaction();

            try
            {
               order.OrderId =  connection.ExecuteScalar<int>(@"
                    INSERT Orders (EmployeeId, CustomerId, OrderDate, RequiredDate) 
                    VALUES (@EmployeeId, @CustomerId, @OrderDate, @RequiredDate); SELECT SCOPE_IDENTITY()
                ", new
                {
                    order.EmployeeId,
                    order.CustomerId,
                    order.OrderDate,
                    order.RequiredDate
                }, transaction);

                foreach (var item in order.OrderDetails)
                {

                    connection.Execute(@"
                        INSERT [Order Details](OrderId, ProductId, UnitPrice, Quantity)
                        VALUES (@OrderId, @ProductId, @UnitPrice, @Quantity)
                    ", new
                    {
                        order.OrderId,
                        item.Product.ProductId,
                        item.Product.UnitPrice,
                        item.Quantity
                    }, transaction);

                }

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                connection.Close();
            }

        }
    }


    public class AdoNetOrderService : IOrderService
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public AdoNetOrderService(ISqlConnectionFactory sqlConnectionFactory)
        {
            this._sqlConnectionFactory = sqlConnectionFactory;
        }

        public void SaveOrder(Order order)
        {
            var connection = _sqlConnectionFactory.GetNewSqlConnection();

            connection.Open();

            var transaction = connection.BeginTransaction();
            
            try
            {
                var insertOrderCommand = connection.CreateCommand();
                insertOrderCommand.Transaction = transaction;
                insertOrderCommand.CommandText = @"
                    INSERT Orders (EmployeeId, CustomerId, OrderDate, RequiredDate) 
                    VALUES (@EmployeeId, @CustomerId, @OrderDate, @RequiredDate); SELECT SCOPE_IDENTITY()";

                insertOrderCommand.Parameters.AddWithValue("@EmployeeId", order.EmployeeId);
                insertOrderCommand.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                insertOrderCommand.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                insertOrderCommand.Parameters.AddWithValue("@RequiredDate", order.RequiredDate);

                //order.OrderId = (int)(decimal)insertOrderCommand.ExecuteScalar();
                order.OrderId = Convert.ToInt32(insertOrderCommand.ExecuteScalar());

                foreach (var item in order.OrderDetails)
                {
                    var inserDetailCommand = connection.CreateCommand();
                    inserDetailCommand.Transaction = transaction;
                    inserDetailCommand.CommandText = @"
                        INSERT [Order Details](OrderId, ProductId, UnitPrice, Quantity)
                        VALUES (@OrderId, @ProductId, @UnitPrice, @Quantity)
                    ";
                    inserDetailCommand.Parameters.AddWithValue("@OrderId", order.OrderId );
                    inserDetailCommand.Parameters.AddWithValue("@ProductId", item.Product.ProductId);
                    inserDetailCommand.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                    inserDetailCommand.Parameters.AddWithValue("@Quantity", item.Quantity);

                    inserDetailCommand.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally { 
                connection.Close();
            }
            
        }
    }
}
