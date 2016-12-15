using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TronBattle.Helpers
{
    public class Helpers
    {
        internal static dynamic ActivateFromAssembly(string assemblyPath, int xPosition, int yPosition, char color)
        {
            var ass = Assembly.LoadFile(assemblyPath);
            var types = ass.GetTypes();
            var correctType = types.FirstOrDefault(type => type.Name == "Competitor");
            if (correctType == null)
            {
                throw new Exception($"There is no class with the name Competitor in assembly {assemblyPath}");
            }
            var instance = Activator.CreateInstance(correctType, xPosition, yPosition, color);
            return instance;
        }

        public static bool ExecuteWithTimeLimit(TimeSpan timeSpan, Action codeBlock)
        {
            try
            {
                Func<bool> lol = () =>
                {
                    try
                    {
                        codeBlock.Invoke();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                };
                var task = Task.Factory.StartNew(lol);
                task.Wait(timeSpan);
                return task.IsCompleted && task.Result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerExceptions[0];
            }
        }
        public static char GetLetter(Random random)
        {
            // This method returns a random lowercase letter.
            // ... Between 'a' and 'z' inclusize.
            int num = random.Next(0, 26); // Zero to 25
            char let = (char)('a' + num);
            return let;
        }
    }
}