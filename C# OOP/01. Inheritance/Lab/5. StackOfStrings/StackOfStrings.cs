using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        private Stack<string> stack;
        public StackOfStrings()
        {
            stack = new Stack<string>();
        }
        public bool IsEmpty()
        {
            return stack.Count == 0;
        }
        public void AddRange(Stack<string> stack)
        {
            while (stack.Count > 0)
            {
                this.stack.Push(stack.Pop());
            }
        }
    }
}
