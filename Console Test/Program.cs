using Indieteur.GlobalHooks;
using System;
using System.Threading;

//Solution based on https://social.msdn.microsoft.com/Forums/vstudio/en-US/ed5be22c-cef8-4615-a625-d05caf113afc/console-keyboard-hook-not-getting-called?forum=csharpgeneral
namespace Console_Test
{
    /*As per my research, it seems that a message loop (https://stackoverflow.com/questions/2222365/what-is-a-message-pump) is needed by a low level hook for it to work properly.
     * Standard consoles do not implement this as compared to GUI applications (by using the Application.Run method). In order to fix the issue we are having with console apps, we need to subscribe to the message pump.
     * See the MessagePump.CS to see how this is implemented.*/


    class Program
    {
       
        static GlobalKeyHook globalKeyHook;
        static GlobalMouseHook globalMouseHook;


        static void RealMain()
        {
           
            Console.ReadKey();
            //Do everything that you need to do starting from here.
            Environment.Exit(0); //Once you have completed all the task, use this piece of code to exit the console application otherwise, the console will always wait for more messages.
        }

        static void Main(string[] args)
        {
            //Make sure to instantiate the hook itself on the main thread or it wouldn't work.
            globalKeyHook = new GlobalKeyHook();
            globalMouseHook = new GlobalMouseHook();
            globalKeyHook.OnKeyDown += GlobalKeyHook_OnKeyDown;
            globalKeyHook.OnKeyPressed += GlobalKeyHook_OnKeyPressed;
            globalKeyHook.OnKeyUp += GlobalKeyHook_OnKeyUp;
            globalMouseHook.OnButtonDown += GlobalMouseHook_OnButtonDown;


            Thread WaitingThread = new Thread(new ThreadStart(RealMain)); //Create a new thread which will be where the actual tasks will be performed.
            WaitingThread.Start(); //Start the thread.
            MessagePump.WaitForMessages(); //Wait for messages from the message pump
        }

        private static void GlobalMouseHook_OnButtonDown(object sender, GlobalMouseEventArgs e)
        {
            Console.WriteLine("Button Down: " + e.Button.ToString());
        }

        private static void GlobalKeyHook_OnKeyUp(object sender, GlobalKeyEventArgs e)
        {
            Console.WriteLine("Released " + e.CharResult);
        }

        private static void GlobalKeyHook_OnKeyPressed(object sender, GlobalKeyEventArgs e)
        {
            Console.WriteLine("Pressed " + e.CharResult);
        }

        private static void GlobalKeyHook_OnKeyDown(object sender, GlobalKeyEventArgs e)
        {
            Console.WriteLine("KeyDown " + e.CharResult);
        }

       
     
    }

}
