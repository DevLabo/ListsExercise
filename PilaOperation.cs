using System;
using System.Collections.Generic;
using System.Text;

namespace ListsExercise
{
    public sealed class PilaOperation
    {
        public static PilaOperation Instance { get; private set; } = new PilaOperation();

        public Stack<int> OrderStack(Stack<int> pila)
        {
            var result = new Stack<int>();
            while (pila.Count > 0)
            {
                var temporary = pila.Pop();
                while (result.Count > 0 && temporary < result.Peek())
                {
                    pila.Push(result.Pop());
                }
                result.Push(temporary);
            }
            return result;
        }
    }
}
