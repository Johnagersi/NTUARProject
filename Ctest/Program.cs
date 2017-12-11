﻿using System;
using System.IO;
using System.Net;
using ArangoDB.Client;
using Ctest.DataBaseManagement;
using Ctest.Edges;
using Ctest.Objs;
using Ctest.Scenes;
using Ctest.Users;
using System.Linq;
//using NUnit.Framework;



namespace Ctest
{
    static class Constants
    {
        public static string urlWithPort = "http://localhost:8529";
        public static string url_POST = "http://localhost:8529/_db/test/test/receive-binary";
        public static string url_GET = "http://localhost:8529/_db/test/test/provide-binary-file";
        public static string path_OBJ= "/home/crespo/Bureau/db/OBJ/";
        public static string path_Scene= "/home/crespo/Bureau/db/Scene/";
        public static string database = "test";
        public static string adminName = "root";
        public static string password = "azertyuiop123";   
        public static string typeScene = "UNKNOWN";
        public static string typeOBJ = "obj"; 

        public static string typeTexture = "UNKNOWN";   

        public static string path_obj_Default = "/home/crespo/Bureau/db/cube.obj";

        public static string GraphName = "App";
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Call the database
            dataBaseManager Data = new dataBaseManager(Constants.urlWithPort,Constants.database,Constants.adminName,Constants.password);
            
            //Add a User in the database.
            /*var person = new User
            {
                name = "BoB",
                emailAddress = "Bob.crespo@hotmail.fr",
                password = "1234",
                age = 24,
                
            };
            
            Data.db.Insert<User>(person);
            Console.WriteLine(person.id);*/
            
            //Create a collection
            //var createResult = Data.db.CreateCollection("User");
            //Console.WriteLine(createResult);
            
            //Add user
            //User ange = new User("Ange","ange.crespo@hotmail.fr","password",23);
            
            //Save user
            //ange.SaveInDB();

            //Create a Edges 

            /*Data.createEdge("Edge_Friend");
            Data.createEdge("Edge_ownOBJ");
            Data.createEdge("Edge_ownScene");
            Data.createEdge("Edge_shareOBJ");
            Data.createEdge("Edge_shareScene");
            Data.createEdge("Edge_isIn"); */

            //Create Graph

            //Data.createGraph("test");

            //DeleteGraph

            //Data.deleteGraph("test");

            User ange = new User("ange.crespo@hotmail.fr","r");
            // User Bob = new User("Bob.crespo@hotmail.fr","r");
            //Scene scn = new Scene("ma Scene","test");
            //scn.SaveInDB();
            OBJ obj = new OBJ("test","caca",2);
            //Console.WriteLine(obj2);
            //Edge_Friend egde = new Edge_Friend(ange,Bob);
            //edge.SaveInDB();
//curl -X POST --data "@cube.obj" "http://localhost:8529/_db/test/test/receive-binary?path=/home/crespo/Bureau/db/try&id=test&type=obj"
            //byte[] data = File.ReadAllBytes();
            //var test = obj.getFile()[0];
            
            //Console.WriteLine("\nResponse Received.The contents of the file uploaded are:\n{0}",System.Text.Encoding.ASCII.GetString(test));
            
            // TODO : TEST.CS TO RUN TEST IF TIME.

            
            /*var cursor = Data.db.All<User>();
            var loadedUsers = cursor.ToList();
            Console.Write(loadedUsers[1]);*/
            /*var result = Data.db.Traverse<User, Edge_Friend>(new TraversalConfig
            {
                StartVertex = ange.id,
                GraphName = "App",
                Direction = EdgeDirection.Any,
                MaxDepth = 1,
            });*/
            
            Console.WriteLine(Data.db.ListCollections()[0]);
            /*var result = Data.db.Traverse<User,Edge_Friend>(new TraversalConfig
            {
                StartVertex = ange.id,
                GraphName = Constants.GraphName,
                
                Direction = EdgeDirection.Any,
                MaxDepth = 1,
            });*/

            var result = Data.db.Query().Traversal<User, Edge_Friend>(ange.id);

            var result2=result.Depth(1,1);
            var result3=result2.OutBound();
            //var result4=result3.Edge(Data.db.NameOf<Edge_Friend>(), EdgeDirection.Any);
            var result5 = result3.Graph(Constants.GraphName);
            var result6=result5.Select(g => g);
            var result7=result6.ToList();
           
            //Console.WriteLine(result5.ToList());
           foreach (var i in result7){
               Console.WriteLine(i);
           }
            Console.WriteLine(Data.db.NameOf<Edge_Friend>());
            Console.WriteLine("Hello World!");
        }
    }
}