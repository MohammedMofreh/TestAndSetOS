using System.Threading;

namespace TestAndSet
{
    internal class Program
    {
        static int lockValue = 0;

        #region TheImplementationOfTestAndSetMethod
        /// <summary>
        ///  Atomically sets target to 1 and returns its previous value ,,
        ///  using Interlocked.Exchange, we achieve atomicity, 
        ///  ensuring that no other threads can interfere with the operation of testing and setting the lock.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        static int TestAndSet(ref int target)
        {
            // location in memory "target" 
            return Interlocked.Exchange(ref target, 1);
        }
        #endregion

        #region PrintMessage
        /// <summary>
        /// PrintMessage
        /// </summary>
        /// <param name="Text"></param>
        static void PrintMessage(string Text)
        {
            Console.WriteLine("********************************");
            Console.WriteLine(Text);
            Console.WriteLine("********************************");
        }
        #endregion

        static void Main()
        {
            // Example usage
            if (TestAndSet(ref lockValue) == 0) // as the location in memory 
                                                // c# does not support the pointer so we use the keyword ref 
            {
                PrintMessage("Critical section entered.");
                // Perform critical section operations here
                // Once done, release the lock
                lockValue = 0;
            }
            else
            {
                PrintMessage("Resource is currently locked.");
                // Handle the case where the resource is already locked
            }

        }
    }
}