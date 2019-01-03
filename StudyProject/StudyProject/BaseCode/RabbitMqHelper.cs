using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RabbitMQ.Client;
using System.Text;
namespace StudyProject
{
    public class RabbitMqHelper
    {
        ///// <summary>
        ///// 新增项
        ///// </summary>
        ///// <param name="exchange">交换机名</param>
        ///// <param name="queueName">队列名</param>
        ///// <param name="value">新增值</param>
        ///// <param name="durable">是否持久化</param>
        ///// <returns></returns>
        //public static bool Add(string exchange, string queueName,string value,bool durable=false)
        //{
        //    var factory = new ConnectionFactory() { HostName = "127.0.0.1", Port = 5672, UserName = "guest", Password = "guest" };
        //    using (var connection = factory.CreateConnection())
        //    using (var channel = connection.CreateModel())
        //    {
        //        try
        //        {
        //            //声明queue
        //            channel.QueueDeclare(queue: queueName,//队列名
        //                                 durable: durable,//是否持久化
        //                                 exclusive: false,//true:排他性，该队列仅对首次申明它的连接可见，并在连接断开时自动删除
        //                                 autoDelete: false,//true:如果该队列没有任何订阅的消费者的话，该队列会被自动删除
        //                                 arguments: null);//如果安装了队列优先级插件则可以设置优先级
        //            var body = Encoding.UTF8.GetBytes(value);

        //            channel.BasicPublish(exchange: exchange,//exchange名称
        //                                 routingKey: "hello",//如果存在exchange,则消息被发送到名称为hello的queue的客户端
        //                                 basicProperties: null,
        //                                 body: body);//消息体
        //            return true;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }
        //}

        /// <summary>
        /// 最后一次声明队列的时间
        /// </summary>
        private static DateTime LastDeclareTime = DateTime.Now.AddDays(-10);

        /// <summary>
        /// 新增项
        /// </summary>
        /// <param name="exchange">交换机名</param>
        /// <param name="queueName">队列名</param>
        /// <param name="value">新增值</param>
        /// <param name="durable">是否持久化</param>
        /// <returns></returns>
        public static bool Add(string exchange, string queueName, string value, bool durable = false)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", Port = 5672, UserName = "guest", Password = "guest" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                try
                {
                    if(LastDeclareTime<DateTime.Now.AddSeconds(-10))
                    {
                        channel.QueueDeclare(queue: queueName,//队列名
                                            durable: durable,//是否持久化
                                            exclusive: false,//true:排他性，该队列仅对首次申明它的连接可见，并在连接断开时自动删除
                                            autoDelete: false,//true:如果该队列没有任何订阅的消费者的话，该队列会被自动删除
                                            arguments: null);//如果安装了队列优先级插件则可以设置优先级
                        LastDeclareTime = DateTime.Now;
                    }
                    //声明queue

                    for (int i = 0; i < 500000; i++)
                    {
                        var body = Encoding.UTF8.GetBytes(i.ToString());

                        channel.BasicPublish(exchange: exchange,//exchange名称
                                             routingKey: "hello",//如果存在exchange,则消息被发送到名称为hello的queue的客户端
                                             basicProperties: null,
                                             body: body);//消息体
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }


    }
}