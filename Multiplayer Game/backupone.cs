//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Net;
//using System.Net.Sockets;
//using System.IO;

//namespace Multiplayer_Game
//{
//    class Program
//    {
//        //  variable to choose join or create game
//        static Mode mode;
//        static int choose;

//        //  enum for player choose
//        enum Mode
//        { Server, Client, Error, }

//        enum playerMove
//        { Rock, Paper, Scissor, noInput, }

//        struct Player
//        {
//            public String nickname;
//            public playerMove move;
//        }


//        //  game
//        static String game()
//        {
//            Player player;
//            int choose;
//            String input = "0";

//            //  prevent error in program
//            player.move = playerMove.noInput;

//            Console.WriteLine("Enter your nickname: "); player.nickname = Console.ReadLine();
//            Console.WriteLine("Enter your move");
//            Console.WriteLine("1. Rock");
//            Console.WriteLine("2. Paper");
//            Console.WriteLine("3. Scissor");
//            Console.WriteLine("Input: "); choose = Convert.ToInt32(Console.ReadLine());

//            switch (choose)
//            {
//                case 1:
//                    player.move = playerMove.Rock;
//                    input = Convert.ToString(choose);
//                    break;

//                case 2:
//                    player.move = playerMove.Paper;
//                    input = Convert.ToString(choose);
//                    break;

//                case 3:
//                    player.move = playerMove.Scissor;
//                    input = Convert.ToString(choose);
//                    break;

//                default:
//                    Console.WriteLine("Error::Please check your input and restart the program");
//                    input = "0";
//                    break;
//            }

//            return input;
//        }


//        //  create server
//        //  prepare server socket listener
//        static TcpListener listener;

//        //  client list
//        static List<TcpClient> clientList = new List<TcpClient>();

//        //  list message
//        static List<String> messageList = new List<String>();

//        //  listening client connection
//        public static void clientListener(object obj)
//        {
//            TcpClient client = (TcpClient)obj;
//            //  receive data from client stream and encode it from ascii into string
//            StreamReader reader = new StreamReader(client.GetStream());

//            Console.WriteLine("Client Conected...");

//            try
//            {
//                while (true)
//                {
//                    //  read data / client message from streamreader
//                    string message = reader.ReadLine();
//                    //  broadcast message to connected client
//                    BroadcastMessage(message, client);
//                    //  show client data in server console
//                    Console.WriteLine(message);
//                }
//            }
//            catch (IOException)   
//            {
//                Console.WriteLine("Client Disconnected...");
//            }

//            clientList.Remove(client);
//        }

//        //  broadcast message to client
//        public static void BroadcastMessage(String message, TcpClient excludeClient)
//        {
//            foreach (TcpClient client in clientList)
//            {
//                //  send client message to other client
//                if (client != excludeClient)
//                {
//                    //  Write message from Client, encode it into ASCII and send it to server network stream and each connected Client will receive the data
//                    StreamWriter writer = new StreamWriter(client.GetStream());
//                    writer.WriteLine(message);
//                    writer.Flush();
//                }
//            }
//        }

//        static void becameServer()
//        {
//            //  create new listener
//            listener = new TcpListener(IPAddress.Any, 1212);
//            listener.Start();
//            Console.WriteLine("Server booting...");

//            while (true)
//            {
//                //  waiting accept new client
//                Console.WriteLine("Waiting for opponent...");
//                TcpClient client = listener.AcceptTcpClient();
//                clientList.Add(client);

//                //  create new thread after accepting client
//                Thread thread = new Thread(clientListener);
//                thread.Start(client);
//            }
//        }


//        //  join server
//        static void becameClient()
//        {

//        }

//        static void Main(string[] args)
//        {
//            Console.WriteLine("Choose Game");
//            Console.WriteLine("1. Create a server");
//            Console.WriteLine("2. Joining a server");
//            Console.Write("Input: "); choose = Convert.ToInt32(Console.ReadLine());

//            switch (choose)
//            {
//                case 1:
//                    mode = Mode.Server;
//                    break;

//                case 2:
//                    mode = Mode.Client;
//                    break;

//                default:
//                    mode = Mode.Error;
//                    break;
//            }

//            switch (mode)
//            {
//                case Mode.Server:
//                    Console.WriteLine();
//                    Console.WriteLine("becoming " + mode);
//                    becameServer();
//                    break;

//                case Mode.Client:
//                    Console.WriteLine();
//                    Console.WriteLine("becoming " + mode);
//                    becameClient();
//                    break;

//                case Mode.Error:
//                    Console.WriteLine();
//                    Console.WriteLine("Error::Please check your input and restart the program");
//                    break;

//                default: break;
//            }

//            //  preventing program close before user can read all data
//            Console.ReadLine();
//        }
//    }
//}
