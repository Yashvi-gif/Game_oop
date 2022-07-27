// Control class
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    public enum Game { inputname, inputdesc, gameplay }

    public class Control
    {
        string name, desc;
        string output;
        Player _player;
        movecmd move;
        LookCommand look;
        QuitCmd quit;
        PutCommand put;
        TakeCmd take;
        Path _path1, _path2;
        Item gem, container, box, gem2;
        Bag _bag1;
        Location school, uni;
        cmdProcessor comm;
        Game stategm;

        public Control()
        {
            put = new PutCommand();
            take = new TakeCmd();
            move = new movecmd();
            look = new LookCommand();
            quit = new QuitCmd();
            gem = new Item(new string[] { "gem" }, "jewel", "This is a gem");
            container = new Item(new string[] { "bag" }, "contObject", "This is a my container");
            box = new Item(new string[] { "box" }, "boxx", "This is a box");
            _bag1 = new Bag(new string[] { "bag" }, "MyBag", "BlueBag");
            gem2 = new Item(new string[] { "gem2" }, "jewel2", "This is a gem2");
            school = new Location(new string[] { "school" }, "schl", "this is my school");
            uni = new Location(new string[] { "uni" }, "uni", "this is my school");
            _path1 = new Path(new string[] { "school", "inuni" }, school, uni);
            _path2 = new Path(new string[] { "uni", "inschool" }, uni, school);
            _bag1.Inventory.Put(gem2);
            school.AddPath(_path1);
            school.Inventory.Put(gem);
            uni.AddPath(_path2);

            comm = new cmdProcessor();
            comm.AddComm(move);
            comm.AddComm(look);
            comm.AddComm(quit);
            comm.AddComm(put);
            comm.AddComm(take);
            stategm = Game.inputname;
            output = "Whats your name?\n";

        }
        public string OutputCmd
        {
            get
            {
                return output;
            }
        }
        public string InputCmd(string stringg)
        {

            switch (stategm)
            {
                case Game.inputname:
                    name = stringg;
                    stategm = Game.inputdesc;
                    return name + "\nEnter your description here: \n";
                case Game.inputdesc:
                    desc = stringg;
                    stategm = Game.gameplay;
                    _player = new Player(name, desc);
                    _player.Inventory.Put(gem);
                    _player.Inventory.Put(box);
                    _player.Inventory.Put(container);
                    _player.Locatn = school;
                    _player.Inventory.Put(_bag1);

                    return "Heylo there, " + name + ", " + desc;
            }
            return comm.Execute(_player, stringg.Split());
        }

    }

} 

//MainWindow.xaml.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace guii
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TestDemo.Control ctrl;
        public MainWindow()
        {
           
            InitializeComponent();
            ctrl = new TestDemo.Control();
            mainConsole.Text = ctrl.OutputCmd;
        }
        private void ClickOnEnter(object s, RoutedEventArgs a)
        {
            mainConsole.Text = "\n" + ctrl.InputCmd(cmdBox.Text);
            cmdBox.Clear();
        }
        private void Cmd_textChanged(object s, RoutedEventArgs a)
        {

        }
    }
}
    


//MainWindow.xaml


<Window x:Class="guii.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:guii"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid Background="#FF1D1D1D">
        <Border BorderBrush="White" BorderThickness="2" HorizontalAlignment="Center" Height="190" Margin="0,50,0,0" VerticalAlignment="Top" Width="780" Background="#FF46">
            <ScrollViewer Foreground="Black" CanContentScroll="True">
                <TextBlock x:Name="mainConsole" TextWrapping="Wrap" Text="TextBlock" Margin="10,10,0,0" Foreground="Black" Background="#FF4"/>
            </ScrollViewer>
        </Border>
        <Button x:Name="enterBtn" Content="Enter" HorizontalAlignment="Center" Margin="697,273,0,0" VerticalAlignment="Top" Width="74" Height="23" Click="ClickOnEnter" Background="White" Foreground="Black" IsDefault="True"/>
        <TextBox x:Name="cmdBox" HorizontalAlignment="Left" Height="23" Margin="21,273,0,0" TextWrapping="Wrap" Text="" VerticalAlignment="Top" Width="649" TextChanged="Cmd_textChanged" Background="#FF4" Foreground="Black"/>
    </Grid>
</Window>
  