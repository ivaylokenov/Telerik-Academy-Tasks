using System;
using System.Configuration;
 
namespace AbstractFactory {
    public interface IButton {
        void Paint();
    }
 
    public interface IGUIFactory {
        IButton CreateButton();
    }
 
    public class OSXButton : IButton { // Executes fourth if OS:OSX
        public void Paint() {
            System.Console.WriteLine("I'm an OSXButton");
        }
    }
 
    public class WinButton : IButton { // Executes fourth if OS:WIN
        public void Paint() {
            System.Console.WriteLine("I'm a WinButton");
        }
    }
 
    public class OSXFactory : IGUIFactory { // Executes third if OS:OSX
        IButton IGUIFactory.CreateButton() {
            return new OSXButton();
        }
    }
 
    public class WinFactory : IGUIFactory { // Executes third if OS:WIN
        IButton IGUIFactory.CreateButton() {
            return new WinButton();
        }
    }
 
    public class Application {
        public Application(IGUIFactory factory) {
            IButton button = factory.CreateButton();
            button.Paint();
        }
    }
 
    public class ApplicationRunner {
        static IGUIFactory CreateOsSpecificFactory() { // Executes second
            // Contents of App.Config associated with this C# project
            //<?xml version="1.0" encoding="utf-8" ?>
            //<configuration>
            //  <appSettings>
            //    <!-- Uncomment either Win or OSX OS_TYPE to test -->
            //    <add key="OS_TYPE" value="Win" />
            //    <!-- <add key="OS_TYPE" value="OSX" /> -->
            //  </appSettings>
            //</configuration>
            string sysType = ConfigurationSettings.AppSettings["OS_TYPE"];
            if (sysType == "Win") {
                return new WinFactory();
            } else {
                return new OSXFactory();
            }
        }
 
        static void Main() { // Executes first
            new Application(CreateOsSpecificFactory());
            Console.ReadLine();
        }
    }
}