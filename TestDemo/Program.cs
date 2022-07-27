using System;

namespace TestDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name ");
            string pname = Console.ReadLine();
            Console.WriteLine(" please enter your description ");
            string pdesc = Console.ReadLine();
            Player _player = new Player(pname, pdesc);
            Item gem = new Item(new string[] { "gem" }, "jewel", "This is a gem");
            Item container = new Item(new string[] { "bag" }, "contObject", "This is a my container");
            _player.Inventory.Put(gem);
            _player.Inventory.Put(container);
            Bag _bag1 = new Bag(new string[] { "bag" }, "MyBag", "BlueBag");
            Item gem2 = new Item(new string[] { "gem2" }, "jewel2", "This is a gem2");
            _bag1.Inventory.Put(gem2);
            _player.Inventory.Put(_bag1);
            movecmd move = new movecmd();
            LookCommand look = new LookCommand();
            QuitCmd quit = new QuitCmd();
            cmdProcessor comm = new cmdProcessor();
            comm.AddComm(quit);
            comm.AddComm(move);
            comm.AddComm(look);
           
            Location school, uni;
            Path _path1, _path2;
            school = new Location(new string[] { "school" }, "schl", "this is my school");
            uni = new Location(new string[] { "uni" }, "uni", "this is my school");
            _path1 = new Path(new string[] { "school", "inuni" }, school, uni);
            _path2 = new Path(new string[] { "uni", "inschool" }, uni, school);
            school.AddPath(_path1);
            school.Inventory.Put(gem);
            uni.AddPath(_path2);
            _player.Locatn = school;
            PutCommand put = new PutCommand();
            TakeCmd take = new TakeCmd();
            comm.AddComm(put);
            comm.AddComm(take);

            while (true)
            {
                Console.WriteLine("Enter your command");
                string _cmd = Console.ReadLine();
                Console.WriteLine(comm.Execute(_player, _cmd.Split()));
                if (_cmd.Split()[0] == "quit")
                {
                    break;
                }
            }




        }
    }
}
