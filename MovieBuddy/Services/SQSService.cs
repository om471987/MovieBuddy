using System;
using Amazon.S3;
using Amazon.SQS;
using Amazon.SQS.Model;
using System.Threading;
using Amazon;
using System.Collections.Generic;

namespace MovieBuddy.Services
{
    public static class SQSService
    {
        private static string accessKey = "AKIAJVD7Q5PTNESEYKPA";
        private static string privateKey = "hGr2eyyrAHmiZaUebp3hhQtDHqm+9HnWeiwuMJGb";
        private static string venueOrderCreationQueue = "https://sqs.us-west-2.amazonaws.com/650667966831/VenueOrderCreation";
        public static void Insert(string message)
        {
            using(var client = new AmazonSQSClient(accessKey, privateKey, RegionEndpoint.USWest2))
            {
                var sendMessageRequest = new SendMessageRequest 
                {
                    MessageBody = message,
                    QueueUrl = venueOrderCreationQueue
                };
                var asyncResult = client.SendMessageAsync(sendMessageRequest);
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
    }
}
