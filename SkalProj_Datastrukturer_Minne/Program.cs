using System;
using System.Text;
using System.Xml;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, will handle the menus for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            //Q2: When does the list capacity increase? when an elements to be added is about to exceed list capacity
            //Q3: the list capcity is doubled
            //Q4: Because instantiating a new array and copying over elements is an expensive operations, it is much prefereable tomaintain slack capacity in the list than it is to constly copy data
            //Q5: List capacity does not seem to decrease with number of memebers
            //Q6: An array si preferable when one needs a collection of items that has a predetermined and fixed number of members, as it operates more effeciently than a list within these criteria


            List<string> theList = new List<string>();
            while (true)
            {
                Console.WriteLine($"Welcome to the list.\nThe list currently contains {theList.Count} elements, and has a capacity of {theList.Capacity}.");
                if (theList.Count > 0)
                {
                    Console.Write("The elements are: ");
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (string str in theList)
                    {
                        stringBuilder.Append($"{str} ");
                    }
                    Console.Write(stringBuilder.ToString());
                }
                Console.WriteLine("\nPress '+' followied by input to add to the list, press '-' to removed items from the list, press '0' to return to main menu.");
                string input = Console.ReadLine()!;
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        break;
                    case '-':
                        theList.Remove(value);
                        break;
                    case '0':
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Unnrecognized input, please try again");
                        break;
                }
                ConsoleUtils.WaitToContinue();
                Console.Clear();
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Welcome to the queue.\n");
            Queue<string> theQueue = new Queue<string>();
            string[] addQueue = new string[] { "", "Kalle", "Greta", "", "Stina", "", "Olle" };
            for (int i = 0; i < addQueue.Length; i++)
            {
                if (addQueue[i] == string.Empty)
                {
                    if (theQueue.Count != 0)
                        stringBuilder.Append($"{theQueue.Dequeue()} has left the queue.\n");
                }
                else
                {
                    theQueue.Enqueue(addQueue[i]);
                    stringBuilder.Append($"{addQueue[i]} has entered the queue\n");
                }
                Console.WriteLine(stringBuilder.ToString());
                ConsoleUtils.WaitToContinue();
                Console.Clear();
            }
            Console.WriteLine("Queue finished");
            ConsoleUtils.WaitToContinue();
            Console.Clear();
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            Stack<char> stack = new Stack<char>();
            Console.WriteLine("Please enter the string you want to reverse");
            string input = Console.ReadLine()!;
            foreach (char c in input)
            {
                stack.Push(c);
            }
            StringBuilder stringBuilder = new StringBuilder();
            while (stack.Count > 0)
            {
                stringBuilder.Append(stack.Pop());
            }
            Console.WriteLine($"Using technology only a marginal couple of magnitudes less ineffecient than AI, we have magically produced this reversed string: {stringBuilder}");
            ConsoleUtils.WaitToContinue();
        }



        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            Stack<int> stack = new Stack<int>();
            Console.WriteLine("Please enter your parenthesization subject string");
            string input = Console.ReadLine()!;
            foreach (char c in input)
            {
                int now;
                if (stack.Count > 0)
                    now = Parenthesizer(c, stack.Peek());
                else
                    now = ParenthesisToInt(c);

                if (now < 5 && now > 0)
                {
                    stack.Push(now);
                }
                else if (now == 0)
                {
                    stack.Pop();
                }
                else if (now < 0)
                {
                    Console.WriteLine("Incorrectly enclosed parenthesis detected, parethesis incorrectly paired or right hand characters have appeared without left hand counterpart, exiting...");
                    ConsoleUtils.WaitToContinue();
                    return;
                }
            }

            if (stack.Count > 0)
            {
                Console.WriteLine("Incorrectly enclosed parethesis detected in string, not all parethesis were closed");
            }
            else
            {
                Console.WriteLine("All parenthesis were correctly enclosed.");
            }
            ConsoleUtils.WaitToContinue();
            Console.Clear();

        }
        /// <summary>
        /// Checks parenthesis values from ParenthesisToInt
        /// </summary>
        /// <param name="cNext">har to be inspected</param>
        /// <param name="current">most recent parethesis character</param>
        /// <returns>retrurns values between -4 and 4 for relevant characters.
        /// 0 indicates as LH-RH pair, 5 indicates irrelevant chracters.
        /// positve values indicate new LH character, negative value indicates unpaired RH caharacter.</returns>
        static int Parenthesizer(char cNext, int current)
        {
            int iNext = ParenthesisToInt(cNext);
            if (iNext == 5)
                return 5;
            int now = iNext + current;
            if (now == 0)
                return now;
            else
                return iNext;
        }
        /// <summary>
        /// Checks an incoming char an converts it to numeric representaion of parenthesis, where LH + RH = 0, non-parenthesis characters are returned as 0
        /// </summary>
        /// <param name="next">char to be inspected and converted</param>
        /// <returns> value between -4 and 4, 5 indicates irrelevant char</returns>
        static int ParenthesisToInt(char next)
        {
            switch (next)
            {
                case '{':
                    return 1;
                case '}':
                    return -1;
                case '[':
                    return 2;
                case ']':
                    return -2;
                case '(':
                    return 3;
                case ')':
                    return -3;
                case '<':
                    return 4;
                case '>':
                    return -4;
                default:
                    return 5;
            }
        }
    }
}

