using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace MovieBuddy.Services
{
    public static class DynamoDBService
    {
        private static string accessKey = "AKIAJVD7Q5PTNESEYKPA";
        private static string privateKey = "hGr2eyyrAHmiZaUebp3hhQtDHqm+9HnWeiwuMJGb";
        public static void InsertItem<T>(T input)
        {
            using (var client = new AmazonDynamoDBClient(accessKey, privateKey, RegionEndpoint.USEast1))
            {
                var name = typeof(T).Name;
                var primaryKey = name + "ID";
                var items = new Dictionary<string, AttributeValue>();
                items[primaryKey] = new AttributeValue { S = Guid.NewGuid().ToString() };
                foreach (var property in typeof(T).GetProperties())
                {
                    if (!items.ContainsKey(property.Name))
                    {
                        if (property.PropertyType == typeof(string))
                        {
                            var value = (string) property.GetValue(input);
                            items[property.Name] = new AttributeValue { S = value };
                        }
                        else if (property.PropertyType == typeof(DateTime))
                        {
                            var value = (DateTime)property.GetValue(input);
                            items[property.Name] = new AttributeValue { S = value.ToString() };
                        }
                        else if (property.PropertyType == typeof(Guid))
                        {
                            var value = (Guid)property.GetValue(input);
                            items[property.Name] = new AttributeValue { S = value.ToString() };
                        }
                        else if (property.PropertyType.IsNumericType())
                        {
                            var value = (double)property.GetValue(input);
                            items[property.Name] = new AttributeValue { N = value.ToString() };
                        }
                        else if (property.PropertyType == typeof(bool))
                        {
                            var value = (bool)property.GetValue(input);
                            items[property.Name] = new AttributeValue { BOOL = value };
                        }
                    }
                }
                var request = new PutItemRequest
                {
                    TableName = name,
                    Item = items
                };
                var asyncResult = client.PutItemAsync(request);
                while (!asyncResult.IsCompleted)
                {
                    Thread.Sleep(200);
                }
                if (asyncResult.IsFaulted)
                {
                    throw asyncResult.Exception;
                }
            }
        }
        public static T ReadData<T>(string id)
        {
            using (var client = new AmazonDynamoDBClient(accessKey, privateKey, RegionEndpoint.USEast1))
            {
                var name = typeof(T).Name;
                var primaryKey = name + "ID";
                var request = new GetItemRequest
                {
                    TableName = name,
                    Key = new Dictionary<string, AttributeValue>() { { primaryKey, new AttributeValue { S = id } } },
                };
                var asyncResult = client.GetItemAsync(request);
                while (!asyncResult.IsCompleted)
                {
                    Thread.Sleep(200);
                }
                if (asyncResult.IsFaulted)
                {
                    throw asyncResult.Exception;
                }
                var response = asyncResult.Result;
                var output = (T)Activator.CreateInstance(typeof(T));
                foreach (var property in typeof(T).GetProperties())
                {
                    if (response.Item.ContainsKey(property.Name))
                    {
                        var value = response.Item[property.Name];
                        if (property.PropertyType == typeof(string) && value.S != null)
                        {
                            property.SetValue(output, value.S);
                        }
                        else if (property.PropertyType == typeof(DateTime) && value.S != null)
                        {
                            property.SetValue(output, value.S);
                        }
                        else if (property.PropertyType == typeof(Guid) && value.S != null)
                        {
                            property.SetValue(output, value.S);
                        }
                        else if (value.IsMSet && value.N != default(string))
                        {
                            property.SetValue(output, value.N);
                        }
                        else if (value.IsBOOLSet)
                        {
                            property.SetValue(output, value.B);
                        }
                    }
                }
                return output;
            }
        }
        public static bool IsNumericType(this object o)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }
    }
}
